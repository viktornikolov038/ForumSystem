using ForumSystem.Web.InputModels.Replies;
using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Web.Components
{
    [ViewComponent(Name = "CreateReply")]
    public class CreateReplyViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int? parentId, int postId)
        {
            var viewModel = new RepliesCreateInputModel
            {
                ParentId = parentId,
                PostId = postId
            };

            return this.View(viewModel);
        }
    }
}
