using ForumSystem.Data.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ForumSystem.Services.Reactions
{
    public interface IReplyReactionsService
    {
        Task<ReactionsCountServiceModel> ReactAsync(ReactionType reactionType, int replyId, string authorId);

        Task<int> GetTotalCountAsync();
    }
}
