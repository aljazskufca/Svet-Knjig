using System.Security.Policy;
using Microsoft.AspNetCore.Identity;

namespace web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}