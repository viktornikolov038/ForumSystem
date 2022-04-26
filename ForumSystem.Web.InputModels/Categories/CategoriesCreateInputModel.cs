using ForumSystem.Common;
using ForumSystem.Web.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.InputModels.Categpries
{

    public class CategoriesCreateInputModel
    {
        [Required]
        [StringLength(GlobalConstants.CategoryNameMaxLength, ErrorMessage = ErrorMessages.CategoryNameLengthErrorMessage, MinimumLength = GlobalConstants.CategoryNameMinLength)]
        [EnsureCategoryNameNotExists(ErrorMessage = ErrorMessages.CategoryExistingNameErrorMessage)]
        public string Name { get; set; }
    }
}
