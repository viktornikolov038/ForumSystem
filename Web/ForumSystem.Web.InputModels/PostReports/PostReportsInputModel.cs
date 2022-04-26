using ForumSystem.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Web.InputModels.PostReports
{
    public class PostReportsInputModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.PostReportDescriptionMaxLength, ErrorMessage = ErrorMessages.PostReportDescriptionLengthErrorMessage, MinimumLength = GlobalConstants.PostReportDescriptionMinLength)]
        public string Description { get; set; }
    }
}
