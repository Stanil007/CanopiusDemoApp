using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CanopiusDemoApp.Controllers
{
    public class PaymentController : Controller
    {

        private readonly PaymentRepository paymentRepository;
        private readonly PolicyRepository policyRepository;
        private readonly ClaimRepository claimRepository;

        public PaymentController(PaymentRepository _paymentRepository,
                                 PolicyRepository _policyRepository, 
                                 ClaimRepository _claimRepository)
        {
            paymentRepository = _paymentRepository;
            policyRepository = _policyRepository;
            claimRepository = _claimRepository; 

        }

        [HttpGet]   
        public IActionResult All()
        {
            try
            {
                var payments = paymentRepository.GetAll();
                return View(payments);
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while fetching all payments");
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                var payment = paymentRepository.GetById(id);
                return View(payment);
            }
            catch (Exception)
            {
                throw new Exception($"An error occurred while fetching payment with id {id}");
            }
        }


        [HttpGet]
        public IActionResult Add()
        {
            var allPolicies = policyRepository.GetAll();
            var allClaims = claimRepository.GetAll();

            ViewBag.Policies = new SelectList(allPolicies, "Id", "PolicyType");
            ViewBag.Claims = new SelectList(allClaims, "Id", "ClaimAmount"); 

            return View();
        }

        [HttpPost]
        public IActionResult Add(Payment payment)
        {
            try
            {
                paymentRepository.Add(payment);
                return RedirectToAction("All");
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while adding payment");
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                var payment = paymentRepository.GetById(id);
                return View(payment);
            }
            catch (Exception)
            {
                throw new Exception($"An error occurred while fetching payment with id {id}");
            }
        }

        [HttpPost]
        public IActionResult Update(Payment payment)
        {
            try
            {
                paymentRepository.Update(payment);
                return RedirectToAction("All");
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while updating payment");
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                paymentRepository.Delete(id);
                return RedirectToAction("All");
            }
            catch (Exception)
            {
                throw new Exception($"An error occurred while deleting payment with id {id}");
            }
        }

    }
}
