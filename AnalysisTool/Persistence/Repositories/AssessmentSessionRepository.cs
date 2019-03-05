using AnalysisTool.Models;
using AnalysisTool.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisTool.Persistence.Repositories
{
    public class AssessmentSessionRepository : Repository<AssessmentSession>, IAssessmentSessionRepository
    {
        public AssessmentSessionRepository(IAnalysisToolContext context) : base(context.AssessmentSessions)
        {

        }


        public void Save(string id, object entity)
        {
            var builder = Builders<AssessmentSession>.Filter;

            var filter = builder.Eq(x => x.Id, id);

            _context.ReplaceOne(filter, entity as AssessmentSession);

        }

        public AnalysisToolContext AnalysisToolContext
        {
            get { return _context as AnalysisToolContext; }
        }
    }
}
