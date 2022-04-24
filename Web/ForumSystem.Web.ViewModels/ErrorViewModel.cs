using ForumSystem.Web.Infrastructure.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Web.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
    
}
