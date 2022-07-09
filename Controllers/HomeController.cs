using Microsoft.AspNetCore.Mvc;
using Musictify.Models;
using System.Diagnostics;

namespace Musictify.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            ViewModel viewModel = new ViewModel();
            DeltaXContext db = new DeltaXContext();
            viewModel.artistList = db.Artists.Take(10).ToList();
            viewModel.songList=db.Songs.Take(10).ToList();
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            List<User> users = new List<User>();
            using (DeltaXContext context = new DeltaXContext())
            {
                users = context.Users.ToList();
            }
            foreach (var user1 in users)
            {
                if(user.UserName==user1.UserName)
                {
                    if(user.Password==user1.Password)
                    {
                        HttpContext.Session.SetString("UserName", user.UserName.ToUpper());
                        return RedirectToAction("Index");
                    }
                }
            }
            ViewData["Message"] = "Incorrect UserName/Password";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}