using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Entities.Authentication;
using LogicLib.Services;
using LogicLib.Services.Impl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Web_Api.DTOs;
using Web_Api.DTOs.Authentication;
using Web_Api.Installers;
using Web_Api.Utils;

namespace Web_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<AuthController> _logger;
        private readonly IMapper _mapper;

        public AuthController(IAuthenticationService authenticationService, IMapper mapper,
            ILogger<AuthController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
            _mapper = mapper;
        }


        [Authorize(Policy = Authorizations.RequireAdminOrManagerRole)]
        [HttpGet("User/{username}")]
        public async Task<UserDto> GetUser(string username)
        {
            var loggedInUserRoleString = User.FindFirst(ClaimTypes.Role).Value;
            var loggedInUserRole =
                (IdentityUser.UserRole) Enum.Parse(typeof(IdentityUser.UserRole), loggedInUserRoleString);
            var result = await _authenticationService.GetAsync(loggedInUserRole, username);
            return _mapper.Map<UserDto>(result);
        }


        [Authorize(Policy = Authorizations.RequireAdminOrManagerRole)]
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserRegistrationRequestDto registrationRequest, CancellationToken cancellationToken)
        {
            var currentUserName = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await _authenticationService
                .CreateUserAsync(currentUserName, _mapper.Map<UserRegistrationRequest>(registrationRequest));
            return Created("", registrationRequest.Username);
        }


        [HttpPut("ChangeMyPassword")]
        public async Task<IActionResult> ChangeMyPassword([FromBody] UserChangeMyPasswordFormDto changePasswordForm)
        {
            throw new NotImplementedException();
        }

        [Authorize(Policy = Authorizations.RequireAdminOrManagerRole)]
        [HttpPut("SetUser/{username}")]
        public async Task<UserDto> SetUser(string username, [FromBody] SetUserFormDto setUserForm)
        {
            var result = await _authenticationService
                .SetUserProperties(username, _mapper.Map<SetUserForm>(setUserForm));
            return _mapper.Map<UserDto>(result);
        }


        // Post: api/Auth/login
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<AuthenticationResultDto> Login([FromBody] UserLoginRequestDto loginForm)
        {
            var tokenRequestResult = await _authenticationService.LoginAsync(loginForm.Username, loginForm.Password);
            _logger.LogInformation($"User {loginForm.Username} logged in.");
            return _mapper.Map<AuthenticationResultDto>(tokenRequestResult);
        }

        // Post: api/Auth/RefreshToken
        [AllowAnonymous]
        [HttpPost("RefreshToken")]
        public async Task<AuthenticationResultDto> RefreshToken([FromBody] RefreshTokenRequestDto refreshTokenRequest,
            CancellationToken cancellationToken)
        {
           // throw new Exception("test exception");
            var tokenRequestResult = await _authenticationService
                .RefreshTokenAsync(refreshTokenRequest.Token, refreshTokenRequest.RefreshToken, cancellationToken);
            return _mapper.Map<AuthenticationResultDto>(tokenRequestResult);
        }
    }
}