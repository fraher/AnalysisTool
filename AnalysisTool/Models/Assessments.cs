using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisTool.Models
{
    /// <summary>
    /// Each assessment which can be performed
    /// </summary>
    public class Assessment
    {
        [Required]
        public int AssessmentId { get; set; }

        [Required]
        public string AssessmentName { get; set; }

        [Required]
        public string AssessmentVersion { get; set; }

        public List<AssessmentStep> AssessmentSteps { get; set; }
    }

    /// <summary>
    /// The steps which make up each assessment
    /// </summary>
    public class AssessmentStep
    {
        [Required]
        public int AssessmentStepId { get; set; }

        [Required]
        public int AssessmentId { get; set; }

        [Required]
        public string StepName { get; set; }

        [Required]
        public string Instructions { get; set; }

        [Required]
        public string MetaData { get; set; }
        
        [Required]
        public int PossiblePoints { get; set; }

        // Link back to Assessment Table
        public Assessment Assessment { get; set; }
    }


}
