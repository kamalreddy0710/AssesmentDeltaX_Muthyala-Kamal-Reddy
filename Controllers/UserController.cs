using Microsoft.AspNetCore.Mvc;
using Musictify.Models;

namespace Musictify.Controllers
{
    public class UserController : Controller
    {
        DeltaXContext db;
        public UserController(DeltaXContext deltaXContext)
        {
            db = deltaXContext;
        }
        public IActionResult Index()
        {
            List<User> users = new List<User>();
            users=db.Users.ToList();

            return View(users);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login","Home");
        }

    }
}
