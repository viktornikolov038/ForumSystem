using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.ViewModels.Chat
{
    public class ChatConversationsViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string ProfilePicture { get; set; }

        public string LastMessage { get; set; }

        public string LastMessageActivity { get; set; }
    }
}
