using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoRental.Models;

namespace VideoRental.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private EFCContext _context;
        public CustomersController()
        {
            _context = new EFCContext();
        }

        /*
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return Content("not found");
            }

            return customer;
        }

       

        //PUT
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw BadRequest(ModelState);
            }



            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        */






        // ------------------------------------------------
        [HttpGet]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        [HttpGet("{id}", Name = "Customers")]
        public ActionResult<Customer> GetCustomerById(long id)
        {
            var item = _context.Customers.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Customer item)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.Name = item.Name;
            customer.BirthDate = item.BirthDate;
            customer.IsSubscribedToNewsletter = item.IsSubscribedToNewsletter;
            customer.MembershipTypeId = item.MembershipTypeId;

            _context.Customers.Update(customer);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return NoContent();
        }
    }
}


