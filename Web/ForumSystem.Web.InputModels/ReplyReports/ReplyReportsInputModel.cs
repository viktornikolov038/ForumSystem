using ForumSystem.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.InputModels.ReplyReports
{
    public class ReplyReportsInputModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.ReplyReportDescriptionMaxLength, ErrorMessage = ErrorMessages.ReplyReportDescriptionLengthErrorMessage, MinimumLength = GlobalConstants.ReplyReportDescriptionMinLength)]
        public string Description { get; set; }
    }
}
