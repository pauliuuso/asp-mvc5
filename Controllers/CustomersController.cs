using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aspnet.Models;
using aspnet.ViewModels;
using System.Data.Entity;

namespace aspnet.Controllers
{
    public class CustomersController: Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult AddCustomer()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("EditOrAddUser", viewModel);
        }

        [HttpPost]
        public ActionResult CreateCustomer(Customer customer)
        {
            if(customer.id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.id == customer.id);
                customerInDb.name = customer.name;
                customerInDb.birthday = customer.birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.isSubscribedToNewsLetter = customer.isSubscribedToNewsLetter;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        [Route("customers/edit/{id}")]
        public ActionResult EditCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("EditOrAddUser", viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("customers/details/{id}")]
        public ActionResult SingleCustomer(int id)
        {
            var customers = _context.Customers.Include(mtype => mtype.MembershipType).SingleOrDefault(cust => cust.id == id);

            if(customers == null)
            {
                return HttpNotFound();
            }

            return View(customers);

        }

    }
}