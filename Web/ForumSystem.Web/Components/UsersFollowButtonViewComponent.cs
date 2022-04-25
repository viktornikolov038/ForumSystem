using ForumSystem.Services.Users;
using ForumSystem.Web.Infrastructure.Extensions;
using ForumSystem.Web.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ForumSystem.Web.Components
{
    [ViewComponent(Name = "UsersFollowButton")]
    public class UsersFollowButtonViewComponent : ViewComponent
    {
        private readonly IUsersService usersService;

        public UsersFollowButtonViewComponent(IUsersService usersService)
            => this.usersService = usersService;

        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            var followerId = this.UserClaimsPrincipal.GetId();
            var viewModel = new UsersDetailsViewModel
            {
                Id = userId,
                IsFollowed = await this.usersService.IsFollowedAlreadyAsync(userId, followerId)
            };

            return this.View(viewModel);
        }
    }
}
