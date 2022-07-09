using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Musictify.Models;

namespace Musictify.Controllers
{

    public class SongController : Controller
    {
        DeltaXContext db;
        public SongController(DeltaXContext deltaXContext)
        {
            db = deltaXContext;
        }
        public IActionResult Index()
        {
            List<Song> songs= new List<Song>();
            songs=db.Songs.ToList();
            return View(songs);
        }

        [HttpGet]
        public IActionResult AddSong()
        {
            var list=new SelectList(db.Artists.ToList(),"ArtistName","ArtistName");
            ViewData["Artists"]=list;
            return View();
        }

        [HttpPost]
        public IActionResult AddSong(Song song)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");

           
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new FileInfo(song.ImageFile.FileName);
            string fileName = DateTime.Now.ToString()+song.ImageFile + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                song.ImageFile.CopyTo(stream);
            }
            song.ArtWork = fileName;

         
            db.Songs.Add(song);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int Id)
        {
            Song song = db.Songs.Find(Id);
            db.Songs.Remove(song);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Song song = db.Songs.Find(Id);
            return View(song);
        }
        [HttpPost]
        public IActionResult Edit(Song song)
        {
            Song song1 = null;
            song1 = db.Songs.Find(song.SongId);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");


            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new FileInfo(song.ImageFile.FileName);
            string fileName = song.ImageFile + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                song.ImageFile.CopyTo(stream);
            }
            song.ArtWork = fileName;
            song1.ArtWork=song.ArtWork;
            song1.SongName = song.SongName;
            song1.ArtWork=song.ArtWork;
            song1.Artists=song.Artists;
            song1.DateReleased=song.DateReleased;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Details(int Id)
        {
            Song song = db.Songs.Find(Id);
            return View(song);
        }
       

    }
}
