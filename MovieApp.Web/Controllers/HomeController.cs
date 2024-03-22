using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Data;
using MovieApp.Web.Models;
using System.Linq;

namespace MovieApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _context;

        public HomeController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel()
            {
                PopularMovies = _context.Movies.ToList()
            };

            return View(model);
            //return View(m);
            //return view ile home controller altında action isimli (ındex) isimli view klasörü altında arayacak
        }
        public IActionResult About()
        {



            return View("About");
        }

    }
}
