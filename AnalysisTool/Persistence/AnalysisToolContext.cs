using AnalysisTool.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisTool.Models
{
    public class AnalysisToolContext : IAnalysisToolContext
    {



        private readonly IMongoDatabase _db;

        public AnalysisToolContext(IOptions<Settings> settings)
        {

            //var databaseName = config.GetValue<string>("DatabaseName");
            //var client = new MongoClient(config.GetConnectionString(databaseName));
            var client = new MongoClient(settings.Value.ConnectionString);

            if(client != null)
            {
                _db = client.GetDatabase(settings.Value.Database);
            }
            

        }


        public IMongoCollection<User> Users
        {
            get
            {
                return _db.GetCollection<User>("Users");
            }
        }

        public IMongoCollection<Assessment> Assessments
        {
            get
            {
                return _db.GetCollection<Assessment>("Assessments");
            }
        }

        public IMongoCollection<PrescribedAssessment> PrescribedAssessments
        {
            get
            {
                return _db.GetCollection<PrescribedAssessment>("PrescribedAssessments");
            }
            
            }

        public IMongoCollection<AssessmentSession> AssessmentSessions
        {
            get
            {
                return _db.GetCollection<AssessmentSession>("AssessmentSessions");
            }
        }


    }
}
