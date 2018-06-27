using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using MovieWebApp.Models;
using MovieWebApp.Dtos;
using AutoMapper;
 
using System.Data.Entity; // Eager Loading
 
 
 

namespace MovieWebApp.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

 
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/customers
        public IHttpActionResult GetCustomers(string query = null) //Filtering records
        {
            // _context.Customers.Include(c => c.MemberShipType).ToList(); // Eager Loading

            var customersQuery = _context.Customers.Include(c => c.MemberShipType);

            //if there is a customer name filtered then retrieve that customer from the db.
            if (!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }
               
        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id) //change the return type
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                // throw  new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            //return customerDto;
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return  BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            //return customerDto;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto );
        }


        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                // throw  new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            //Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb); // is redondant
            Mapper.Map(customerDto, customerInDb);

            //customerInDb.Name = customerDto.Name;
            //customerInDb.BirthDate = customerDto.BirthDate;
            //customerInDb.MemberShipTypeId = customerDto.MemberShipTypeId;
            //customerInDb.IsSubscribed = customerDto.IsSubscribed;

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
