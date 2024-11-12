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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = _accountService.Login(username, password);
            if (user != null)
            {
                Session["UserId"] = user.Id;
                Session["FullName"] = user.FullName;
                Session["PhoneNumber"] = user.PhoneNumber;
                Session["Email"] = user.Email;
                Session["Role"] = user.Role;



                // Đặt cookie xác thực
                FormsAuthentication.SetAuthCookie(username, false);


                if (user.Role == "Admin")
                    return RedirectToAction("AdminOnlyAction", "Admin");
                if (user.Role == "Doctor")
                    return RedirectToAction("DoctorSchedule", "Doctor");

                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không chính xác.";
            return View();
        }

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





        //phong








        //phong





        [HttpGet]
        public ActionResult RegisterWithRole(string role)
        {
            ViewBag.SelectedRole = role;
            return View("Register"); // Đảm bảo tên view là "Register"
        }

    }
}
