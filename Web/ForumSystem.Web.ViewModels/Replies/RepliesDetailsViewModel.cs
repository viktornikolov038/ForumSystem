using ForumSystem.Common;
using Ganss.XSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.ViewModels.Replies
{
    public class RepliesDetailsViewModel
    {
        private readonly IHtmlSanitizer sanitizer;

        public RepliesDetailsViewModel()
        {
            this.sanitizer = new HtmlSanitizer();
            this.sanitizer.AllowedTags.Add(GlobalConstants.IFrameTag);
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public string SanitizedDescription
            => this.sanitizer.Sanitize(this.Description);

        public int Likes { get; set; }

        public int Loves { get; set; }

        public int HahaCount { get; set; }

        public int WowCount { get; set; }

        public int SadCount { get; set; }

        public int AngryCount { get; set; }

        public string CreatedOn { get; set; }

        public int PostId { get; set; }

        public string PostAuthorId { get; set; }

        public int? ParentId { get; set; }

        public RepliesAuthorDetailsViewModel Author { get; set; }

        public IEnumerable<RepliesDetailsViewModel> Replies { get; set; }
    }
}
