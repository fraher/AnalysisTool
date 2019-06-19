using AnalysisTool.Models;
using AnalysisTool.Persistence.Repositories;
using AnalysisTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisTool.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAnalysisToolContext _context;

        public UnitOfWork(IAnalysisToolContext context)
        {
            _context = context;
            
            Assessments = new AssessmentRepository(_context);
            AssessmentSessions = new AssessmentSessionRepository(_context);
            PrescribedAssessments = new PrescribedAssessmentRepository(_context);
        }


        
        public IAssessmentRepository Assessments { get; private set; }
        public IAssessmentSessionRepository AssessmentSessions { get; private set; }
        public IPrescribedAssessmentRepository PrescribedAssessments { get; private set; }      


        
    }
}
