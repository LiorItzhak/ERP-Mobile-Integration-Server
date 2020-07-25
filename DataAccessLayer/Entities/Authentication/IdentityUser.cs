using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Entities.Authentication
{
    public class IdentityUser : IdentityUser<int>
    {
        public int EmpId { get; set; }
        public UserRole Role { get; set; }



        public enum UserRole
        {
            Admin,
            Manager,
            Standard
        }
    }
}