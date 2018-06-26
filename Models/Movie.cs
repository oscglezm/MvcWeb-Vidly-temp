using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.ComponentModel.DataAnnotations; // added for constrain [Required]

namespace MovieWebApp.Models
{
    public class Movie
    {
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter the Title of the Movie")]
        public string Name { get; set; }
  
        [Display(Name = "Release Date")]
       public DateTime ReleaseDate { get; set; }

       
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1,20,ErrorMessage = "The field Number in Stock must be between 1 and 20.")]
        public int NumberInStock { get; set; }

         
        public Genre Genre { get; set; }

        public byte GenreId { get; set; }

        public byte NumberAvailable { get; set; }

       
    }
}