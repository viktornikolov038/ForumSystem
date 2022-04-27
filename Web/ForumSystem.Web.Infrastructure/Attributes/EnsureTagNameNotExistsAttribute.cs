﻿namespace ForumSystem.Web.Infrastructure.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using ForumSystem.Services.Tags;
    using Microsoft.Extensions.DependencyInjection;

    public class EnsureTagNameNotExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var tagsService = validationContext.GetService<ITagsService>();
            var isExisting = tagsService.IsExistingAsync((string) value).GetAwaiter().GetResult();
            if (isExisting)
            {
                return new ValidationResult(this.ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
