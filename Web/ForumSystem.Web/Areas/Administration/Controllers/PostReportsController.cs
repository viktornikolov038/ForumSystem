using ForumSystem.Services.Reports;
using ForumSystem.Web.ViewModels.PostReports;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ForumSystem.Web.Areas.Administration.Controllers
{
    public class PostReportsController : AdminController
    {
        private readonly IPostReportsService postReportsService;

        public PostReportsController(IPostReportsService postReportsService)
            => this.postReportsService = postReportsService;

        public async Task<IActionResult> All()
        {
            var viewModel = new PostReportAllViewModel
            {
                PostReports = await this.postReportsService.GetAllAsync<PostReportsListingViewModel>()
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var postReport = await this.postReportsService.GetByIdAsync<PostReportsDetailsViewModel>(id);
            if (postReport == null)
            {
                return this.NotFound();
            }

            return this.View(postReport);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await this.postReportsService.DeleteAsync(id);
            if (!deleted)
            {
                return this.NotFound();
            }

            return this.RedirectToAction(nameof(All));
        }
    }
}
