using System.Linq;
using System.Threading.Tasks;
using Core.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any()){
                var user = new AppUser{

                    DisplayName = "Dan",
                    Email = "dan@dan.com",
                    UserName = "dan@dan.com",
                    Address = new Address{
                        FirstName = "Dan",
                        LastName = "White",
                        Street = "1 Street View",
                        City = "Somewhere",
                        State = "Anywhere",
                        PostCode = "abc"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}