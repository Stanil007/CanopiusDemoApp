using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CanopiusDemoApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerRepository customerRepository;

        public CustomerController(CustomerRepository _customerRepository)
        {
            customerRepository = _customerRepository;
        }

        public IActionResult All()
        {
            try
            {
                var allCustomers = customerRepository.GetAll();
                return View(allCustomers);
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while fetching all customers");
            }
        }

        public IActionResult GetById(int id)
        {
            try
            {
                var customer = customerRepository.GetById(id);
                return View(customer);
            }
            catch (Exception)
            {
                throw new Exception($"An error occurred while fetching customer with id {id}");
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            try
            {
                customerRepository.Add(customer);
                return RedirectToAction("All");
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while adding customer");
            }
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                var customer = customerRepository.GetById(id);
                return View(customer);
            }
            catch (Exception)
            {
                throw new Exception($"An error occurred while fetching customer with id {id}");
            }
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            try
            {
                customerRepository.Update(customer);
                return RedirectToAction("All");
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while updating customer");
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                customerRepository.Delete(id);
                return RedirectToAction("All");
            }
            catch (Exception)
            {
                throw new Exception($"An error occurred while deleting customer with id {id}");
            }
        }
    }
}
