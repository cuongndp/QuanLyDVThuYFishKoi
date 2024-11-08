using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fish.Services.Interfaces;

namespace fish.WebApplication.Controllers
{
    public class Index1Controller : Controller
    {
        private readonly IIndex1Service _index1Service;

        public Index1Controller(IIndex1Service index1Service)
        {
            _index1Service = index1Service;
        }

        // GET: Index1
        public ActionResult Index()
        {
            _index1Service.DoNothing(); // Gọi service nếu có logic nào trong tương lai
            return View();
        }
    }
}
