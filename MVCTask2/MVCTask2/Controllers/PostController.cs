using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MVCTask2.Models;

namespace MVCTask2.Controllers
{
    public class PostController : Controller
    {
        private readonly MVCTask2DBContext context;
        public PostController()
        {
            this.context = new();
        }

        public IActionResult Index()
        {
            var users = context.Users.ToDictionary(u => u.Id, u => u.Name);
            ViewBag.UserNames = users;
            List<Post> posts = context.Posts.ToList();
            return View(posts);
        }

        public IActionResult Details(int id)
        {
            Post? post = context.Posts.Where(p => p.Id == id).SingleOrDefault();
            if (post == null)
            {
                return Content("Invalid Id");
            }
            var user = context.Users.SingleOrDefault(u => u.Id == post.UserId);
            if(user != null)
            {
                ViewBag.UserName = user.Name;
            }
            return View(post);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<User> Users = context.Users.ToList();
            ViewBag.Users = Users;


            int? userId = HttpContext.Session.GetInt32("userId");
            ViewBag.UserId = userId;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Post p)
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            if(userId == null)
            {
                p.UserId = p.UserId;
            }
            else
            {
                p.UserId = userId.Value;
            }

            context.Posts.Add(p);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Post? post = context.Posts.SingleOrDefault(p => p.Id == id);
            if (post == null)
            {
                return Content("Invalid Id");
            }
            List<User> Users = context.Users.ToList();
            ViewBag.Users = Users;
            return View(post);
        }


        [HttpPost]
        public IActionResult Edit(Post p)
        {
            context.Posts.Update(p);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Post? post = context.Posts.SingleOrDefault(p=> p.Id == id);

            if (post == null)
            {
                return Content("Invalid Id");
            }

            context.Posts.Remove(post);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
