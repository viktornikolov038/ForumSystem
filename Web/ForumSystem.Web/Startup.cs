﻿namespace ForumSystem.Web
{
    using AutoMapper;
    using ForumSystem.Web.Hubs;
    using ForumSystem.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration) => this.configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            _ = services
                .AddDatabase(this.configuration)
                .AddIdentity()
                .ConfigureCookiePolicyOptions()
                .AddResponseCompressionForHttps()
                .AddAntiforgeryHeader()
                .AddFacebookAuthentication(this.configuration)
                .AddGoogleAuthentication(this.configuration)
                .AddAutoMapper(typeof(ForumProfile).Assembly)
                .AddApplicationServices(this.configuration)
                .AddControllersWithAutoAntiforgeryTokenAttribute()
                .AddRazorPages();

            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage()
                    .UseDatabaseErrorPage();
            }
            else
            {
                app
                    .UseExceptionHandler("/Home/Error")
                    .UseHsts();
            }

            app
                .ApplyMigrations()
                .SeedData()
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseCookiePolicy()
                .UseStatusCodePagesWithRedirects("/Home/NotFound{0}")
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "areaRoute",
                        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Posts}/{action=Trending}/{id?}");

                    endpoints.MapHub<ChatHub>("/chat");
                    endpoints.MapRazorPages();
                });
        }
    }
}
