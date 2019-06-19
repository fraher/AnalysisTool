using AnalysisTool.Persistence;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
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

        public AnalysisToolContext(MongoDbSettings settings)
        {
            
            //var databaseName = config.GetValue<string>("DatabaseName");
            //var client = new MongoClient(config.GetConnectionString(databaseName));
            var client = new MongoClient(settings.ConnectionString);            
            
            if(client != null)
            {
                _db = client.GetDatabase(settings.DatabaseName);
            }
            

        }


        public IMongoCollection<User> Usersx
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
