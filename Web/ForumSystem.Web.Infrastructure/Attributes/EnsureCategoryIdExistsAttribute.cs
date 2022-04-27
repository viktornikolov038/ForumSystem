namespace ForumSystem.Web.Infrastructure.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using ForumSystem.Services.Categories;
    using Microsoft.Extensions.DependencyInjection;

    public class EnsureCategoryIdExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var categoriesService = validationContext.GetService<ICategoriesService>();
            var isExisting = categoriesService.IsExistingAsync((int) value).GetAwaiter().GetResult();
            if (!isExisting)
            {
                return new ValidationResult(this.ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
