using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CanopiusDemoApp.Controllers
{
    public class ClaimController : Controller
    {
        private readonly ClaimRepository claimRepository;

        public ClaimController(ClaimRepository _claimRepository)
        {
            claimRepository = _claimRepository;
        }

        [HttpGet]
        public IActionResult All()
        {
            try
            {
                var allClaims = claimRepository.GetAll();
                return View(allClaims);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching all claims: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var claim = claimRepository.GetById(id);
                return View(claim);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching claim with id {id}: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Claim claim)
        {
            try
            {
                claimRepository.Add(claim);
                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding claim: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                var claim = claimRepository.GetById(id);
                return View(claim);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching claim with id {id}: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Update(Claim claim)
        {
            try
            {
                claimRepository.Update(claim);
                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating claim: {ex.Message}");
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                claimRepository.Delete(id);
                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting claim with id {id}: {ex.Message}");
            }
        }
    }
}
