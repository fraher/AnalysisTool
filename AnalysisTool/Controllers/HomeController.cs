using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnalysisTool.Models;
using AnalysisTool.ViewModels;

namespace AnalysisTool.Controllers
{
    public class HomeController : Controller
    {
        private AnalysisToolContext _context { get; set; }

        public HomeController(AnalysisToolContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();


            model.User = _context.Users.FirstOrDefault(u => u.UserId == 1);
            

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
