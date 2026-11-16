
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NextStepMVC.Data;
using System.Linq;

namespace NextStepMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var opportunities = _context.Opportunities.ToList();

            return View(opportunities);
        }
    }
}
