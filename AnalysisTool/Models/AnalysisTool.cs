using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AnalysisTool.Models
{

    public class AnalysisToolContext : DbContext
    {
        public AnalysisToolContext(DbContextOptions<AnalysisToolContext> options)
            : base(options)
        { }

        DbSet<User> Users { get; set; }
        DbSet<Assessment> Assessments { get; set; }
        DbSet<AssessmentStep> AssessmentSteps { get; set; }
        DbSet<AssessmentSession> AssessmentSessions { get; set; }
        DbSet<AssessmentSessionStepResult> AssessmentSessionStepResults { get; set; }
        DbSet<UserAssessment> UserAssessments { get; set; }
    }

}
