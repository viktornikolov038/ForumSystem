using ForumSystem.Services.Posts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ForumSystem.Web.Areas.Administration.Controllers
{
    public class PostsController : AdminController
    {
        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService) => this.postsService = postsService;

        [HttpPost]
        public async Task<IActionResult> Pin(int id)
        {
            var isExisting = await postsService.IsExistingAsync(id);
            if (!isExisting)
            {
                return this.NotFound();
            }

            var isPinned = await this.postsService.PinAsync(id);

            return this.Ok(isPinned);
        }
    }
}
