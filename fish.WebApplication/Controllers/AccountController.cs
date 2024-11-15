using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using fish.Services.Interfaces;
using Fish.Repositories.Models;

namespace fish.WebApplication.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        // Inject IAccountService thông qua constructor
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        //
      





























        //

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string fullName, string email, string phoneNumber, string username, string role, string password, string rolePassword)
        {

            // Mật khẩu cấp quyền (có thể lưu trong file cấu hình thay vì mã cứng)
            const string adminRolePassword = "admin";
            const string doctorRolePassword = "doctor";

            // Kiểm tra quyền truy cập dựa trên role và rolePassword
            if (role == "Admin" && rolePassword != adminRolePassword)
            {
                ViewBag.Error = "Mật khẩu cấp quyền cho vai trò Admin không chính xác.";
                return View();
            }
            if (role == "Doctor" && rolePassword != doctorRolePassword)
            {
                ViewBag.Error = "Mật khẩu cấp quyền cho vai trò Doctor không chính xác.";
                return View();
            }
            

            var user = new User
            {
                FullName = fullName,
                Email = email,
                PhoneNumber = phoneNumber,
                Username = username,
                Role = role,
                Password = password
            };

            if (!_accountService.Register(user))
            {
                ViewBag.Error = "Tên đăng nhập, email hoặc số điện thoại đã tồn tại.";
                return View();
            }

            ViewBag.Error = "Tạo tài khoản thành công";
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }





        //....



        [Authorize]
        public ActionResult BookingForm()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            ViewBag.Doctors = _accountService.GetDoctors();
            return View("~/Views/DichVu/Form.cshtml");
        }
        [HttpPost]
        [Authorize]
        public ActionResult SubmitBooking(string diachi, string ngayHen, string gioHen, string moTa, decimal? giaTien, int? doctorId = null)
        {


            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var booking = new Booking
            {
                FullName = Session["FullName"]?.ToString(),
                PhoneNumber = Session["PhoneNumber"]?.ToString(),
                Email = Session["Email"]?.ToString(),
                DiaChi = diachi,
                NgayHen = DateTime.Parse(ngayHen),
                GioHen = TimeSpan.Parse(gioHen),
                MoTa = moTa,
                GiaTien = giaTien ?? 0,
                UserId = Convert.ToInt32(Session["UserId"]),
                DoctorId = doctorId
            };

            if (!_accountService.Booking(booking))
            {
                ViewBag.Error = "Đã xảy ra lỗi trong quá trình đặt lịch.";
                ViewBag.Doctors = _accountService.GetDoctors();
                return View("~/Views/DichVu/Form.cshtml");
            }
            ViewBag.Message = "Đặt lịch thành công!";
            return View("~/Views/DichVu/Form.cshtml");

        }


        //....




        [HttpGet]
        public ActionResult RegisterWithRole(string role)
        {
            ViewBag.SelectedRole = role;
            return View("Register"); // Đảm bảo tên view là "Register"
        }

    }
}
