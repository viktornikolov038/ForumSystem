namespace ForumSystem.Web.Areas.Identity.Pages.Account
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    using Data.Models;

    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public LogoutModel(SignInManager<ApplicationUser> signInManager) => this.signInManager = signInManager;

        public async Task<IActionResult> OnGet(string returnUrl = null)
        {
            await this.signInManager.SignOutAsync();

            if (returnUrl != null)
            {
                return this.LocalRedirect(returnUrl);
            }

            return this.RedirectToPage();
        }

        public void OnPost()
        {
        }
    }
}
