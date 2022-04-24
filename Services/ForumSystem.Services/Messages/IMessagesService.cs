using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Services.Messages
{
    public interface IMessagesService
    {
        Task CreateAsync(string content, string authorId, string receiverId);

        Task<string> GetLastActivityAsync(string currentUserId, string userId);

        Task<string> GetLastMessageAsync(string currentUserId, string userId);

        Task<IEnumerable<TModel>> GetAllWithUserAsync<TModel>(string currentUserId, string userId);

        Task<IEnumerable<TModel>> GetAllAsync<TModel>(string currentUserId);
    }
}
