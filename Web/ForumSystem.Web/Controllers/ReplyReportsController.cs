using ForumSystem.Services.Replies;
using ForumSystem.Services.Reports;
using ForumSystem.Web.Infrastructure.Extensions;
using ForumSystem.Web.InputModels.ReplyReports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ForumSystem.Web.Controllers
{

    [Authorize]
    public class ReplyReportsController : Controller
    {
        private readonly IRepliesService repliesService;
        private readonly IReplyReportsService replyReportsService;

        public ReplyReportsController(
            IRepliesService repliesService,
            IReplyReportsService replyReportsService)
        {
            this.repliesService = repliesService;
            this.replyReportsService = replyReportsService;
        }

        public async Task<IActionResult> Create(int id)
        {
            var reply = await this.repliesService.GetByIdAsync<ReplyReportsInputModel>(id);
            if (reply == null)
            {
                return this.NotFound();
            }

            return this.View(reply);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReplyReportsInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.replyReportsService.CreateAsync(input.Description, input.Id, this.User.GetId());

            return this.RedirectToAction("Details", "Replies", new { id = input.Id });
        }
    }
}
