using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Webapp_Bank.Models;

namespace Webapp_Bank.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<User> userlist = new List<User>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            userlist.Add(new Models.User { Username = "Pradeep", Password = "Pradeep@123" });
            userlist.Add(new Models.User { Username = "Maillka", Password = "mallika@123" });
            userlist.Add(new Models.User { Username = "Vibhu", Password = "Vibhu@123" });
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User u)
        {
            var found = userlist.Find(f => ((f.Username == u.Username) && (f.Password == u.Password)));
            if (found != null)
            {
                return
                    RedirectToAction("Dashboard", "Home");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}

