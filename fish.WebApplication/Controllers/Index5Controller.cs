using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fish.Services.Interfaces;

namespace fish.WebApplication.Controllers
{
    public class Index5Controller : Controller
    {
        private readonly IIndex5Service _index5Service;

        public Index5Controller(IIndex5Service index5Service)
        {
            _index5Service = index5Service;
        }

        // GET: Index5
        public ActionResult Index()
        {
            _index5Service.DoNothing(); // Gọi service nếu có logic nào trong tương lai
            return View();
        }
    }
}
