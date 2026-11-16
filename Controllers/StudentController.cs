
using Microsoft.AspNetCore.Mvc;
using NextStepMVC.Data;
using System.Linq;

namespace NextStepMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var opportunities = _context.Opportunities.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                opportunities = opportunities.Where(o => o.Title.Contains(search) ||o.Organization.Contains(search)).ToList();
            }

            return View(opportunities);
        }
    }
}
