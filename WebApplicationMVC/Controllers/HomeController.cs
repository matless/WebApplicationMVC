using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationMVC.Data;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }
        [Authorize]
        public IActionResult Index()
        {
            var items = dbContext.WorkItems.ToList();
            return View(items);
        }
        [Authorize(Roles = "Admin")]
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