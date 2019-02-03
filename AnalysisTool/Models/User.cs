using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisTool.Models
{
    public class User
    {
        private AnalysisToolContext _context { get; set; }

        public User(AnalysisToolContext context)
        {
            _context = context;
        }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int BirthYear { get; set; }        

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();            
        }

        public User Get(int userId)
        {
            return _context.Users.FirstOrDefault(e => e.UserId == userId);
        }
    }


}
