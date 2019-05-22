using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalysisTool.Models;
using AnalysisTool.Persistence;
using AnalysisTool.Services;
using AnalysisTool.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnalysisTool.Controllers
{
    public class AssessmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private AssessmentViewModel _model;

        public AssessmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _model = new AssessmentViewModel();
        }

        // GET: /<controller>/
        public IActionResult Mood()
        {
            return View();
        }


        // GET
        public IActionResult Assessment()
        {
            _model.Assessment = _unitOfWork.Assessments.SingleOrDefault(x => x.Name == "Mock Stroop Test");
            
            return View(_model);
        }

        public PartialViewResult _Template(AssessmentViewModel assessmentVM)
        {  //Gets the requested parameter and returns the view page

            return PartialView(assessmentVM);
        }

        public IActionResult Completed()
        {
            bool moreAssessments = true;

            return View(moreAssessments);
        }
    }
}
