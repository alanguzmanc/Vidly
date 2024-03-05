using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
           // IEnumerable<Customer> customers = _context.Customers.Include(c=> c.MembershipType) .ToList();           

            return View();
        }

        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=> c.MembershipType).SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }


        public IActionResult CustomerForm(int Id) 
        {

            var viewModel = new CustomerFormViewModel();
            var membershipTypes = _context.MembershipType.ToList();
            //viewModel.MembershipTypes = _context.MembershipType.ToList();
            if (Id == 0)
            {
                viewModel = new CustomerFormViewModel(new Customer(), membershipTypes);
                //viewModel.Customer = new Customer();
                
            }
            else
            {
                viewModel = new CustomerFormViewModel(_context.Customers.Single(c => c.Id == Id), membershipTypes);
                //viewModel.Customer = _context.Customers.Single(c=> c.Id == Id);
               
            }
            return View("CustomerForm", viewModel);

        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(CustomerFormViewModel model)
        {

            var viewModel = new CustomerFormViewModel();
            var membershipTypes = _context.MembershipType.ToList();

            var customer = new Customer()
            {
                Id = model.Id.GetValueOrDefault(),
                Name = model.Name,
                Birthdate = model.Birthdate,
                MembershipTypeId= model.MembershipTypeId.GetValueOrDefault(),
                IsSubscribeToNewsletter = model.IsSubscribeToNewsletter,
            };


            if (!ModelState.IsValid)
            {
                return View("modelForm", new CustomerFormViewModel(customer, membershipTypes));
            }
            

            if (model.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var existingCustomer = _context.Customers.Single(c=> c.Id== model.Id);

                existingCustomer.Name= model.Name;
                existingCustomer.Birthdate= model.Birthdate;
                existingCustomer.MembershipTypeId = model.MembershipTypeId.GetValueOrDefault();
                existingCustomer.IsSubscribeToNewsletter = model.IsSubscribeToNewsletter;

                
            }           
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }

       
       

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
