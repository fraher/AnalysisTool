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
    /// This class defines the assignment of an assessment to a user and its performance
    /// </summary>
    public class PrescribedAssessment
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        [Required]
        public string ProviderUserId { get; set; }

        [Required]
        public string AssessmentId { get; set; }

        [Required]
        public string Frequency { get; set; }

        [Required]
        public DateTime WindowStartDateTime { get; set; }

        [Required]
        public DateTime WindowEndDateTime { get; set; }

        /// <summary>
        /// The calculated dates to be performed based on the Frequency and the Window Start/End dates
        /// </summary>
        public List<List<DateTime>> CalculatedWindows { get; set; }        
                
    }
}
