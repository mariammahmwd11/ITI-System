using Microsoft.AspNetCore.Identity;

namespace ITI_System.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
