namespace ForumSystem.Data.Models
{
    using System;

    using Common;
    using ForumSystem.Data.Common.Models;

    public class PostReport : IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}