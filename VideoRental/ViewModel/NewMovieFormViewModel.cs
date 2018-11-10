using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VideoRental.Models;

namespace VideoRental.ViewModel
{
    public class NewMovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        //public Movie Movie { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre field is required")]
        public byte? GenreId { get; set; }
                
        [Required(ErrorMessage = "The Release Date field is required")]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [NumberBetween1To20]
        public byte? NumberInStock { get; set; }

        public NewMovieFormViewModel()
        {
            Id = 0;
        }

        public NewMovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}
