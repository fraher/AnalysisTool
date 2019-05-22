using AnalysisTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisTool.Persistence
{
    public interface IUnitOfWork
    {
        
        IAssessmentRepository Assessments { get; }
        IPrescribedAssessmentRepository PrescribedAssessments { get; }
        IAssessmentSessionRepository AssessmentSessions { get; }
               
    }
}
