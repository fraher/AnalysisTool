using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisTool.Controllers
{
    public class SharingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}