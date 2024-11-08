using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fish.Services.Interfaces;

namespace fish.WebApplication.Controllers
{
    public class DichVuController : Controller
    {
        private readonly IDichVuService _dichVuService;

        public DichVuController(IDichVuService dichVuService)
        {
            _dichVuService = dichVuService ?? throw new ArgumentNullException(nameof(dichVuService));
        }

        // GET: DichVu/Index
        public ActionResult Index()
        {
            var services = _dichVuService.GetAllServices();
            return View(services);
        }



       



        public ActionResult Form()
        {
            // Lấy danh sách bác sĩ từ DichVuService
            var doctors = _dichVuService.GetDoctors();

            // Truyền danh sách bác sĩ vào ViewBag để sử dụng trong View
            ViewBag.Doctors = doctors;

            return View();
        }
    }
}
