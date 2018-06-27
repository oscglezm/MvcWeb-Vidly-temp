using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieWebApp.Dtos
{
    public class MovieDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter the Title of the Movie")]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }
        
        public DateTime? DateAdded { get; set; }

        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20.")]
        public int NumberInStock { get; set; }
        
        [Required]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }

    }
}