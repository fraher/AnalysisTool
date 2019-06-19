﻿using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static AnalysisTool.Models.SystemConstants;

namespace AnalysisTool.Models
{
    [CollectionName("Users")]
    public class User : MongoIdentityUser<Guid>
    {
        

        //[BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        //public string Id { get; set; } = null;
        //public string UserName { get; set; }
        public string TypeOfUser { get; set; }
        public bool Active { get; set; } = true;

        // User Specific Items
        [BsonIgnoreIfNull]
        public string PatientGender { get; set; }
        [BsonIgnoreIfNull]
        public int BirthYear { get; set; }        

        // Provider Specific Items
        [BsonIgnoreIfNull]
        public string ProviderName { get; set; }
        [BsonIgnoreIfNull]
        public string Institution { get; set; }

        public User() : base()
        {

        }

        public User(string userName) : base(userName)
        {

        }
    }


}
