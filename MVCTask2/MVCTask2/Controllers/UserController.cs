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

        
        public IActionResult EditToDB(User us)
        {
            User? user = context.Users.SingleOrDefault(u => u.Id == us.Id);

            if (user == null)
            {
                return Content("Invalid Id");
            }

            user.Name = us.Name;
            user.Age = us.Age;
            user.Email = us.Email;
            user.Password = us.Password;

            context.SaveChanges();
            TempData["Message"] = "User updated successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) 
        {
            User? user = context.Users.SingleOrDefault(u=>u.Id == id);

            if (user == null)
            {
                return Content("Invalid Id");
            }

            context.Users.Remove(user);
            context.SaveChanges();
            TempData["Message"] = "User deleted successfully.";
            return RedirectToAction("Index");
        }


    }
}
