using ForumSystem.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.InputModels.Replies
{
    public class RepliesEditInputModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ReplyDescriptionMaxLength)]
        public string Description { get; set; }

        public string AuthorId { get; set; }
    }
}
