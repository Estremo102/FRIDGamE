﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FRIDGamE.Areas.Identity.Data;
using FRIDGamE.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace FRIDGamE.Controllers
{
    public class PromotionsController : Controller
    {
        private readonly IdentityContext _context;

        public PromotionsController(IdentityContext context)
        {
            _context = context;
        }

        // GET: Promotions
        public async Task<IActionResult> Index()
        {
            var identityContext = _context.Promotion.Include(p => p.GameName);
            return View(await identityContext.ToListAsync());
        }

        // GET: Promotions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Promotion == null)
            {
                return NotFound();
            }

            var promotion = await _context.Promotion
                .Include(p => p.GameName)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promotion == null)
            {
                return NotFound();
            }

            return View(promotion);
        }

        // GET: Promotions/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["GameNameId"] = new SelectList(_context.Games, "Id", "GameName");
            return View();
        }

        // POST: Promotions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameNameId,Discount,StartOfPromotion,EndOfPromotion")] Promotion promotion)
        {
            promotion.RegularPrice = _context.Games.Find(promotion.GameNameId).RegularPrice;
            var promotions = _context.Promotion.ToList();
            if (promotion.StartOfPromotion is null)
            {
                promotion.StartOfPromotion = DateTime.Now;
            }
            foreach (var p in promotions)
            {
                if(p.GameNameId == promotion.GameNameId &&
                    promotion.EndOfPromotion > p.StartOfPromotion &&
                    promotion.StartOfPromotion < p.EndOfPromotion)
                {
                    ViewData["GameNameId"] = new SelectList(_context.Games, "Id", "GameName", promotion.GameNameId);
                    ViewData["Success"] = false;
                    ViewData["Error"] = "1";
                    return View(promotion);
                }
            }
            if(promotion.StartOfPromotion > promotion.EndOfPromotion)
            {
                ViewData["GameNameId"] = new SelectList(_context.Games, "Id", "GameName", promotion.GameNameId);
                ViewData["Success"] = false;
                ViewData["Error"] = "2";
                return View(promotion);
            }
            if (ModelState.IsValid)
            {
                _context.Add(promotion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameNameId"] = new SelectList(_context.Games, "Id", "GameName", promotion.GameNameId);
            ViewData["Success"] = true;
            return View(promotion);
        }

        // GET: Promotions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Promotion == null)
            {
                return NotFound();
            }

            var promotion = await _context.Promotion.FindAsync(id);
            if (promotion == null)
            {
                return NotFound();
            }
            ViewData["GameNameId"] = new SelectList(_context.Games, "Id", "GameName", promotion.GameNameId);
            return View(promotion);
        }

        // POST: Promotions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameNameId,Discount,StartOfPromotion,EndOfPromotion")] Promotion promotion)
        {
            promotion.RegularPrice = _context.Games.Find(promotion.GameNameId).RegularPrice;
            if (id != promotion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promotion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromotionExists(promotion.Id))
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
            ViewData["GameNameId"] = new SelectList(_context.Games, "Id", "GameName", promotion.GameNameId);
            return View(promotion);
        }

        // GET: Promotions/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Promotion == null)
            {
                return NotFound();
            }

            var promotion = await _context.Promotion
                .Include(p => p.GameName)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promotion == null)
            {
                return NotFound();
            }

            return View(promotion);
        }

        // POST: Promotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Promotion == null)
            {
                return Problem("Entity set 'IdentityContext.Promotion'  is null.");
            }
            var promotion = await _context.Promotion.FindAsync(id);
            if (promotion != null)
            {
                _context.Promotion.Remove(promotion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromotionExists(int id)
        {
            return _context.Promotion.Any(e => e.Id == id);
        }
    }
}
