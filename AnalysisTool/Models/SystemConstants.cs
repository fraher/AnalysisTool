using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisTool.Models
{
    public static class SystemConstants
    {
        public class Frequency
        {
            public const string Once = "Once";
            public const string Daily = "Daily";
            public const string Weekly = "Weekly";
            public const string Monthly = "Monthly";
            public const string Yearly = "Yearly";            

        }        

        public class UserType
        {
            public const string Administrator = "Administrator";
            public const string Patient = "Patient";
            public const string Provider = "Provider";
        }

        public class Mood
        {
            public const string Happy = "Happy";
            public const string Meh = "Meh";
            public const string Sad = "Sad";
        }

        public class Gender
        {
            public const string Male = "Male";
            public const string Female = "Female";
        }
    }

}
