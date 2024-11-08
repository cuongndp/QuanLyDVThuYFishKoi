using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using fish.Services.Interfaces;

namespace fish.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = _homeService.GetApplicationDescription();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = _homeService.GetContactMessage();
            return View();
        }
    }
}
