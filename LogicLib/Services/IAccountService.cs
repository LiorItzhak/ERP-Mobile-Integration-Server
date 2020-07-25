using LogicLib.Services.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Entities.Authentication;

namespace LogicLib.Services
{
    public interface IAuthenticationService
    {

        Task<IdentityUser> GetAsync(IdentityUser.UserRole applicantUserRole, string username);
        Task<AuthenticationResult> LoginAsync(string username, string password);
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken);
        Task CreateUserAsync(string creatorUserName, UserRegistrationRequest userRegistrationRequest);
        Task<IdentityUser> SetUserProperties(string username, SetUserForm setUserForm);
    }
    
    public class AuthenticationResult
    {
        public const string EmployeeSnClaimTag = "empSn";
        public const string UserIdClaimTag = "userid";
        public const string UserRoleClaimTag = "role";

        public string Token { get; set; }
        public string RefreshToken { get; set; }

    }
    

    
    public class UserRegistrationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
        public IdentityUser.UserRole Role { get; set; }
    }
    
    public class SetUserForm
    {
        public string Password { get; set; }
        public IdentityUser.UserRole? Role { get; set; }
    }



    

}
