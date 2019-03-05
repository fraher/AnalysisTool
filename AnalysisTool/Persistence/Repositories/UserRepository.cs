using AnalysisTool.Models;
using AnalysisTool.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AnalysisTool.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IAnalysisToolContext context) : base(context.Users)
        {

        }

        public void Save(string id, object entity)
        {
            var builder = Builders<User>.Filter;

            var filter = builder.Eq(x => x.Id, id);            

            _context.ReplaceOne(filter, entity as User);
            
        }
        

        public AnalysisToolContext AnalysisToolContext
        {
            get { return _context as AnalysisToolContext;  }
        }
    }
}
