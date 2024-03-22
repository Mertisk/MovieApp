using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.Entity
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required]

        public string Title { get; set; }
        [StringLength(50, MinimumLength = 5)]

        public string Description { get; set; }


        public string ImageUrl { get; set; }
        [Required]
        public Genre Genre { get; set; } // navigation property
        public int? GenreId { get; set; } // int?(null)  olma sebebi mesela genreID= 7 yok ama 7 ataması yaparsak hata alamamak için null deger atamış oluyoruz 0 atanmaz çünkü genreId= 0 da karsılıgı yok 


    }
}
