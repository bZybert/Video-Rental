using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoRental.Models;
using VideoRental.ViewModel;

namespace VideoRental.Controllers
{
    public class CustomersController : Controller
    {
        private EFCContext _context;

        public CustomersController()
        {
            _context = new EFCContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult New()
        {
            var membershipTypes = _context.MembershipType.ToList();

            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(), //dodajemy żeby validacja nie wskazywała error że Id == null
                MembershipType = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //zabezpieczenie danych z formularza
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipType = _context.MembershipType.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)  // sprawdzamy czy customer jest nowym użytkownikiem
            {
                _context.Customers.Add(customer);
            }
            else  // jeżeli nie wyszukujemy w bazie 
            {
                var customerInDb = _context.Customers.Single(x => x.Id == customer.Id);

                // TryUpdateModelAsync(customer);
                //przypisyjemy ręcznie lub alternatywa  AutoMapper  Mapper.Map(customer,customerInDb)
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
                        
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipType.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        public IActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public IActionResult Details(int id)
        {

            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }


    }
}