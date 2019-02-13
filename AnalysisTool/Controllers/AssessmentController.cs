using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalysisTool.Models;
using AnalysisTool.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnalysisTool.Controllers
{
    public class AssessmentController : Controller
    {
        private AnalysisToolContext _context { get; set; }

        public AssessmentController(AnalysisToolContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Mood()
        {
            return View();
        }


        // GET
        public IActionResult Assessment()
        {

            var model = new AssessmentViewModel();


            model.Assessment = _context.Assessments.FirstOrDefault(x => x.AssessmentId == 1);
            model.AssessmentSteps = _context.AssessmentSteps.Where(x => x.AssessmentId == 1).ToList();
            

            List<string> questions = new List<string> {
            "../images/stroop test.gif", model.AssessmentSteps[0].MetaData, model.AssessmentSteps[1].MetaData, model.AssessmentSteps[2].MetaData, "../images/coris_blocks.gif"};

            return View(questions);
        }

        public PartialViewResult _Template(List<string> assessments)
        {  //Gets the requested parameter and returns the view page

            return PartialView(assessments);
        }

        public IActionResult Completed()
        {
            bool moreAssessments = true;

            return View(moreAssessments);
        }
    }
}
