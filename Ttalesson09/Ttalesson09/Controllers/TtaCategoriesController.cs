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
    public class TtaCategoriesController : Controller
    {
        private readonly TtaBookContext _context;

        public TtaCategoriesController(TtaBookContext context)
        {
            _context = context;
        }

        // GET: TtaCategories
        public async Task<IActionResult> TtaIndex(string keyword)
        {
            var categories = _context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                categories = categories.Where(c => c.CategoryName.Contains(keyword));
            }

            return View(await categories.OrderBy(c => c.CategoryId).ToListAsync());
        }


        // GET: TtaCategories/Details/5
        public async Task<IActionResult> TtaDetails(int? TtaId)
        {
            if (TtaId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == TtaId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: TtaCategories/Create
        public IActionResult TtaCreate()
        {
            return View();
        }

        // POST: TtaCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TtaCreate([Bind("CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(TtaIndex));
            }
            return View(category);
        }

        // GET: TtaCategories/Edit/5
        public async Task<IActionResult> TtaEdit(int? TtaId)
        {
            if (TtaId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(TtaId);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: TtaCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TtaEdit(int TtaId, [Bind("CategoryId,CategoryName")] Category category)
        {
            if (TtaId != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
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
            return View(category);
        }

        // GET: TtaCategories/Delete/5
        public async Task<IActionResult> TtaDelete(int? TtaId)
        {
            if (TtaId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == TtaId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: TtaCategories/Delete/5
        [HttpPost, ActionName("TtaDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TtaDeleteConfirmed(int TtaId)
        {
            var category = await _context.Categories.FindAsync(TtaId);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(TtaIndex));
        }

        private bool CategoryExists(int TtaId)
        {
            return _context.Categories.Any(e => e.CategoryId == TtaId);
        }
    }
}
