using System.Diagnostics;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Data.ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, Data.ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index1()
        {
            // Group by Department for Pie/Donut Chart
            var departmentStats = _context.Employees
                .GroupBy(e => e.Department)
                .Select(g => new { Label = g.Key, Count = g.Count() })
                .ToList();

            // Group by Designation for Bar/Line Chart
            var positionStats = _context.Employees
                .GroupBy(e => e.Designation)
                .Select(g => new { Label = g.Key, Count = g.Count() })
                .ToList();
            
            ViewBag.DepartmentLabels = departmentStats.Select(d => d.Label).ToArray();
            ViewBag.DepartmentCounts = departmentStats.Select(d => d.Count).ToArray();

            ViewBag.PositionLabels = positionStats.Select(p => p.Label).ToArray();
            ViewBag.PositionCounts = positionStats.Select(p => p.Count).ToArray();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
