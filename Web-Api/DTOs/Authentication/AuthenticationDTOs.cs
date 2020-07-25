using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Web_Api.DTOs.Authentication
{
    public class UserDto
    {
        public string Username { get; set; }
        public int EmpSn{ get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public UserRole Role { get; set; }
        public enum UserRole
        {
            Admin,
            Manager,
            Standard
        }
    }
    
    public class AuthenticationResultDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }

    public class RefreshTokenRequestDto
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }

    public class UserLoginRequestDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
    
    public class UserChangeMyPasswordFormDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
    
    public class UserRegistrationRequestDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public UserDto.UserRole Role { get; set; }
    }
    
    public class SetUserFormDto
    {
        public string Password { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public UserDto.UserRole? Role { get; set; }
    }
}
