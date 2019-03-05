using AnalysisTool.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisTool.Services
{
    public interface IAssessmentRepository : IRepository<Assessment>
    {
        void Save(string id, object entity);
    }
}
