using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectImage.Models;

namespace ProjectImage.Controllers
{
    public class TtaPostsController : Controller
    {
        private readonly DemoTranTienAnh2310900005Context _context;

        public TtaPostsController(DemoTranTienAnh2310900005Context context)
        {
            _context = context;
        }

        // GET: TtaPosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.TtaPosts.ToListAsync());
        }

        // GET: TtaPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var ttaPost = await _context.TtaPosts.FirstOrDefaultAsync(m => m.Id == id);
            if (ttaPost == null)
                return NotFound();

            return View(ttaPost);
        }

        // GET: TtaPosts/Create
        public IActionResult Create()
        {
            LoadImageList();
            return View();
        }

        // POST: TtaPosts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Image,Content,Status")] TtaPost ttaPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ttaPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            LoadImageList(); // cần nếu có lỗi nhập liệu
            return View(ttaPost);
        }

        // GET: TtaPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var ttaPost = await _context.TtaPosts.FindAsync(id);
            if (ttaPost == null)
                return NotFound();

            LoadImageList();
            return View(ttaPost);
        }

        // POST: TtaPosts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Image,Content,Status")] TtaPost ttaPost)
        {
            if (id != ttaPost.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ttaPost);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TtaPostExists(ttaPost.Id))
                        return NotFound();
                    else
                        throw;
                }
            }

            LoadImageList(); // nạp lại ảnh nếu có lỗi nhập
            return View(ttaPost);
        }

        // GET: TtaPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var ttaPost = await _context.TtaPosts.FirstOrDefaultAsync(m => m.Id == id);
            if (ttaPost == null)
                return NotFound();

            return View(ttaPost);
        }

        // POST: TtaPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ttaPost = await _context.TtaPosts.FindAsync(id);
            if (ttaPost != null)
            {
                _context.TtaPosts.Remove(ttaPost);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TtaPostExists(int id)
        {
            return _context.TtaPosts.Any(e => e.Id == id);
        }

        /// <summary>
        /// Lấy danh sách ảnh trong thư mục wwwroot/images và truyền vào ViewBag.Images
        /// </summary>
        private void LoadImageList()
        {
            var imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            if (Directory.Exists(imageFolderPath))
            {
                var imageFiles = Directory.GetFiles(imageFolderPath)
                    .Select(Path.GetFileName)
                    .ToList();

                ViewBag.Images = imageFiles;
            }
            else
            {
                ViewBag.Images = new List<string>();
            }
        }
    }
}
