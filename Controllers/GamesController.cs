using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FRIDGamE.Areas.Identity.Data;
using FRIDGamE.Models;
using Microsoft.AspNetCore.Authorization;

namespace FRIDGamE.Controllers
{
    public class GamesController : Controller
    {
        private readonly IdentityContext _context;

        public GamesController(IdentityContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var identityContext = _context.Games.Include(g => g.GamePublisher).Include(g => g.Studio);
            return View(await identityContext.ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.GamePublisher)
                .Include(g => g.Studio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["GamePublisherId"] = new SelectList(_context.Publishers, "Id", "PublisherName");
            ViewData["StudioId"] = new SelectList(_context.Developers, "Id", "DeveloperName");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameName,StudioId,GamePublisherId,Description,RegularPrice,ReleaseDate")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GamePublisherId"] = new SelectList(_context.Publishers, "Id", "PublisherName", game.GamePublisherId);
            ViewData["StudioId"] = new SelectList(_context.Developers, "Id", "DeveloperName", game.StudioId);
            return View(game);
        }

        // GET: Games/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            ViewData["GamePublisherId"] = new SelectList(_context.Publishers, "Id", "PublisherName", game.GamePublisherId);
            ViewData["StudioId"] = new SelectList(_context.Developers, "Id", "DeveloperName", game.StudioId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameName,StudioId,GamePublisherId,Description,RegularPrice,ReleaseDate")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GamePublisherId"] = new SelectList(_context.Publishers, "Id", "PublisherName", game.GamePublisherId);
            ViewData["StudioId"] = new SelectList(_context.Developers, "Id", "DeveloperName", game.StudioId);
            return View(game);
        }

        // GET: Games/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.GamePublisher)
                .Include(g => g.Studio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Games == null)
            {
                return Problem("Entity set 'IdentityContext.Games'  is null.");
            }
            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                _context.Games.Remove(game);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Buy(int? id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.GamePublisher)
                .Include(g => g.Studio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        public IActionResult BuyConfirmed(int gameId, Guid userId)
        {
            if (_context.Games == null)
            {
                return Problem("Entity set 'IdentityContext.Games'  is null.");
            }
            Game? game = _context.Games.Find(gameId);
            Customer? user = _context.Customer.Find(userId);
            if (user == null || game == null)
            {
                return NotFound();
            }
            user.Games.Add(game);
            _context.Update(user);
            _context.SaveChanges();
            return View();
        }


        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
