using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AnalysisTool.Models
{

    public class AnalysisToolContext : DbContext
    {
        public AnalysisToolContext(DbContextOptions<AnalysisToolContext> options)
            : base(options)
        { }

        
    }

}
