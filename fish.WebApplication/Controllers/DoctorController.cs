using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fish.Services.Interfaces;

namespace fish.WebApplication.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public ActionResult DoctorSchedule()
        {
            if (Session["UserId"] == null || Session["Role"]?.ToString() != "Doctor")
            {
                return RedirectToAction("Login", "Account");
            }

            // Lấy danh sách các lịch khám mà bác sĩ được gán
            int doctorId = Convert.ToInt32(Session["UserId"]);
            var bookings = _doctorService.GetBookingsForDoctor(doctorId);

            return View("~/Views/Doctor/DoctorSchedule.cshtml", bookings);
        }
    }
}
