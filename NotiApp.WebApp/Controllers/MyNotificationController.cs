using Microsoft.AspNetCore.Mvc;
using NotiApp.Models;

namespace NotiApp.WebApp.Controllers
{
    public class MyNotificationController : Controller
    {
        private readonly IMyNotificationRepository repository;

        public MyNotificationController(IMyNotificationRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyNotification()
        {
            ViewBag.UserId = 1;
            return View();
        }

        public IActionResult MyNotificationWithModal()
        {
            ViewBag.UserId = 1;
            return View();
        }

        public IActionResult MyPage()
        {
            var userId = 1;
            ViewBag.UserId = userId;
            var noti = this.repository.GetNotificationByUserid(userId);

            return View(noti);
        }

        [Route("api/IsNotification")]
        public bool IsMyNotificationByUserId(int userId)
        {
            return this.repository.IsNotification(userId);
        }

        [Route("api/CompleteNotification")]
        public bool CompleteNotification(int userId)
        {
            this.repository.CompleteNotificationByUserid(userId);
            return true;
        }
    }
}
