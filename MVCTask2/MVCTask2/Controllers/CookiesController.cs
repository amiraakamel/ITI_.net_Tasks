using Microsoft.AspNetCore.Mvc;

namespace MVCTask2.Controllers
{
    public class CookiesController : Controller
    {
        public IActionResult CookiesForm()
        {
            return View();
        }

        public IActionResult SetCookiesData(string name, string email)
        {

            Response.Cookies.Append("Name", name);
            Response.Cookies.Append("Email", email);

            return RedirectToAction("GetCookiesData");
        }

        public IActionResult GetCookiesData()
        {
            string Name = Request.Cookies["Name"];
            string Email = Request.Cookies["Email"];

            return View(new { Name = Name, Email = Email });
        }
    }
}
