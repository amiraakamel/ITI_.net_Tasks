using Microsoft.AspNetCore.Mvc;
using MVCTask2.Models;
using MVCTask2.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace MVCTask2.Controllers;

public class AccountController : Controller
{
    private readonly MVCTask2DBContext context;
    public AccountController()
    {
        this.context = new();
    }

    [HttpGet]
    public IActionResult Register()
    {
        UserVM model = new UserVM(); 
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(UserVM user)
    {
          if(ModelState.IsValid)
        {
            User u = new User()
            {
                Name = user.Name,
                Age = user.Age,
                Email = user.Email,
                Password = user.Password
            };
            context.Users.Add(u);
            int Id = context.SaveChanges();
            u.Id = Id;
            return RedirectToAction("LogIn");
        }

        return View(user);
    }

    [HttpGet]
    public IActionResult LogIn()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
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

        return RedirectToAction("Details", "User" , new {id = user.Id});
    }

    public IActionResult LogOut()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index","User");
    }
}
