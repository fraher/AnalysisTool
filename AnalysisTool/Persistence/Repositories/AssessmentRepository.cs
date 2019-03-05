using AnalysisTool.Models;
using AnalysisTool.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisTool.Persistence.Repositories
{
    public class AssessmentRepository : Repository<Assessment>, IAssessmentRepository
    {
        public AssessmentRepository(IAnalysisToolContext context) : base(context.Assessments)
        {

        }        

        public void Save(string id, object entity)
        {
            var builder = Builders<Assessment>.Filter;

            var filter = builder.Eq(x => x.Id, id);

            _context.ReplaceOne(filter, entity as Assessment);

        }

        public AnalysisToolContext AnalysisToolContext
        {
            get { return _context as AnalysisToolContext; }
        }

    }
}
