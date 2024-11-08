using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fish.Services.Interfaces;

namespace fish.WebApplication.Controllers
{
    public class Index3Controller : Controller
    {
        private readonly IIndex3Service _index3Service;

        public Index3Controller(IIndex3Service index3Service)
        {
            _index3Service = index3Service;
        }

        // GET: Index1
        public ActionResult Index()
        {
            _index3Service.DoNothing(); // Gọi service nếu có logic nào trong tương lai
            return View();
        }
    }
}
