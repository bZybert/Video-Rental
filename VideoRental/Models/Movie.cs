using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRental.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage ="Genre field is required")]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "The Release Date field is required")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [NumberBetween1To20]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }
    }
}
