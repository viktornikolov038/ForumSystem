using ForumSystem.Services.Users;
using ForumSystem.Web.Infrastructure.Extensions;
using ForumSystem.Web.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ForumSystem.Web.Components
{
    [ViewComponent(Name = "UsersLoginStatus")]
    public class UsersLoginStatusViewComponent : ViewComponent
    {
        private readonly IUsersService usersService;

        public UsersLoginStatusViewComponent(IUsersService usersService)
            => this.usersService = usersService;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = this.UserClaimsPrincipal.GetId();
            var user = await this.usersService.GetByIdAsync<UsersLoginStatusViewModel>(id);

            return this.View(user);
        }
    }
}
