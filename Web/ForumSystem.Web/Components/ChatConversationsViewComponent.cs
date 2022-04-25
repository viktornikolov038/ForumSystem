using ForumSystem.Services.Messages;
using ForumSystem.Web.Infrastructure.Extensions;
using ForumSystem.Web.ViewModels.Chat;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ForumSystem.Web.Components
{
    [ViewComponent(Name = "ChatConversations")]
    public class ChatConversationsViewComponent : ViewComponent
    {
        private readonly IMessagesService messagesService;

        public ChatConversationsViewComponent(IMessagesService messagesService)
            => this.messagesService = messagesService;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUserId = this.UserClaimsPrincipal.GetId();
            var conversations = await this.messagesService.GetAllAsync<ChatConversationsViewModel>(currentUserId);

            foreach (var user in conversations)
            {
                user.LastMessage = await this.messagesService.GetLastMessageAsync(currentUserId, user.Id);
                user.LastMessageActivity = await this.messagesService.GetLastActivityAsync(currentUserId, user.Id);
            }

            return this.View(conversations);
        }
    }
}
