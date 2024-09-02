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
            TempData["Message"] = "User view Details successfully.";
            return View(user);
        }

        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult AddToDB(User u)
        {
            context.Users.Add(u);
            context.SaveChanges();
            TempData["Message"] = "User added successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult EditForm(int id)
        {
            User? user = context.Users.SingleOrDefault(u => u.Id == id);
            if (user == null)
            {
                return Content("Invalid Id");
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult EditToDB(int id, string Name, int Age, string Email, string Password)
        {
            User? user = context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return Content("Invalid Id");
            }

            user.Name = Name;
            user.Age = Age;
            user.Email = Email;
            user.Password = Password;

            context.SaveChanges();
            TempData["Message"] = "User updated successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) 
        {
            User? user = context.Users.SingleOrDefault(user=>user.Id == id);

            if (user == null)
            {
                return Content("Invalid Id");
            }

            context.Users.Remove(user);
            context.SaveChanges();
            TempData["Message"] = "User deleted successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult CookiesForm()
        {
            return View();
        }

        public IActionResult SetCookiesData(string name , string email)
        {

            Response.Cookies.Append("Name",name);
            Response.Cookies.Append("Email", email);

            return RedirectToAction("GetCookiesData");
        }

        public IActionResult GetCookiesData()
        {
            string Name = Request.Cookies["Name"];
            string Email = Request.Cookies["Email"];

            return View(new {Name = Name ,Email = Email});
        }
    }
}
