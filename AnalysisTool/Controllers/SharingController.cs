using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalysisTool.Persistence;
using AnalysisTool.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisTool.Controllers
{
    public class SharingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private SharingViewModel _model;

        public SharingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _model = new SharingViewModel();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}