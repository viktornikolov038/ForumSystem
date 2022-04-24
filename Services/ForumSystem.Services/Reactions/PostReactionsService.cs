using ForumSystem.Data;
using ForumSystem.Data.Models;
using ForumSystem.Data.Models.Enums;
using ForumSystem.Services.Providers.DateTime;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Services.Reactions
{
    public class PostReactionsService : IPostReactionsService
    {
        private readonly ApplicationDbContext db;
        private readonly IDateTimeProvider dateTimeProvider;

        public PostReactionsService(ApplicationDbContext db, IDateTimeProvider dateTimeProvider)
        {
            this.db = db;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task<ReactionsCountServiceModel> ReactAsync(ReactionType reactionType, int postId, string authorId)
        {
            var postReaction = await this.db.PostReactions
                .FirstOrDefaultAsync(pr => pr.PostId == postId && pr.AuthorId == authorId);

            if (postReaction == null)
            {
                postReaction = new PostReaction
                {
                    ReactionType = reactionType,
                    PostId = postId,
                    AuthorId = authorId,
                    CreatedOn = this.dateTimeProvider.Now()
                };

                await this.db.PostReactions.AddAsync(postReaction);
            }
            else
            {
                postReaction.ModifiedOn = this.dateTimeProvider.Now();
                postReaction.ReactionType = postReaction.ReactionType == reactionType
                    ? ReactionType.Neutral
                    : reactionType;
            }

            await this.db.SaveChangesAsync();

            return await this.GetCountByPostIdAsync(postId);
        }

        public async Task<int> GetTotalCountAsync()
            => await this.db.PostReactions
                .Where(pr => !pr.Post.IsDeleted)
                .CountAsync();

        private async Task<ReactionsCountServiceModel> GetCountByPostIdAsync(int postId)
            => new ReactionsCountServiceModel
            {
                Likes = await this.GetCountByTypeAndPostIdAsync(ReactionType.Like, postId),
                Loves = await this.GetCountByTypeAndPostIdAsync(ReactionType.Love, postId),
                HahaCount = await this.GetCountByTypeAndPostIdAsync(ReactionType.GgagagaahahahhaahHaha, postId),
                WowCount = await this.GetCountByTypeAndPostIdAsync(ReactionType.Wow, postId),
                SadCount = await this.GetCountByTypeAndPostIdAsync(ReactionType.Mad, postId),
                AngryCount = await this.GetCountByTypeAndPostIdAsync(ReactionType.Rage, postId)
            };

        private async Task<int> GetCountByTypeAndPostIdAsync(ReactionType reactionType, int postId)
            => await this.db.PostReactions
                .Where(pr => !pr.Post.IsDeleted && pr.PostId == postId)
                .CountAsync(pr => pr.ReactionType == reactionType);
    }
}
