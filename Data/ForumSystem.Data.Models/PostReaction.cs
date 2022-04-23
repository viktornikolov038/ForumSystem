using ForumSystem.Data.Common.Models;
using ForumSystem.Data.Models.Enums;
using System;

namespace ForumSystem.Data.Models
{
    public class PostReaction : IAuditInfo
    {
        public int Id { get; set; }

        public ReactionType ReactionType { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

        public string AuthorId { get; set; }

        public ForumUser Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}