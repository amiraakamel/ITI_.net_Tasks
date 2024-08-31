using Microsoft.AspNetCore.Mvc;

namespace MVCTask1.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserProfile()
        {
            return View(); 
        }
    }
}
