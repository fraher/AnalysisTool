using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalysisTool.Persistence;
using AnalysisTool.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnalysisTool.Controllers
{
    public class ReportController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private ReportViewModel _model;

        public ReportController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _model = new ReportViewModel();
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
