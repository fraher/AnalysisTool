using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnalysisTool.Controllers
{
    public class AssessmentController : Controller
    {
        // GET: /<controller>/
        public IActionResult Mood()
        {
            return View();
        }


        // GET
        public IActionResult Assessment()
        {
            List<string> questions = new List<string> {
            "../images/stroop test.gif",
            "../images/stroop test blue.gif"};

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
