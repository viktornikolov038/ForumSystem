using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.ViewModels.Users
{
    public class UsersFollowersViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string ProfilePicture { get; set; }

        public string ThreadsCount { get; set; }

        public string RepliesCount { get; set; }

        public int Points { get; set; }
    }
}
