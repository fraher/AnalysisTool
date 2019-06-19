using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnalysisTool.ViewModels
{
    public class DisplayRecoveryCodesViewModel
    {
        [Required]
        public IEnumerable<string> Codes { get; set; }

    }
}
