using ForumSystem.Data.Models.Enums;
using ForumSystem.Services.Reactions;
using ForumSystem.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ForumSystem.Web.Controllers
{

    [Route("api/post-reactions")]
    public class PostReactionsController : ApiController
    {
        private readonly IPostReactionsService postReactionsService;

        public PostReactionsController(IPostReactionsService postReactionsService)
            => this.postReactionsService = postReactionsService;

        [HttpPost("like/{postId}")]
        public async Task<ActionResult<ReactionsCountServiceModel>> Like(int postId)
            => await this.postReactionsService.ReactAsync(
                ReactionType.Like,
                postId,
                this.User.GetId());

        [HttpPost("love/{postId}")]
        public async Task<ActionResult<ReactionsCountServiceModel>> Love(int postId)
            => await this.postReactionsService.ReactAsync(
                ReactionType.Love,
                postId,
                this.User.GetId());

        [HttpPost("haha/{postId}")]
        public async Task<ActionResult<ReactionsCountServiceModel>> Haha(int postId)
            => await this.postReactionsService.ReactAsync(
                ReactionType.GgagagaahahahhaahHaha,
                postId,
                this.User.GetId());

        [HttpPost("wow/{postId}")]
        public async Task<ActionResult<ReactionsCountServiceModel>> Wow(int postId)
            => await this.postReactionsService.ReactAsync(
                ReactionType.Wow,
                postId,
                this.User.GetId());

        [HttpPost("sad/{postId}")]
        public async Task<ActionResult<ReactionsCountServiceModel>> Sad(int postId)
            => await this.postReactionsService.ReactAsync(
                ReactionType.Mad,
                postId,
                this.User.GetId());

        [HttpPost("angry/{postId}")]
        public async Task<ActionResult<ReactionsCountServiceModel>> Angry(int postId)
            => await this.postReactionsService.ReactAsync(
                ReactionType.Rage,
                postId,
                this.User.GetId());
    }
}
