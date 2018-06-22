using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieWebApp.Models
{
    public class MovieFormViewModel
    {

        [Required]
        public int? ID { get; set; }

        [Required(ErrorMessage = "Please enter the Title of the Movie")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        
        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20.")]
        [Required]
        public int? NumberInStock { get; set; }


        [Display (Name = "Genre")]
        [Required]
       public byte? GenreId { get; set; }

        public List<Genre> Genres { get; set; }



        public string Title
        {
            get
            {
                return ID != 0 ? "Edit Movie" : "New Movie"; //if (..) then (?) else (:)
            }
        }


        public MovieFormViewModel()
        {
            ID = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            ID = movie.ID;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }


    }
}