using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fish.Services.Interfaces;
using Fish.Repositories.Models;

namespace fish.WebApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [Authorize(Roles = "Admin,Doctor")]
        public ActionResult ManageServices()
        {
            var services = _adminService.GetAllServices();
            return View(services);
        }

        public ActionResult AdminOnlyAction(int? editBookingId = null, int? editUserId = null)
        {
            if (Session["Role"]?.ToString() != "Admin")
                return RedirectToAction("Login", "Account");

            ViewBag.Users = _adminService.GetAllUsers();
            ViewBag.Services = _adminService.GetAllServices();
            ViewBag.Bookings = _adminService.GetAllBookings();

            if (editBookingId.HasValue)
            {
                ViewBag.BookingToEdit = _adminService.GetBookingById(editBookingId.Value);
            }

            if (editUserId.HasValue)
            {
                ViewBag.UserToEdit = _adminService.GetUserById(editUserId.Value);
            }

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateService(ServiceModel service)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddService(service);
                return RedirectToAction("ManageServices");
            }
            return View(service);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditService(int id)
        {
            var service = _adminService.GetServiceById(id);
            if (service == null)
                return HttpNotFound();

            return View(service);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult EditService(ServiceModel service)
        {
            if (ModelState.IsValid)
            {
                _adminService.UpdateService(service);
                return RedirectToAction("ManageServices");
            }
            return View(service);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteService(int id)
        {
            _adminService.DeleteService(id);
            return RedirectToAction("ManageServices");
        }

        public ActionResult ManageBookings(int? editBookingId = null)
        {
            if (Session["Role"]?.ToString() != "Admin")
                return RedirectToAction("Login", "Account");

            ViewBag.Users = _adminService.GetAllUsers();
            ViewBag.Services = _adminService.GetAllServices();
            ViewBag.Bookings = _adminService.GetAllBookings();

            if (editBookingId.HasValue)
            {
                ViewBag.BookingToEdit = _adminService.GetBookingById(editBookingId.Value);
            }

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AssignDoctor(int id)
        {
            var booking = _adminService.GetBookingById(id);

            if (booking == null)
                return HttpNotFound();

            ViewBag.Doctors = _adminService.GetDoctors();
            return View(booking);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AssignDoctor(int id, int doctorId)
        {
            var booking = _adminService.GetBookingById(id);
            if (booking == null)
                return HttpNotFound();

            var doctor = _adminService.GetUserById(doctorId);
            if (doctor == null || doctor.Role != "Doctor")
            {
                ViewBag.Error = "Bác sĩ không hợp lệ.";
                ViewBag.Doctors = _adminService.GetDoctors();
                return View(booking);
            }

            _adminService.AssignDoctor(id, doctorId);
            return RedirectToAction("ManageBookings");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ManageUsers()
        {
            var users = _adminService.GetAllUsers();
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserInAdmin(User user)
        {
            if (Session["Role"]?.ToString() != "Admin")
                return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                _adminService.UpdateUser(user);
                return RedirectToAction("AdminOnlyAction");
            }

            ViewBag.Users = _adminService.GetAllUsers();
            ViewBag.Services = _adminService.GetAllServices();
            ViewBag.UserToEdit = user;
            return View("AdminOnlyAction");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUser(int id)
        {
            if (Session["Role"]?.ToString() != "Admin")
                return RedirectToAction("Login", "Account");

            _adminService.DeleteUser(id);
            return RedirectToAction("AdminOnlyAction");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBookings(Booking booking)
        {
            if (Session["Role"]?.ToString() != "Admin")
                return RedirectToAction("Login", "Account");

            if (booking.UserId == 0)
            {
                ModelState.AddModelError("", "UserId is required.");
            }


            if (ModelState.IsValid)
            {
                _adminService.UpdateBooking(booking);
                return RedirectToAction("AdminOnlyAction");



            }

            ViewBag.Users = _adminService.GetAllUsers();
            ViewBag.Services = _adminService.GetAllServices();
            ViewBag.BookingToEdit = booking;
            return View("AdminOnlyAction");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBooking(int id)
        {
            if (Session["Role"]?.ToString() != "Admin")
                return RedirectToAction("Login", "Account");

            _adminService.DeleteBooking(id);
            return RedirectToAction("AdminOnlyAction");
        }

    }
}
