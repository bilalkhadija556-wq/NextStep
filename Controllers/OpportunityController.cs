using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextStepMVC.Models;
using NextStepMVC.Repositories.Interfaces;

namespace NextStepMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OpportunityController : Controller
    {
        private readonly IOpportunityRepository _repository;

        public OpportunityController(IOpportunityRepository repository)
        {
            _repository = repository;
        }

        // Display all opportunities
        public IActionResult Index()
        {
            var opportunities = _repository.GetAll();

            return View(opportunities);
        }

        // Open the Add Opportunity form
        public IActionResult Create(string type)
        {
            Opportunity opportunity = new Opportunity();

            opportunity.Type = type;

            return View(opportunity);
        }

        // Save the new opportunity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(opportunity);

                return RedirectToAction("Index");
            }

            return View(opportunity);
        }

        // Open the Edit Opportunity form
        public IActionResult Edit(int id)
        {
            var opportunity = _repository.GetById(id);

            if (opportunity == null)
            {
                return NotFound();
            }

            return View(opportunity);
        }

        // Save the updated opportunity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(opportunity);

                return Json(new
                {
                    success = true,
                    message = "Opportunity updated successfully."
                });
            }

            return BadRequest(ModelState);
        }

        // Delete an opportunity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var opportunity = _repository.GetById(id);

            if (opportunity == null)
                return NotFound();

            _repository.Delete(id);

            var opportunities = _repository.GetAll();

            return PartialView("~/Views/Admin/_OpportunityRows.cshtml", opportunities);
        }
    }
}
