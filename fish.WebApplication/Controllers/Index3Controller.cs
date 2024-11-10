using System.Web.Mvc;
using Fish.Services.Interfaces;
using Fish.Repositories.Models;
using fish.Services.Interfaces;
using fish.Services.Services;

namespace Fish.WebApplication.Controllers
{
    public class Index3Controller : Controller
    {
        private readonly IPublicMessageService _publicMessageService;

        private readonly IUserService _userService; // Thêm IUserService

        public Index3Controller(IPublicMessageService publicMessageService, IUserService userService)
        {
            _publicMessageService = publicMessageService;

            _userService = userService; // Gán userService
        }

        // GET: PublicMessage
        public ActionResult Index()
        {
            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var messages = _publicMessageService.GetAllMessages();
            return View(messages); // Trả về danh sách tin nhắn để hiển thị trên view
        }

        // POST: PublicMessage/Add
        [HttpPost]
        public ActionResult Add(string noiDung)
        {

            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            if (Session["UserId"] == null)
            {
                return Json(new { error = "Bạn cần phải đăng nhập để gửi tin nhắn." });
            }


            if (!string.IsNullOrWhiteSpace(noiDung))
            {

                int userId = (int)Session["UserId"]; // Lấy ID người dùng từ Session
                var message = new PublicMessage
                {
                    UserId = userId,
                    NoiDung = noiDung
                };
                _publicMessageService.AddMessage(message);

                return Json(new { noiDung = message.NoiDung });
            }

            return Json(new { error = "Nội dung tin nhắn không được để trống" });
        }
    }
}