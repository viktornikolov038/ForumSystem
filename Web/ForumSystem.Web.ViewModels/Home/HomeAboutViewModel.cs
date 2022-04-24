using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.ViewModels.Home
{
    public class HomeAboutViewModel
    {
        public int PostsCount { get; set; }

        public int UsersCount { get; set; }

        public int ReactionsCount { get; set; }

        public IEnumerable<HomeAdminViewModel> Admins { get; set; }
    }
}
