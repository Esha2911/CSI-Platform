using CSI_Platform.Entities.Model;
using CSI_Platform.Repository.Repository.IRepository;
using CSI_Platform_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CSI_Platform_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository _ctx)
        {
            _logger = logger;
            _homeRepository = _ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Index(User user)
        {
            string status = _homeRepository.Login(user.Email, user.Password);

            if (status.Equals("Valid"))
            {
                TempData["Success"] = "Login Successfull";
                return RedirectToAction("Index", "PlatformLanding");
            }
            else
            {
                TempData["Invalid"] = "Invalid Credentials";
                return View();
            }
        }

        public IActionResult LostPassword()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _homeRepository.Add(user);
            _homeRepository.save();
            return RedirectToAction("Index");
        }

        public IActionResult ResetPassword()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PlatformLanding()
        {
            return View();
        }
        public IActionResult VolunteeringMission()
        {
            return View();
        }
        public IActionResult StoryListing()
        {
            return View();
        }
        public PartialViewResult GetGridView()
        {
            return PartialView("_GridCard");
        }
        public PartialViewResult GetListView()
        {
            return PartialView("_ListCard");
        }
        public PartialViewResult GetNoMission()
        {
            return PartialView("_NoMissionFound");
        }
    }
}