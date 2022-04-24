using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.ViewModels.Categories
{
    public class CategoriesAllViewModel
    {
        public string Search { get; set; }

        public IEnumerable<CategoriesInfoViewModel> Categories { get; set; }
    }
}
