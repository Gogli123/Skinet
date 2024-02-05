using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Sandro",
                    Email = "Sandro@test.com",
                    UserName = "Sandro@test.com",
                    Address = new Address
                    {
                        FirstName = "Sandro",
                        LastName = "Goglidze",
                        Street = "dighomi",
                        City = "Tbilisi",
                        State = "Tbilisi",
                        ZipCode = "0112",
                    }
                };

                await userManager.CreateAsync(user, "Tataxuri787!@#");
            }
        }
    }
}