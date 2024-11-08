using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fish.Services.Interfaces;

namespace fish.WebApplication.Controllers
{
    public class Index4Controller : Controller
    {
        private readonly IIndex4Service _index4Service;

        public Index4Controller(IIndex4Service index4Service)
        {
            _index4Service = index4Service;
        }

        // GET: Index1
        public ActionResult Index()
        {
            _index4Service.DoNothing(); // Gọi service nếu có logic nào trong tương lai
            return View();
        }
    }
}
