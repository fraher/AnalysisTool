﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnalysisTool.Models;
using AnalysisTool.ViewModels;
using AnalysisTool.Persistence;
using Microsoft.AspNetCore.Authorization;

namespace AnalysisTool.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]        
        public IActionResult Index()
        {
            

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

    }
}
