using FRIDGamE.Areas.Identity.Data;
using FRIDGamE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Entity;
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
        public IActionResult Account()
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