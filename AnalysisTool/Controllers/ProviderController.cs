using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisTool.Controllers
{
    public class ProviderController : Controller
    {
        public IActionResult Provider()
        {
            return View();
        }
    }
}