﻿namespace ForumSystem.Web.InputModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using Infrastructure.Attributes;

    using static Common.ErrorMessages;
    using static Common.GlobalConstants;

    public class CategoriesEditInputModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryNameMaxLength, ErrorMessage = CategoryNameLengthErrorMessage, MinimumLength = CategoryNameMinLength)]
        [EnsureCategoryNameNotExists(ErrorMessage = CategoryExistingNameErrorMessage)]
        public string Name { get; set; }
    }
}