using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Data;
using System.Linq;

namespace MovieApp.Web.ViewComponents
{



    public class GenresViewComponent : ViewComponent
    {

        private readonly MovieContext _context;

        public GenresViewComponent(MovieContext context)
        {
            _context = context;
        }



        public IViewComponentResult Invoke()
        {
            //var turListesi = new List<Genre>()
            //{
            //    new Genre {Name= "Macera"},
            //    new Genre {Name= "Komedi"},
            //    new Genre {Name= "Romantik"},
            //    new Genre {Name= "Savaş"}
            //};
            //return View(turListesi);bunları ctrl+k+c yaptım cunku merkezi data dan film türleri alınabilir.


            ViewBag.SelectedGenre = RouteData.Values["id"];

            return View(_context.Genres.ToList());

        }



    }
}

