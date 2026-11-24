using Microsoft.AspNetCore.Mvc;
using NextStepMVC.Repositories.Interfaces;

namespace NextStepMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IOpportunityRepository _repository;

        public StudentController(IOpportunityRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(string search)
        {
            var opportunities = _repository.Search(search);

            return View(opportunities);
        }
        [HttpGet]
        public IActionResult Search(string search)
        {
            var opportunities = _repository.Search(search);

            return PartialView("_OpportunityResults", opportunities);
        }
    }
}
