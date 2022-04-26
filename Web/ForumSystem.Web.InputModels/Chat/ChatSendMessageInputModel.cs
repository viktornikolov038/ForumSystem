using ForumSystem.Common;
using ForumSystem.Web.ViewModels.Chat;
using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Web.InputModels.Chat
{
    public class ChatSendMessageInputModel
    {
        [Required]
        [MaxLength(GlobalConstants.MessageContentMaxLength)]
        public string Message { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        public IEnumerable<ChatUserViewModel> Users { get; set; }
    }
}
