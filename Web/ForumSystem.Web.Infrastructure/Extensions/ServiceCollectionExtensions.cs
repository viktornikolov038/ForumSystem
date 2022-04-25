
using CloudinaryDotNet;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ForumNet.Services.Providers.Cloudinary;
using ForumSystem.Data;
using ForumSystem.Data.Models;
using ForumSystem.Services.Categories;
using ForumSystem.Services.Messages;
using ForumSystem.Services.Posts;
using ForumSystem.Services.Providers.Cloudinary;
using ForumSystem.Services.Providers.DateTime;
using ForumSystem.Services.Providers.Email;
using ForumSystem.Services.Reactions;
using ForumSystem.Services.Replies;
using ForumSystem.Services.Reports;
using ForumSystem.Services.Tags;
using ForumSystem.Services.Users;

namespace ForumSystem.Web.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string AntiforgeryHeaderName = "X-CSRF-TOKEN";

        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<ApplicationDbContext>(options => options
                    .UseSqlServer(configuration.GetDefaultConnectionString()));

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddDefaultIdentity<ApplicationUser>(options => options
                    .SetIdentityOptions())
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }

        public static IServiceCollection ConfigureCookiePolicyOptions(this IServiceCollection services)
            => services
                .Configure<CookiePolicyOptions>(options => options
                    .SetCookiePolicyOptions());

        public static IServiceCollection AddResponseCompressionForHttps(this IServiceCollection services)
            => services
                .AddResponseCompressionForHttps(options => options
                    .EnableForHttps = true);

        public static IServiceCollection AddAntiforgeryHeader(this IServiceCollection services)
            => services
                .AddAntiforgeryHeader(options => options
                    .HeaderName = AntiforgeryHeaderName);

        public static IServiceCollection AddFacebookAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddFacebookAuthentication()
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = configuration["Facebook:AppId"];
                    facebookOptions.AppSecret = configuration["Facebook:AppSecret"];
                });

            return services;
        }

        public static IServiceCollection AddGoogleAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddAuthenticationCore()
                .AddGoogleAuthentication(configuration
                });

            return services;
        }

        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddSingleton(configuration)
                .AddSingleton(CloudinaryConfiguration(configuration))
                .AddTransient<ICategoriesService, CategoriesService>()
                .AddTransient<ICloudinaryService, CloudinaryService>()
                .AddTransient<IDateTimeProvider, DateTimeProvider>()
                .AddTransient<IMessagesService, MessagesService>()
                .AddTransient<IPostReactionsService, PostReactionsService>()
                .AddTransient<IPostReportsService, PostReportsService>()
                .AddTransient<IPostsService, PostsService>()
                .AddTransient<IRepliesService, RepliesService>()
                .AddTransient<IReplyReactionsService, ReplyReactionsService>()
                .AddTransient<IReplyReportsService, ReplyReportsService>()
                .AddTransient<ITagsService, TagsService>()
                .AddTransient<IUsersService, UsersService>()
                .AddTransient<IEmailSender>(serviceProvider =>
                    new SendGridEmailSender(configuration["SendGrid:ApiKey"]));

        public static IServiceCollection AddControllersWithAutoAntiforgeryTokenAttribute(this IServiceCollection services)
        {
            services
                .AddControllersWithViews(options => options
                    .Filters
                    .Add<AutoValidateAntiforgeryTokenAttribute>());

            return services;
        }

        private static Cloudinary CloudinaryConfiguration(IConfiguration configuration)
        {
            var cloudinaryCredentials = new Account(
                configuration["Cloudinary:CloudName"],
                configuration["Cloudinary:ApiKey"],
                configuration["Cloudinary:ApiSecret"]);

            return new Cloudinary(cloudinaryCredentials);
        }
    }
}
