namespace ForumSystem.Web.Infrastructure.Extensions
{
    using CloudinaryDotNet;
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
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

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
                .AddResponseCompression(options => options
                    .EnableForHttps = true);

        public static IServiceCollection AddAntiforgeryHeader(this IServiceCollection services)
            => services
                .AddAntiforgery(options => options
                    .HeaderName = AntiforgeryHeaderName);

        public static IServiceCollection AddFacebookAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddAuthentication()
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = "Facebook:AppId";
                    facebookOptions.AppSecret ="Facebook:AppSecret";
                });

            return services;
        }

        public static IServiceCollection AddGoogleAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddAuthentication()
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = "Google:ClientId";
                    googleOptions.ClientSecret = "Google:ClientSecret";
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
                    new SendGridEmailSender("SendGrid:ApiKey"));

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
                "Cloudinary:CloudName",
                "Cloudinary:ApiKey",
                "Cloudinary:ApiSecret");

            return new Cloudinary(cloudinaryCredentials);
        }
    }
}
