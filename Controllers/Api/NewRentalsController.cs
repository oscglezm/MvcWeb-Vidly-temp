using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Security.Provider;
using MovieWebApp.Models;

namespace MovieWebApp.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //POST /api/newrentals
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            try
            {
                if (newRental.MoviesIds.Count == 0)
                    return BadRequest("No movies Ids have been given");

                //if (!ModelState.IsValid)
                //    return BadRequest();

                var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

                if (customer == null)
                    return BadRequest("Customer id is not valid");


                var movies = _context.Movies.Where(m => newRental.MoviesIds.Contains(m.ID)).ToList();

                if (movies.Count != newRental.MoviesIds.Count)
                    return BadRequest("One or more movies ids are invalid");

                foreach (Movie current in movies)
                {
                    if (current.NumberAvailable == 0)
                        return BadRequest("Movie is not available");

                    current.NumberAvailable--;

                    var rental = new Rental()
                    {
                        Customer = customer,
                        DateRented = DateTime.Now,
                        Movie = current
                    };

                    _context.Rentals.Add(rental);

                }

                _context.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }
    }
}