using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisTool.Models
{
    public class User
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int BirthYear { get; set; }        
    }
}
