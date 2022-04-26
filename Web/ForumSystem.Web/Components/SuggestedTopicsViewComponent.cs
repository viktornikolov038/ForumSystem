﻿using ForumSystem.Services.Posts;
using ForumSystem.Services.Tags;
using ForumSystem.Web.ViewModels.Posts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ForumSystem.Web.Components
{

    [ViewComponent(Name = "SuggestedTopics")]
    public class SuggestedTopicsViewComponent : ViewComponent
    {
        private const int PostsToTake = 5;

        private readonly IPostsService postsService;
        private readonly ITagsService tagsService;

        public SuggestedTopicsViewComponent(IPostsService postsService, ITagsService tagsService)
        {
            this.postsService = postsService;
            this.tagsService = tagsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var suggestedPosts = await this.postsService.GetSuggestedAsync<PostsListingViewModel>(PostsToTake);
            var viewModel = new PostsAllViewModel
            {
                Posts = suggestedPosts
            };

            foreach (var post in viewModel.Posts)
            {
                post.Activity = await this.postsService.GetLatestActivityByIdAsync(post.Id);
                post.Tags = await this.tagsService.GetAllByPostIdAsync<PostsTagsDetailsViewModel>(post.Id);
            }

            return this.View(viewModel);
        }
    }
}
