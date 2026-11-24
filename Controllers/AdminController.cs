using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextStepMVC.Repositories.Interfaces;

namespace NextStepMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IOpportunityRepository _repository;

        public AdminController(IOpportunityRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var opportunities = _repository.GetAll();

            return View(opportunities);
        }
    }
}
