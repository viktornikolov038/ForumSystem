﻿namespace ForumSystem.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    public class PostsListingViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Likes { get; set; }

        public int RepliesCount { get; set; }

        public int Views { get; set; }

        public string Activity { get; set; }

        public bool IsPinned { get; set; }

        public string AuthorId { get; set; }

        public string AuthorProfilePicture { get; set; }

        public PostsCategoryDetailsViewModel Category { get; set; }

        public IEnumerable<PostsTagsDetailsViewModel> Tags { get; set; }
    }
}
