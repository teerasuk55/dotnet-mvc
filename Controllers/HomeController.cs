using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnet_mvc_master.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sample.Data;
using sample.Models;

namespace sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext databaseContext;

        private readonly ILogger<HomeController> _logger;

        public HomeController(DatabaseContext databaseContext,ILogger<HomeController> logger)
        {
            this.databaseContext = databaseContext;
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
            var data = new FormViewModels{
                Provinces = databaseContext.Provinces.ToList(),
            };
            return View(data);
        }

        [HttpPost]
        public IActionResult GetDistrict(int provinceId)
        {
            var data = new FormViewModels();
            var districts = databaseContext.Districts.Where(w=>w.ProvinceId == provinceId).ToList();

            data = new FormViewModels{
                Districts = districts,
            };
            data.msg = "Hello";
            return Json(data);
        }

        [HttpPost]
        public IActionResult Subdistricts(int districtsId)
        {
            var subdistricts = databaseContext.Subdistricts.Where(w=>w.DistrictId == districtsId).ToList();
            var data = new FormViewModels{
                Subdistricts = subdistricts,
            };
            return Json(data);
        }

        public IActionResult Editform()
        {
            var data = new FormViewModels{
                Provinces = databaseContext.Provinces.ToList(),
            };
            return View(data);
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
