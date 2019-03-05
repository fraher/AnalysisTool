using AnalysisTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisTool.Persistence
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IAssessmentRepository Assessments { get; }
        IPrescribedAssessmentRepository PrescribedAssessments { get; }
        IAssessmentSessionRepository AssessmentSessions { get; }
               
    }
}
