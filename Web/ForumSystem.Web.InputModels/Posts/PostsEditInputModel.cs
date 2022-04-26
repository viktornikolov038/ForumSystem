using ForumSystem.Common;
using ForumSystem.Web.Infrastructure.Attributes;
using ForumSystem.Web.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.InputModels.Posts
{
    public class PostsEditInputModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.PostTitleMaxLength, ErrorMessage = ErrorMessages.PostTitleLengthErrorMessage, MinimumLength = GlobalConstants.PostTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PostDescriptionMaxLength)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [EnsureCategoryIdExists(ErrorMessage =ErrorMessages. CategoryNonExistingIdErrorMessage)]
        public int CategoryId { get; set; }

        public string AuthorId { get; set; }

        [EnsureTagIdsExists(ErrorMessage = ErrorMessages.TagNonExistingIdErrorMessage)]
        [Display(Name = GlobalConstants.TagsDisplayName)]
        public IEnumerable<int> TagIds { get; set; }

        public IEnumerable<PostsTagsDetailsViewModel> Tags { get; set; }

        public IEnumerable<PostsCategoryDetailsViewModel> Categories { get; set; }
    }
}
