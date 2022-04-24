using ForumSystem.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Services.Reactions
{
    public interface IPostReactionsService
    {
        Task<ReactionsCountServiceModel> ReactAsync(ReactionType reactionType, int postId, string authorId);

        Task<int> GetTotalCountAsync();
    }
}
