using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.ViewModels.Users
{
    public class UsersThreadsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Likes { get; set; }

        public int RepliesCount { get; set; }

        public int Views { get; set; }

        public string Activity { get; set; }

        public bool IsPinned { get; set; }

        public UsersThreadsCategoryViewModel Category { get; set; }

        public IEnumerable<UsersThreadsTagsViewModel> Tags { get; set; }
    }
}
