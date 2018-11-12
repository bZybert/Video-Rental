using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoRental.Dtos;
using VideoRental.Models;

namespace VideoRental.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly EFCContext _context;

        private readonly IMapper _mapper;

        public CustomersController(IMapper mapper)
        {
            _context = new EFCContext();
            _mapper = mapper;
        }

       
        /*
        public CustomersController()
        {
            _context = new EFCContext();
           
        }*/

        


        // ------------------------------------------------
        [HttpGet]
        public ActionResult<List<CustomerDbo>> GetAllCustomers()
        {
            var customers = _context.Customers.ToList();
            //return _context.Customers.ToList();
           // return _mapper.Map<CustomerDto>();
           return Ok(_mapper.Map<IEnumerable<CustomerDbo>>(customers));
        }

        [HttpGet("{id}", Name = "Customers")]
        public ActionResult<CustomerDbo> GetCustomerById(long id)
        {
            
            var item = _context.Customers.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CustomerDbo>(item));
        }

        [HttpPost]
        public ActionResult<CustomerDbo> CreateCustomer(CustomerDbo customerDTO)
        {
            var customer = _mapper.Map<CustomerDbo, Customer>(customerDTO);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.Id = customer.Id;
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, CustomerDbo item)
        {
            var customerInDb = _context.Customers.SingleOrDefault(x => x.Id == id);

            if (customerInDb == null)
            {
                return NotFound();
            }

            _mapper.Map<CustomerDbo, Customer>(item, customerInDb);

            /*customer.Name = item.Name;
            customer.BirthDate = item.BirthDate;
            customer.IsSubscribedToNewsletter = item.IsSubscribedToNewsletter;
            customer.MembershipTypeId = item.MembershipTypeId; */

            _context.Customers.Update(customerInDb);
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


