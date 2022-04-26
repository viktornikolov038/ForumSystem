using ForumSystem.Common;
using ForumSystem.Web.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.InputModels.Tags
{
    public class TagsCreateInputModel
    {
        [Required]
        [StringLength(GlobalConstants.TagNameMaxLength, ErrorMessage = ErrorMessages.TagNameLengthErrorMessage, MinimumLength = GlobalConstants.TagNameMinLength)]
        [EnsureTagNameNotExists(ErrorMessage = ErrorMessages.TagExistingNameErrorMessage)]
        public string Name { get; set; }
    }
}
