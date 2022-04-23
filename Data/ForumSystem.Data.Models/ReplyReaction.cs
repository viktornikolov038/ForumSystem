namespace ForumSystem.Data.Models
{
    using System;

    using ForumSystem.Data.Common.Models;
    using ForumSystem.Data.Models.Enums;

    public class ReplyReaction : IAuditInfo
    {
        public int Id { get; set; }

        public ReactionType ReactionType { get; set; }

        public int ReplyId { get; set; }

        public Reply Reply { get; set; }

        public string AuthorId { get; set; }

        public ForumUser Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}