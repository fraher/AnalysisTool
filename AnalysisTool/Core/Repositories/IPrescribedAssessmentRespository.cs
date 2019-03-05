using AnalysisTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisTool.Services
{
    public interface IPrescribedAssessmentRepository : IRepository<PrescribedAssessment>
    {
        void Save(string id, object entity);
    }
}
