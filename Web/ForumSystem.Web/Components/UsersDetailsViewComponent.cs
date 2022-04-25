using ForumSystem.Services.Users;
using ForumSystem.Web.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ForumSystem.Web.Components
{
    [ViewComponent(Name = "UsersDetails")]
    public class UsersDetailsViewComponent : ViewComponent
    {
        private readonly IUsersService usersService;

        public UsersDetailsViewComponent(IUsersService usersService)
            => this.usersService = usersService;

        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            var viewModel = new UsersDetailsViewModel
            {
                Id = userId,
                FollowersCount = await this.usersService.GetFollowersCountAsync(userId),
                FollowingCount = await this.usersService.GetFollowingCountAsync(userId)
            };

            return this.View(viewModel);
        }
    }
}
