using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisTool.Models
{
    /// <summary>
    /// Each assessment which can be performed
    /// </summary>
    public class Assessment
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }        
        public string Name { get; set; }        
        public string Version { get; set; }        
        public string Instructions { get; set; }        
        public List<AssessmentStep> Steps { get; set; }        
    }

    /// <summary>
    /// The steps which make up each assessment
    /// </summary>
    public class AssessmentStep
    {                
        public int StepNumber { get; set; }        
        public string Name { get; set; }
        [BsonIgnoreIfNull]
        public string InformativeText { get; set; }
        public int PossiblePoints { get; set; }                       
        public DisplayParams DisplayParams { get; set; }
        public ResponseParams ResponseParams { get; set; }
    }

    /// <summary>
    /// This provides information on how the assessment step will be displayed to the user
    /// </summary>
    public class DisplayParams
    {
        public string DisplayType { get; set; }
        [BsonIgnoreIfNull]
        public string Content { get; set; }
        [BsonIgnoreIfNull]
        public string Css { get; set; }
    }

    /// <summary>
    /// This provides the information on how the user will respond to the assessment step
    /// </summary>
    public class ResponseParams
    {                
        public string ResponseType { get; set; }                           
    }

    

    
    
}
