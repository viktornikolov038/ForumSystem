﻿namespace ForumSystem.Data.Models
{
    using System;

    using Common;
    using Enums;
    using ForumSystem.Data.Common.Models;

    public class PostReaction : IAuditInfo
    {
        public int Id { get; set; }

        public ReactionType ReactionType { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}