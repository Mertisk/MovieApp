using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Entity;

namespace MovieApp.Web.Data
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }


        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {



        }



    }
}
