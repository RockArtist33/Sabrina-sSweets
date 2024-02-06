using Microsoft.AspNetCore.Mvc;
using SabrinaSweets.Data;
using SabrinaSweets.Models;
using SabrinaSweets.Models.ViewModels;
using System.Diagnostics;

namespace SabrinaSweets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context= context;
        }

        public IActionResult Index()
        {
            var ViewModelShop_ = new ViewModelShop();
            ViewModelShop_.ShoppingCategories = _context.ShoppingCategory.Where(modelItem => modelItem.Id >= 0).ToList();
            ViewModelShop_.ShoppingItems = _context.ShoppingItems.Where(modelItem => modelItem.ShoppingItemId >= 0).ToList();
            return View(ViewModelShop_);
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