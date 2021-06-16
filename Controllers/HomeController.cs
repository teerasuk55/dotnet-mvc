using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sample.Models;

namespace sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult History()
        {
            return View();
        }
        public IActionResult Form()
        {
            return View();
        }
        public IActionResult Addform()
        {
            return View();
        }

        public IActionResult Editform()
        {
            return View();
        }

        public IActionResult Endform()
        {
            return View();
        }

        public IActionResult Adminform()
        {
            return View();
        }

        public IActionResult Manageuser()
        {
            return View();
        }

        public IActionResult Adduser()
        {
            return View();
        }

        public IActionResult Edituser()
        {
            return View();
        }

        public IActionResult Manageform()
        {
            return View();
        }

        public IActionResult Editformadmin()
        {
            return View();
        }

        public IActionResult Profile()
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
