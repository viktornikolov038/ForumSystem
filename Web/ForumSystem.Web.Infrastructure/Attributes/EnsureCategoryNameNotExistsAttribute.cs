namespace ForumSystem.Web.Infrastructure.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using ForumSystem.Services.Categories;
    using Microsoft.Extensions.DependencyInjection;

    public class EnsureCategoryNameNotExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var categoryService = validationContext.GetService<ICategoriesService>();
            var isExisting = categoryService.IsExistingAsync((string) value).GetAwaiter().GetResult();
            if (isExisting)
            {
                return new ValidationResult(this.ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}