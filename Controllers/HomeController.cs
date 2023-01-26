using FRIDGamE.Areas.Identity.Data;
using FRIDGamE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;

namespace FRIDGamE.Controllers
{
    public class HomeController : Controller
    {
        private readonly IdentityContext _context;

        public HomeController(IdentityContext context)
        {
            _context = context;
        }

        // GET: News
        public IActionResult Index()
        {
            var identityContext = _context.News.Include(n => n.Author);
            return View(identityContext.ToList());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        // GET: News/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = _context.News
                .Include(n => n.Author)
                .FirstOrDefault(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        [Authorize]
        public IActionResult Account(string? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }
            //var customer = _context.Customer.Include(c => c.Games).First(c => c.CustomerId == Guid.Parse(id));
            //var customer = customers.FirstOrDefault(c => c.CustomerId == Guid.Parse(id));
            //customer.Games.Add(new Game() { GameName = "ABCD" });
            //var account = _context.Customer.Include(c => c.Games).ToList();
            //var customer = account.First(c => c.CustomerId == Guid.Parse(id));
            var customer = _context.Customer.Find(Guid.Parse(id));
            ViewData["Games"] = _context.Library(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [Authorize]
        public IActionResult Payment(string? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var news = _context.Customer.Find(Guid.Parse(id));
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Payment(Guid id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }
            var cust2 = _context.Customer.Find(id);
            cust2.Balance += customer.Balance;
            if (ModelState.IsValid)
            {
                _context.Customer.Update(cust2);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}