using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.ViewModels.PostReports
{
    public class PostReportAllViewModel
    {
        public IEnumerable<PostReportsListingViewModel> PostReports { get; set; }
    }
}
