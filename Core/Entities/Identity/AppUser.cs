using Microsoft.AspNetCore.Identity;

namespace Core.Identity.Entities
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }

        public Address Address { get; set; }
    }
}