using AnalysisTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AnalysisTool.ViewModels
{
    public class AssessmentViewModel
    {
        public User User { get; set; }
        public List<Assessment> Assessments { get; set; }
        public List<AssessmentStep> AssessmentSteps { get; set; }
        public AssessmentSession AssessmentSession { get; set; }               
    }
}
