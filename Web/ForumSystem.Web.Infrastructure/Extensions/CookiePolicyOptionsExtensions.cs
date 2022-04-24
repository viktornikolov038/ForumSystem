using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.Infrastructure.Extensions
{
    public static class CookiePolicyOptionsExtensions
    {
        public static CookiePolicyOptions SetCookiePolicyOptions(this CookiePolicyOptions options)
        {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;

            return options;
        }
    }
}
