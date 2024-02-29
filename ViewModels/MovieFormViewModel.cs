using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {

        public MovieFormViewModel() {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie, IEnumerable<Genre> genres)
        {
            Genres = genres;
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
        }

        public IEnumerable<Genre>? Genres { get; set;}
        public string Title {
            get {
                if (Id != 0)
                    return "Edit Movie";
                else return "New Movie";
            }
        }


        public int? Id { get; set; }

        [Required]
        [Display(Name = "Movie")]
        [MaxLength(255)]
        public string Name { get; set; }

        //public Genre Genre { get; set; }

        
        [Display(Name= "Genre")]
        [Required]
        public int? GenreId { get; set; }


        
        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }


        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 30)]
        public byte? NumberInStock { get; set; }
    }
}
