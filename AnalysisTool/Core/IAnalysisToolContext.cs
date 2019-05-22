using AnalysisTool.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisTool.Persistence
{
    public interface IAnalysisToolContext
    {
        IMongoCollection<User> Usersx { get; }
        IMongoCollection<Assessment> Assessments { get; }
        IMongoCollection<PrescribedAssessment> PrescribedAssessments { get; }
        IMongoCollection<AssessmentSession> AssessmentSessions { get; }
    }
}
