using Microsoft.AspNetCore.Mvc;
using MVCTask2.Models;

namespace MVCTask2.Controllers
{
    public class UserController : Controller
    {
        private readonly MVCTask2DBContext context;
        public UserController()
        {
            this.context = new();
        }
        public IActionResult Index()
        {
            List<User> users = context.Users.ToList();
            return View(users);
        }

        public IActionResult Details(int id)
        {
            User? user = context.Users.Where(u=>u.Id == id).SingleOrDefault();
            if(user == null)
            {
                return Content("Invalid Id");
            }
            return View(user);
        }
    }
}
