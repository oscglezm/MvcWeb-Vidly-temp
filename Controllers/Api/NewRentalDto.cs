using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieWebApp.Models;

namespace MovieWebApp.Controllers.Api
{
   public class NewRentalDto
   {
     
       public int CustomerId { get; set; }
       public List<int> MoviesIds { get; set; }

   }
}
