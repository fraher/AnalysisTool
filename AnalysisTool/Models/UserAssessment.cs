using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisTool.Models
{
    public class UserAssessment
    {
        [Required]
        public int UserAssessmentId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int AssessmentId { get; set; }

        [Required]
        public string Frequency { get; set; }

        [Required]
        public string PrescribingProvider { get; set; }

        [Required]
        public DateTime WindowStartDateTime { get; set; }

        [Required]
        public DateTime WindowEndDateTime { get; set; }

        // References
        public User User { get; set; }
        public Assessment Assessment { get; set; }
    }
}
