using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalysisTool.Persistence;
using AnalysisTool.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisTool.Controllers
{
    public class ProviderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private ProviderViewModel _model;

        public ProviderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _model = new ProviderViewModel();
        }

        public IActionResult Provider()
        {
            return View();
        }
    }
}