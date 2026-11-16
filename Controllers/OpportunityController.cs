using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextStepMVC.Data;
using NextStepMVC.Models;
using System.Linq;

namespace NextStepMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OpportunityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpportunityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display all opportunities
        public IActionResult Index()
        {
            var opportunities = _context.Opportunities.ToList();

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
                _context.Opportunities.Add(opportunity);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(opportunity);
        }

        // Open the Edit Opportunity form
        public IActionResult Edit(int id)
        {
            var opportunity = _context.Opportunities.Find(id);

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
                _context.Opportunities.Update(opportunity);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(opportunity);
        }

        // Delete an opportunity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var opportunity = _context.Opportunities.Find(id);

            if (opportunity == null)
            {
                return NotFound();
            }

            _context.Opportunities.Remove(opportunity);

            _context.SaveChanges();

            return RedirectToAction("Index", "Admin");
        }

    }
}
