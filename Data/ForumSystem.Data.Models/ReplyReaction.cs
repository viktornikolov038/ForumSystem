﻿namespace ForumSystem.Data.Models
{
    using System;

    using Common;
    using Enums;
    using ForumSystem.Data.Common.Models;

    public class ReplyReaction : IAuditInfo
    {
        public int Id { get; set; }

        public ReactionType ReactionType { get; set; }

        public int ReplyId { get; set; }

        public Reply Reply { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}