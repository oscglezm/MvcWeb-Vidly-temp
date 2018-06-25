using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieWebApp.Models;
using MovieWebApp.ViewModels;
using System.Data.Entity; // Eager Loading

namespace MovieWebApp.Controllers
{
    using System.Diagnostics.CodeAnalysis;

    [AllowAnonymous] //allow anonymous access
    public class CustomersController : Controller
    {
        //
        // GET: /Customers/
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


       
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            List<Customer> customers = _context.Customers.Include(c => c.MemberShipType).ToList(); // Eager Loading

            //RandomMovieModel viewModels = new RandomMovieModel
            //{
            //    Customers = customers
            //};

          
            //return View(viewModels);

            return View(); // above code was commented because It has been developed datatables with Ajax code. (check video 79)
                      
        }


        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(x => x.Id == id);  // Eager Loading

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {

            var membershiptypes = _context.MemberShipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                Customer =  new Customer(), //it avoid the validation error printed: "The Id field is required" when you invoke the  @Html.ValidationSummary() in CustomerForm view.
                MemberShipTypes = membershiptypes
            };

            return View("CustomerForm",viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save( Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MemberShipTypes = _context.MemberShipTypes.ToList()
                };
                return View("CustomerForm",viewmodel);
            }


            if(customer.Id == 0)
            _context.Customers.Add(customer); //Add new customer

            else // Edit existing customer
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDB.Name = customer.Name;
                customerInDB.BirthDate = customer.BirthDate;
                customerInDB.IsSubscribed = customer.IsSubscribed;
                customerInDB.MemberShipTypeId = customer.MemberShipTypeId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);

            if(customer == null)
                return new HttpNotFoundResult();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };

            return View("CustomerForm",viewModel);
        }

    }
}