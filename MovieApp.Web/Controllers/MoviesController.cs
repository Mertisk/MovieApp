using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApp.Web.Data;
using MovieApp.Web.Entity;
using MovieApp.Web.Models;
using System.Linq;

namespace MovieApp.Web.Controllers
{
    //controller 
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;
        public MoviesController(MovieContext context)
        {
            _context = context; // Movies veya genre listesine baglanmak için MovieContext  içinden context çektik ve _context alanına atadık

        }


        [HttpGet]
        public IActionResult List(int? id, string q)
        {


            var kelime = q;




            var movies = _context.Movies.AsQueryable();

            if (id != null)
            {
                movies = movies.Where(m => m.GenreId == id);


            }

            if (!string.IsNullOrEmpty(kelime))
            {
                movies = movies.Where(
                  m => m.Title.ToLower().Contains(q.ToLower()) ||
                  m.Description.ToLower().Contains(q.ToLower()));
            }

            var model = new MoviesViewModel
            {
                Movies = movies.ToList(),
            };


            return View("Movies", model);


        }
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {

            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View();
        }
        [HttpPost]

        public IActionResult Create(Movie m)
        {
            if (ModelState.IsValid)
            {
                //MovieRepository.Add(m);

                _context.Movies.Add(m);
                _context.SaveChanges();
                TempData["Message"] = $"{m.Title}  eklendi.";


                return RedirectToAction("List");
            }
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");

            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);

        }
        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            if (ModelState.IsValid)
            {
                //MovieRepository.Edit(m);
                _context.Movies.Update(m);
                _context.SaveChanges();


                TempData["Message"] = $"{m.Title}  güncellendi.";


                return RedirectToAction("Details", "Movies", new { @id = m.MovieId });
            }
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View(m);

        }
        [HttpPost]
        public IActionResult Delete(int MovieId, string Title)
        {
            //MovieRepository.Delete(MovieId);


            var entity = _context.Movies.Find(MovieId);
            _context.Movies.Remove(entity);
            _context.SaveChanges();


            //ViewBag.Message = $"{Title} isimli film silindi.";bu şekilde viewbag ile yazınca alert ekranda çıkmıyor çünkü viewbag.message sadece yönlendirme yapmış oluyoruz değer ataması olmuyor 
            TempData["Message"] = $"{Title}  silindi.";
            return RedirectToAction("List");

        }

    }
}
