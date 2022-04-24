using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.ViewModels.Categories
{
    public class CategoriesInfoViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PostsCount { get; set; }
    }
}
