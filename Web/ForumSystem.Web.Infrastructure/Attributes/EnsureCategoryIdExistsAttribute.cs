using ForumSystem.Services.Categories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.Infrastructure.Attributes
{
    public class EnsureCategoryIdExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var categoriesService = validationContext.GetService<ICategoriesService>();
            var isExisting = categoriesService.IsExistingAsync((int)value).GetAwaiter().GetResult();
            if (!isExisting)
            {
                return new ValidationResult(this.ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
