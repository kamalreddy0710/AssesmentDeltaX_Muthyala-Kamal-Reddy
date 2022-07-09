using Microsoft.AspNetCore.Mvc;
using Musictify.Models;

namespace Musictify.Controllers
{
    public class ArtistsController : Controller
    {
        DeltaXContext db;
        public ArtistsController(DeltaXContext deltaXContext)
        {
            db = deltaXContext;
        }
        public IActionResult Index()
        {
            List<Artist> artists = new List<Artist>();
            artists=db.Artists.ToList();
            return View(artists);
        }
        [HttpGet]
        public IActionResult AddArtist()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddArtist(Artist artist)
        {
            db.Artists.Add(artist); 
            db.SaveChanges();
            return RedirectToAction("AddSong","Song");
        }

        
        public IActionResult Delete(int Id)
        {
            Artist artist = db.Artists.Find(Id);
            db.Artists.Remove(artist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Artist artist = db.Artists.Find(Id);
            return View(artist);
        }
        [HttpPost]
        public IActionResult Edit(Artist artist)
        {
            Artist artist1 = null;
            artist1=db.Artists.Find(artist.ArtistId);
            artist1.ArtistName = artist.ArtistName;
            artist1.DateofBirth = artist.DateofBirth;
            artist1.Bio=artist.Bio;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Details(int Id)
        {
            Artist artist=db.Artists.Find(Id);
            return View(artist);
        }



    }
}
