using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using MyPortfolio.Models;
using System.ComponentModel;
using System;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _environment;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult Index()
        {
          
            return View();
        }
        public IActionResult Download()
        {
            var webRootPath = _environment.WebRootPath;
            var folderPath = Path.Combine(webRootPath, "cv");
            var filePath = Path.Combine(folderPath, "cv(2).pdf");

            if (System.IO.File.Exists(filePath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/pdf", "cv(2).pdf");
            }

            return RedirectToAction("Index");
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