using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisTool.Models
{
    public class AssessmentSession
    {
        [Required]
        public int AssessmentSessionId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int MoodRating { get; set; }
        
        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        List<AssessmentSessionStepResult> AssessmentSessionStepResult { get; set; }

        // Reference to link User Table
        public User User { get; set; }
    }

    public class AssessmentSessionStepResult
    {
        [Required]
        public int AssessmentSessionStepResultId { get; set; }

        [Required]
        public int AssessmentSessionId { get; set; }

        [Required]
        public int AssessmentStepId { get; set; }

        [Required]
        public int AssessmentOrder { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }

        [Required]
        public int Points { get; set; }

        // References
        public AssessmentSession AssessmentSession { get; set; }
        public AssessmentStep AssessmentStep { get; set; }

    }
}
