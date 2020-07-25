using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CrossLayersUtils;
using CrossLayersUtils.Utils;
using DataAccessLayer;
using DataAccessLayer.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityUser = DataAccessLayer.Entities.Authentication.IdentityUser;
using RefreshToken = DataAccessLayer.Entities.Authentication.RefreshToken;

namespace LogicLib.Services.Impl
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IDalService _dalService;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly TokenValidationParameters _tokenValidationParametersWithoutExpiry;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        private const string CreatorDontExistMsg = "creator dont exist";

        private const string CreatorDontHavePermissionAdminCanCreateAdmin =
            "creator dont have permission - only admin can create new admin";

        private const string CreatorDontHavePermission =
            "creator dont have permission - only manager or admin can create new user";

        private const string EmployeeNotExist = "Employee not exist";

        private const string UserAlreadyExist = "User already exist";


        public AuthenticationService(
            TokenValidationParameters tokenValidationParameters,
            JwtSettings jwtSettings,
            IDalService dalService,
            UserManager<IdentityUser> userManager,
            ILogger<AuthenticationService> logger)
        {
            _tokenValidationParametersWithoutExpiry = tokenValidationParameters.Clone();
            _tokenValidationParametersWithoutExpiry.ValidateLifetime = false;
            _dalService = dalService;
            _logger = logger;
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }


        public async Task CreateUserAsync(string creatorUserName,
            UserRegistrationRequest userRegistrationRequest)
        {
            //check creator permissions
            var creator = await _userManager.FindByNameAsync(creatorUserName);
            if (creator == null)
                throw new IllegalArgumentException(CreatorDontExistMsg);


            //only manager or admin can create new user
            if (creator.Role != IdentityUser.UserRole.Admin && creator.Role != IdentityUser.UserRole.Manager)
                throw new InvalidCredentialException(CreatorDontHavePermission);

            //only admin can create new admin
            if (creator.Role != IdentityUser.UserRole.Admin &&
                userRegistrationRequest.Role == IdentityUser.UserRole.Admin)
                throw new InvalidCredentialException(CreatorDontHavePermissionAdminCanCreateAdmin);

            //check if the user already exist
            if (await _userManager.FindByNameAsync(userRegistrationRequest.Username) != null)
                throw new IllegalArgumentException(UserAlreadyExist);


            //check if register by email or by empSn
            var emailValidator = new EmailValidator();
            if (emailValidator.Validate(userRegistrationRequest.Username.Trim()).IsValid)
            {
                var email = userRegistrationRequest.Username.Trim();
                //register by email - get employee's Sn
                userRegistrationRequest.Username = (await _dalService.CreateUnitOfWork().Employees
                    .SingleOrDefaultAsync(x => x.IsActive && x.Email == email)).Sn.ToString();
            }

            //check if the user have matching employee
            var emp = await _dalService.CreateUnitOfWork()
                .Employees.SingleOrDefaultAsync(x => x.Sn.ToString() == userRegistrationRequest.Username);

            if (emp == null)
                throw new IllegalArgumentException(EmployeeNotExist);


            var newUser = new IdentityUser
            {
                Role = userRegistrationRequest.Role,
                UserName = userRegistrationRequest.Username,
                EmpId = emp.Sn
            };

            var createdUserResult = await _userManager.CreateAsync(newUser, userRegistrationRequest.Password);

            if (!createdUserResult.Succeeded)
                throw new IllegalArgumentException(createdUserResult.Errors
                    .Select(x => x.Description).Aggregate((s1, s2) => $"{s1},{s2}"));


            //user created successfully 
        }

        public async Task<IdentityUser> SetUserProperties(string username, SetUserForm setUserForm)
        {
            if (setUserForm.Password != null)
            {
                var user = await GetUserByEmailOrUserName(username);
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, resetToken, setUserForm.Password);
                if (!result.Succeeded)
                    throw new IllegalArgumentException(result.Errors
                        .Select(x => x.Description).Aggregate((s1, s2) => $"{s1},{s2}"));

                await RestrictAllTokens(username);
            }

            if (setUserForm.Role.HasValue)
            {
                var user = await GetUserByEmailOrUserName(username);
                user.Role = setUserForm.Role.Value;
                await _userManager.UpdateAsync(user);
            }

            return await GetUserByEmailOrUserName(username);
        }


        public async Task<IdentityUser> GetAsync(IdentityUser.UserRole applicantUserRole, string username)
        {
            //check applicant permissions
            if (applicantUserRole != IdentityUser.UserRole.Admin && applicantUserRole != IdentityUser.UserRole.Manager)
                throw new InvalidCredentialException("applicant user dont have permissions to ask for user's details");
            var user = await GetUserByEmailOrUserName(username);
            if (user == null) throw new NotFoundException("User don't exist");
            return user;
        }

        public async Task<AuthenticationResult> LoginAsync(string username, string password)
        {
            //check whether the user exists
            var user = await GetUserByEmailOrUserName(username);

            if (user == null) throw new NotFoundException("User don't exist");
            //check employee
            var emp = await _dalService.CreateUnitOfWork().Employees.SingleOrDefaultAsync(x => x.Sn == user.EmpId);
            if (emp == null) throw new IllegalArgumentException("Employee not exist");
            if (!emp.IsActive) throw new InvalidStateException("Employee inactive");


            var validationResult = new UserLoginValidator(password, _userManager).Validate(user);
            if (!validationResult.IsValid)
                throw new IllegalArgumentException(validationResult.Errors
                    .Select(x => x.ErrorMessage).Aggregate((s1, s2) => $"{s1},{s2}"));

            //the information has been validated!
            return await GenerateAuthenticationResultForUser(user);
        }


        public async Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken,
            CancellationToken cancellationToken)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            var validatedToken = GetPrincipalFromToken(token);
            if (validatedToken == null) throw new IllegalArgumentException("Invalid Token");


            var storedRefreshToken = await transaction.RefreshTokens.FindByIdAsync(refreshToken);
            if (storedRefreshToken == null)
                throw new IllegalArgumentException("This refresh token doses not exist");


            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            var validationResult = new RefreshTokenValidator(jti).Validate(storedRefreshToken);
            if (!validationResult.IsValid)
                throw new IllegalArgumentException(validationResult.Errors
                    .Select(x => x.ErrorMessage).Aggregate((s1, s2) => $"{s1},{s2}"));

            //refresh-token is valid and match the given token - generate new tokens
            storedRefreshToken.IsUsed = true;
            await transaction.RefreshTokens.UpdateAsync(storedRefreshToken);
            var user = await _userManager
                .FindByIdAsync(validatedToken.Claims.Single(x => x.Type == "userid").Value);


            cancellationToken.ThrowIfCancellationRequested();
            await transaction.CompleteAsync(cancellationToken);
            return await GenerateAuthenticationResultForUser(user);
        }

        private async Task<IdentityUser> GetUserByEmailOrUserName(string usernameOrEmail)
        {
            //check if login by email or by empSn
            var emailValidator = new EmailValidator();
            if (!emailValidator.Validate(usernameOrEmail.Trim()).IsValid)
                return await _userManager.FindByNameAsync(usernameOrEmail);
            //login by email - get employee's Sn
            var email = usernameOrEmail.Trim().ToLower();
            var empSn = (await _dalService.CreateUnitOfWork().Employees
                .SingleOrDefaultAsync(x => x.IsActive && x.Email.ToLower() == email ))?.Sn;

            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.EmpId == empSn);
            //check whether the user exists
            return user;
        }

        private async Task<AuthenticationResult> GenerateAuthenticationResultForUser(IdentityUser user)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            var emp = await transaction.Employees.SingleOrDefaultAsync(x => x.Sn == user.EmpId);
            if (emp == null || !emp.IsActive)
                throw new InvalidStateException("This user is inactive");

            //generate user's claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(AuthenticationResult.UserIdClaimTag, user.Id.ToString()),
                new Claim(AuthenticationResult.UserRoleClaimTag, user.Role.ToString()),
                new Claim(AuthenticationResult.EmployeeSnClaimTag, emp.Sn.ToString()),
            };
            if (emp.Email != null)
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, emp.Email));
            
            //Generate token and refresh token:
            //generate token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = null, // Not required as no third-party is involved
                Audience = null, // Not required as no third-party is involved 
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddTicks(_jwtSettings.TokenLifetime.Ticks),
                SigningCredentials = new SigningCredentials(_jwtSettings.PrivateSigningSecretKey,
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);

            //generate refresh token
            var refreshToken = new RefreshToken
            {
                //Key = Guid.NewGuid().ToString(),//TODO AUTO GENERATE
                JwtId = jwtToken.Id,
                UserId = user.Id,
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenLifetimeDays)
            };

            //save the refresh token and get the generated token's key
            refreshToken = await transaction.RefreshTokens.AddAsync(refreshToken);
            await transaction.CompleteAsync();
            //generate success response
            return new AuthenticationResult
            {
                Token = token,
                RefreshToken = refreshToken.Key,
            };
        }


        private async Task RestrictAllTokens(string username)
        {
            using var uow = _dalService.CreateUnitOfWork();
            var user = await GetUserByEmailOrUserName(username);
            var tokens = await uow.RefreshTokens
                .FindAllAsync(x => x.UserId == user.Id && !x.IsInvalidated, PageRequest.Of(0, int.MaxValue));
            foreach (var refreshToken in tokens)
            {
                refreshToken.IsInvalidated = true;
                await uow.RefreshTokens.UpdateAsync(refreshToken);
            }

            await uow.CompleteAsync();
        }

        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, _tokenValidationParametersWithoutExpiry,
                    out var validatedToken);
                return IsJwtWithValidSecurityAlgorithm(validatedToken) ? principal : null;
            }
            catch
            {
                return null;
            }
        }

        private static bool IsJwtWithValidSecurityAlgorithm(SecurityToken vaildatedToken)
        {
            return (vaildatedToken is JwtSecurityToken jwtSecurityToken) &&
                   jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                       StringComparison.InvariantCultureIgnoreCase);
        }

        private class UserLoginValidator : AbstractValidator<IdentityUser>
        {
            public UserLoginValidator(string enteredPassword, UserManager<IdentityUser> userManager)
            {
                RuleFor(x => x).MustAsync(async (x, cancellation) =>
                        await userManager.CheckPasswordAsync(x, enteredPassword))
                    .WithMessage("The entered password is invalid");
            }
        }

        private class EmailValidator : AbstractValidator<string>
        {
            public EmailValidator()
            {
                RuleFor(x => x).EmailAddress();
            }
        }

        private class RefreshTokenValidator : AbstractValidator<RefreshToken>
        {
            public RefreshTokenValidator(string jwtId)
            {
                RuleFor(x => x.IsInvalidated).Equal(false)
                    .WithMessage("The refresh token is invalidated");
//                RuleFor(x => x.IsUsed).Equal(false)
//                    .WithMessage("The refresh token has been used");
                RuleFor(x => x.ExpiryDate).Must(expiryDate => expiryDate > DateTime.UtcNow)
                    .WithMessage("This refresh token has been expired");
                RuleFor(x => x.JwtId).Equal(jwtId)
                    .WithMessage("The refresh does not match this JWT ");
            }
        }
    }


    public class JwtSettings
    {
        private string _privateSigningSecretBase64;

        public string PrivateSigningSecretBase64
        {
            get => _privateSigningSecretBase64;
            set
            {
                PrivateSigningSecretKey =
                    //new SymmetricSecurityKey(Encoding.UTF8.GetBytes(value));//UTF string
                    new SymmetricSecurityKey(Convert.FromBase64String(value)); //Base64 string
                _privateSigningSecretBase64 = value;
            }
        }

        public SymmetricSecurityKey PrivateSigningSecretKey { get; private set; }

        public TimeSpan TokenLifetime { get; set; }

        public int RefreshTokenLifetimeDays { get; set; }
    }
}

//                //validate that the token is expired 
//                var tokenExpiryDateTimeUnix =
//                    long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
//                var tokenExpiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
//                    .AddSeconds(tokenExpiryDateTimeUnix);
//                if (tokenExpiryDateTimeUtc > DateTime.UtcNow)
//                    return new AuthenticationResult
//                        {IsSuccess = false, Errors = new[] {"This token hasn't expired yet"}};