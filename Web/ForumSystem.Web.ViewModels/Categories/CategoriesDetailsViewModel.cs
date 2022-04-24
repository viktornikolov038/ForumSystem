using ForumSystem.Web.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.ViewModels.Categories
{
    public class CategoriesDetailsViewModel
    {
        public string Search { get; set; }

        public CategoriesInfoViewModel Category { get; set; }

        public IEnumerable<PostsListingViewModel> Posts { get; set; }
    }
}
