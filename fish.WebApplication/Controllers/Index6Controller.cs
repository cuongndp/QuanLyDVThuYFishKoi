using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fish.Services.Interfaces;

namespace fish.WebApplication.Controllers
{
    public class Index6Controller : Controller
    {
        private readonly IIndex6Service _index6Service;

        public Index6Controller(IIndex6Service index6Service)
        {
            _index6Service = index6Service;
        }

        // GET: Index6
        public ActionResult Index()
        {
            _index6Service.DoNothing(); // Gọi service nếu có logic nào trong tương lai
            return View();
        }
    }
}
