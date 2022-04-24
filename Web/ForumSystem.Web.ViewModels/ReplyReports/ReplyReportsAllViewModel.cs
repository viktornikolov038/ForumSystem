using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.ViewModels.ReplyReports
{
    public class ReplyReportsAllViewModel
    {
        public IEnumerable<ReplyReportsListingViewModel> ReplyReports { get; set; }
    }
}
