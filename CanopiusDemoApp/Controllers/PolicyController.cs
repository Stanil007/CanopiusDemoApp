﻿using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CanopiusDemoApp.Controllers
{
    public class PolicyController : Controller
    {

        private readonly PolicyRepository policyRepository;

        public PolicyController(PolicyRepository _policyRepository)
        {
             policyRepository = _policyRepository;
        }


        [HttpGet]
        public IActionResult All()
        {
            try
            {
                var allPolicies = policyRepository.GetAll();
                return View(allPolicies);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching all policies: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                var policy = policyRepository.GetById(id);
                return View(policy);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching policy with id {id}: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Add(Policy policy)
        {
            try
            {
                policyRepository.Add(policy);
                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding policy: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                var policy = policyRepository.GetById(id);
                return View(policy);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching policy with id {id}: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Update(Policy policy)
        {
            try
            {
                policyRepository.Update(policy);
                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating policy: {ex.Message}");
            }
        }


        public IActionResult Delete(int id)
        {
            try
            {
                policyRepository.Delete(id);
                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting policy with id {id}: {ex.Message}");
            }
        }
    }
}
