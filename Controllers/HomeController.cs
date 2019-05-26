using System.Diagnostics;
using System.Linq;
using AspNetCoreMiniProfiler.Data;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMiniProfiler.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMiniProfiler.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _db;
        public HomeController(DataContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
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

        public IActionResult Products()
        {
            var products = _db.Products.ToList();
            return View(products);
        }

        public IActionResult Clients()
        {
            var clients = _db.Clients.ToList();

            return View(clients);
        }

        public IActionResult ProductClients(int id)
        {
            var clientProducts = _db.ClientProducts
                .Include(x => x.Client)
                .Include(x => x.Product)
                .Where(x => x.ClientId == id)
                .ToList();

            return View(clientProducts);
        }
    }
}
