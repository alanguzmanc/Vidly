using Humanizer.Localisation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //GET/api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Customer>> GetCustomer(int id)
        //{
        //    var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);

        //    if (customer == null)
        //        return NotFound();

        //    return customer;
        //}

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer =  _context.Customers.Include(c=> c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
               return NotFound();

            return customer;
        }


        //POST /api/customers
        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }


        //PUT/api/customers/1
        [HttpPut]
        public ActionResult<Customer> UpdateCustomer(int id,Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != customer.Id)
            {
                return BadRequest();
            }


            if (!_context.Customers.Any(c => c.Id == id))
            {
                return NotFound();
            }

            _context.Entry(customer).State = EntityState.Modified;
            
            //_context.Customers.Update(customer);
            _context.SaveChanges();
            return customer;
        }


        //Delete/api/customers/1
        [HttpDelete]
        public ActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c=>c.Id == id);

            if (customer == null) return NotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
