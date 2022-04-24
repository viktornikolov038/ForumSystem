using ForumSystem.Web.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.ViewModels.Tags
{
    public class TagsDetailsViewModel
    {
        public string Search { get; set; }

        public TagsInfoViewModel Tag { get; set; }

        public IEnumerable<PostsListingViewModel> Posts { get; set; }
    }
}
