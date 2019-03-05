using AnalysisTool.Models;
using AnalysisTool.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisTool.Persistence
{
    public class PrescribedAssessmentRepository : Repository<PrescribedAssessment>, IPrescribedAssessmentRepository
    {
        public PrescribedAssessmentRepository(IAnalysisToolContext context) : base(context.PrescribedAssessments)
        {

        }

        public void Save(string id, object entity)
        {
            var builder = Builders<PrescribedAssessment>.Filter;

            var filter = builder.Eq(x => x.Id, id);

            _context.ReplaceOne(filter, entity as PrescribedAssessment);

        }

        public AnalysisToolContext AnalysisToolContext
        {
            get { return _context as AnalysisToolContext; }
        }
    }

    
}
