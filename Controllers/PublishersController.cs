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
using System.Data;

namespace FRIDGamE.Controllers
{
    public class PublishersController : Controller
    {
        //private readonly IdentityContext _context;
        private readonly IPublisherService _publisherService;

        public PublishersController(IdentityContext context, IPublisherService publisherService)
        {
            //_context = context;
            _publisherService = publisherService;
        }

        // GET: Publishers
        [Authorize(Roles = "Admin")]
        public IActionResult Index() => View(_publisherService.FindAll());

        // GET: Publishers/Details/5
        public IActionResult Details(int? id)
        {
            var publisher = _publisherService.FindById(id);
            if (publisher is null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // GET: Publishers/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PublisherName,NIP")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _publisherService.Save(publisher);
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: Publishers/Edit/5
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null || _publisherService.FindById(id) is null)
            {
                return NotFound();
            }

            var publisher = _publisherService.FindById(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // POST: Publishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,PublisherName,NIP")] Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _publisherService.Update(publisher);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherExists(publisher.Id))
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
            return View(publisher);
        }

        // GET: Publishers/Delete/5
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null || _publisherService.FindById(id) == null)
            {
                return NotFound();
            }

            var publisher = _publisherService.FindById(id);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_publisherService.FindById(id) == null)
            {
                return Problem("Entity set 'IdentityContext.Publishers'  is null.");
            }
            _publisherService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PublisherExists(int id) => _publisherService.FindById(id) != null;
    }
}
