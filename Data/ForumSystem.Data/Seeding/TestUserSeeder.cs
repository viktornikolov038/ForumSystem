namespace ForumSystem.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSystem.Common;
    using ForumSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    internal class TestUserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var isExisting = await userManager.Users.AnyAsync(u => u.UserName == GlobalConstants.TestUserUserName);
            if (!isExisting)
            {
                var testUser = new ApplicationUser
                {
                    UserName = GlobalConstants.TestUserUserName,
                    Email = GlobalConstants.TestUserEmail,
                    ProfilePicture = GlobalConstants.TestUserProfilePicture,
                    EmailConfirmed = true,
                };

                var result = await userManager.CreateAsync(testUser, GlobalConstants.TestUserPassword);
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
