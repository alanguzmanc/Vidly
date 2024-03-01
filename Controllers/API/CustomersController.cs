using Humanizer.Localisation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Dtos;
using Vidly.Models;
using AutoMapper;

namespace Vidly.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        //GET/api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(_mapper.Map<Customer,CustomerDto>);
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
        public ActionResult<CustomerDto> GetCustomer(int id)
        {
            var customer =  _context.Customers.Include(c=> c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
               return NotFound();

            return _mapper.Map<Customer,CustomerDto>(customer);
        }


        //POST /api/customers
        [HttpPost]
        public ActionResult<CustomerDto> PostCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);


            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(Request.Path + "/" + customerDto.Id, customerDto);
            //return customerDto;
        }


        //PUT/api/customers/1
        [HttpPut("{id}")]
        public ActionResult<CustomerDto> PutCustomer(int id,CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != customerDto.Id)
            {
                return BadRequest();
            }


            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDB == null)
            {
                return NotFound();
            }

            _mapper.Map<CustomerDto, Customer>(customerDto, customerInDB);

            //_context.Entry(customerInDB).State = EntityState.Modified;            
            //_context.Customers.Update(customer);
            _context.SaveChanges();
            return customerDto;
        }


        //Delete/api/customers/1
        [HttpDelete("{id}")]
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
