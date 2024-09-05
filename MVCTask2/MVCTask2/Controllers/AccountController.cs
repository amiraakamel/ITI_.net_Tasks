using Microsoft.AspNetCore.Mvc;
using MVCTask2.Models;

namespace MVCTask2.Controllers
{
    public class AccountController : Controller
    {
        private readonly MVCTask2DBContext context;
        public AccountController()
        {
            this.context = new();
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(User u)
        {
            User? user = context.Users
                        .Where(us => us.Email == u.Email && us.Password == u.Password)
                        .SingleOrDefault();

            if (user == null)
            {
                ViewBag.error = "Invalid email or password.";
                return View("LogIn");
            }

            HttpContext.Session.SetString("username", user.Name);
            HttpContext.Session.SetInt32("userId", user.Id);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","User");
        }
    }
}
