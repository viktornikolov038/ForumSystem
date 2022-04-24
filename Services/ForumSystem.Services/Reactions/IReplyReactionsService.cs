using ForumSystem.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Services.Reactions
{
    public interface IReplyReactionsService
    {
        Task<ReactionsCountServiceModel> ReactAsync(ReactionType reactionType, int replyId, string authorId);

        Task<int> GetTotalCountAsync();
    }
}
