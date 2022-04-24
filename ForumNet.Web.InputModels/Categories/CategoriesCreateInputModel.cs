using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumNet.Web.InputModels.Categories
{
    public class CategoriesCreateInputModel
    {
        [Required]
        [StringLength(CategoryNameMaxLength, ErrorMessage = CategoryNameLengthErrorMessage, MinimumLength = CategoryNameMinLength)]
        [EnsureCategoryNameNotExists(ErrorMessage = CategoryExistingNameErrorMessage)]
        public string Name { get; set; }
    }
}
