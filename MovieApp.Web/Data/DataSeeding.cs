using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore; //migrate için 
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Web.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Web.Data
{
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MovieContext>();

            context.Database.Migrate();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Movies.Count() == 0)
                {
                    context.Movies.AddRange(

                            new List<Movie>()
                             {
                new Movie{  Title="film 1",Description="1",ImageUrl="atatürk.webp",GenreId=3},
                new Movie{  Title="film 2",Description="2",ImageUrl="fantastik.jpg",GenreId=2},
                new Movie{   Title="film 3",Description="3",ImageUrl="atatürk.webp", GenreId = 2},
                new Movie{   Title="film 4",Description="4",ImageUrl="atatürk.webp",GenreId=1},
                new Movie{  Title="film 5",Description="5",ImageUrl="atatürk.webp", GenreId = 3},
                new Movie{ Title="film 6",Description="6",ImageUrl="jawan.jpeg" , GenreId = 1}
                             }

                        );
                }
                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(
                            new List<Genre>()
            {
                new Genre {  Name= "Macera"},
                new Genre {  Name= "Komedi"},
                new Genre { Name = "Romantik"},
                new Genre { Name= "Savaş"}
            }

                        );
                }

                context.SaveChanges();
            }


        }





    }
}
