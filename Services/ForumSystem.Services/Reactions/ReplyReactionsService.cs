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
    public class ReplyReactionsService : IReplyReactionsService
    {
        private readonly ApplicationDbContext db;
        private readonly IDateTimeProvider dateTimeProvider;

        public ReplyReactionsService(ApplicationDbContext db, IDateTimeProvider dateTimeProvider)
        {
            this.db = db;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task<ReactionsCountServiceModel> ReactAsync(ReactionType reactionType, int replyId, string authorId)
        {
            var replyReaction = await this.db.ReplyReactions
                .FirstOrDefaultAsync(rr => rr.ReplyId == replyId && rr.AuthorId == authorId);

            if (replyReaction == null)
            {
                replyReaction = new ReplyReaction
                {
                    ReactionType = reactionType,
                    ReplyId = replyId,
                    AuthorId = authorId,
                    CreatedOn = this.dateTimeProvider.Now()
                };

                await this.db.ReplyReactions.AddAsync(replyReaction);
            }
            else
            {
                replyReaction.ModifiedOn = this.dateTimeProvider.Now();
                replyReaction.ReactionType = replyReaction.ReactionType == reactionType
                    ? ReactionType.Neutral
                    : reactionType;
            }

            await this.db.SaveChangesAsync();

            return await this.GetCountByReplyIdAsync(replyId);
        }

        public async Task<int> GetTotalCountAsync()
            => await this.db.ReplyReactions
                .Where(pr => !pr.Reply.IsDeleted)
                .CountAsync();

        private async Task<ReactionsCountServiceModel> GetCountByReplyIdAsync(int replyId)
            => new ReactionsCountServiceModel
            {
                Likes = await this.GetCountByTypeAndReplyIdAsync(ReactionType.Like, replyId),
                Loves = await this.GetCountByTypeAndReplyIdAsync(ReactionType.Love, replyId),
                HahaCount = await this.GetCountByTypeAndReplyIdAsync(ReactionType.GgagagaahahahhaahHaha, replyId),
                WowCount = await this.GetCountByTypeAndReplyIdAsync(ReactionType.Wow, replyId),
                SadCount = await this.GetCountByTypeAndReplyIdAsync(ReactionType.Mad, replyId),
                AngryCount = await this.GetCountByTypeAndReplyIdAsync(ReactionType.Rage, replyId)
            };

        private async Task<int> GetCountByTypeAndReplyIdAsync(ReactionType reactionType, int replyId)
            => await this.db.ReplyReactions
                .Where(pr => !pr.Reply.IsDeleted && pr.ReplyId == replyId)
                .CountAsync(pr => pr.ReactionType == reactionType);
    }
}
