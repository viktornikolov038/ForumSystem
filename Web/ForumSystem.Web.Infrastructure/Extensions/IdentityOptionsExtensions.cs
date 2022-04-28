namespace ForumSystem.Web.Infrastructure.Extensions
{
    using ForumSystem.Common;
    using Microsoft.AspNetCore.Identity;

    public static class IdentityOptionsExtensions
    {
        public static IdentityOptions SetIdentityOptions(this IdentityOptions options)
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = GlobalConstants.UserPasswordMinLength;
            options.User.RequireUniqueEmail = true;

            return options;
        }
    }
}
