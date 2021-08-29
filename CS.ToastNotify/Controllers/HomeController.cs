using AspNetCoreHero.ToastNotification.Abstractions;
using CS.ToastNotify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CS.ToastNotify.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotyfService _notyfService;
        public HomeController(ILogger<HomeController> logger, INotyfService notyfService)
        {
            _logger = logger;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            _notyfService.Success("You have successfully saved the data.");
            _notyfService.Error("Exception...");
            _notyfService.Warning("Warning...");
            _notyfService.Information("Welcome to CoreSpider.", 5);
            return View();
        }

        [HttpPost]
        public IActionResult Index(string submit) 
        {
            switch (submit)
            {
                case "Success":
                    _notyfService.Success("You have successfully saved the data.");
                    break;
                case "Info":
                    _notyfService.Information("Welcome to CoreSpider.", 5);
                    break;
                case "Error":
                    _notyfService.Error("Exception...");
                    break;
                case "Warning":
                    _notyfService.Warning("Warning...");
                    break;
            }
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
