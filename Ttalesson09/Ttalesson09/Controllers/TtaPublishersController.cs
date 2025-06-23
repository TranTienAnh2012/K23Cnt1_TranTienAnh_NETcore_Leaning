using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ttalesson09.Models;

namespace Ttalesson09.Controllers
{
    public class TtaPublishersController : Controller
    {
        private readonly TtaBookContext _context;

        public TtaPublishersController(TtaBookContext context)
        {
            _context = context;
        }

        // GET: TtaPublishers
       // GET: TtaPublishers
    public async Task<IActionResult> TtaIndex(string keywordPub)
    {
        var publishers = _context.Publishers.AsQueryable();

        if (!string.IsNullOrEmpty(keywordPub))
        {
            publishers = publishers.Where(p => p.PublisherName.Contains(keywordPub));
        }

        return View(await publishers.ToListAsync());
    }


        // GET: TtaPublishers/Details/5
        public async Task<IActionResult> TtaDetails(int? TtaId)
        {
            if (TtaId == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == TtaId);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // GET: TtaPublishers/Create
        public IActionResult TtaCreate()
        {
            return View();
        }

        // POST: TtaPublishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TtaCreate([Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publisher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(TtaIndex));
            }
            return View(publisher);
        }

        // GET: TtaPublishers/Edit/5
        public async Task<IActionResult> TtaEdit(int? TtaId)
        {
            if (TtaId == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers.FindAsync(TtaId);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // POST: TtaPublishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TtaEdit(int TtaId, [Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (TtaId != publisher.PublisherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publisher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherExists(publisher.PublisherId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(TtaIndex));
            }
            return View(publisher);
        }

        // GET: TtaPublishers/Delete/5
        public async Task<IActionResult> TtaDelete(int? TtaId)
        {
            if (TtaId == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == TtaId);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: TtaPublishers/Delete/5
        [HttpPost, ActionName("TtaDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TtaDeleteConfirmed(int TtaId)
        {
            var publisher = await _context.Publishers.FindAsync(TtaId);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(TtaIndex));
        }

        private bool PublisherExists(int TtaId)
        {
            return _context.Publishers.Any(e => e.PublisherId == TtaId);
        }
    }
}
