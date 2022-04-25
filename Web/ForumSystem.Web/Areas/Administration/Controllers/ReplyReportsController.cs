using ForumSystem.Services.Reports;
using ForumSystem.Web.ViewModels.ReplyReports;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ForumSystem.Web.Areas.Administration.Controllers
{
    public class ReplyReportsController : AdminController
    {
        private readonly IReplyReportsService replyReportsService;

        public ReplyReportsController(IReplyReportsService replyReportsService)
            => this.replyReportsService = replyReportsService;

        public async Task<IActionResult> All()
        {
            var viewModel = new ReplyReportsAllViewModel
            {
                ReplyReports = await this.replyReportsService.GetAllAsync<ReplyReportsListingViewModel>()
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var postReport = await this.replyReportsService.GetByIdAsync<ReplyReportsDetailsViewModel>(id);
            if (postReport == null)
            {
                return this.NotFound();
            }

            return this.View(postReport);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await this.replyReportsService.DeleteAsync(id);
            if (!deleted)
            {
                return this.NotFound();
            }

            return this.RedirectToAction(nameof(All));
        }
    }
}
