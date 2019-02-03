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

        public DbSet<User> Users { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<AssessmentStep> AssessmentSteps { get; set; }
        public DbSet<AssessmentSession> AssessmentSessions { get; set; }
        public DbSet<AssessmentSessionStepResult> AssessmentSessionStepResults { get; set; }
        public DbSet<UserAssessment> UserAssessments { get; set; }
    }

}
