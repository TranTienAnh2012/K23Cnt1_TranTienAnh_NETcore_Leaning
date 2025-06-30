using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TtaLesson11.Models;

namespace TtaLesson11.Controllers
{
    public class TtaEmployeesController : Controller
    {
        private readonly DemoTranTienAnh2310900005Context _context;

        public TtaEmployeesController(DemoTranTienAnh2310900005Context context)
        {
            _context = context;
        }

        // GET: TtaEmployees
        public async Task<IActionResult> TtaIndex()
        {
            return View(await _context.TtaEmployees.ToListAsync());
        }

        // GET: TtaEmployees/Details/5
        public async Task<IActionResult> TtaDetails(int? Ttaid)
        {
            if (Ttaid == null)
            {
                return NotFound();
            }

            var ttaEmployee = await _context.TtaEmployees
                .FirstOrDefaultAsync(m => m.TtaEmpId == Ttaid);
            if (ttaEmployee == null)
            {
                return NotFound();
            }

            return View(ttaEmployee);
        }

        // GET: TtaEmployees/Create
        public IActionResult TtaCreate()
        {
            return View();
        }

        // POST: TtaEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TtaCreate([Bind("TtaEmpId,TtaEmpName,TtaEmpLevel,TtaEmpStartDate,TtaEmpStatus")] TtaEmployee ttaEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ttaEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(TtaIndex));
            }
            return View(ttaEmployee);
        }

        // GET: TtaEmployees/Edit/5
        public async Task<IActionResult> TtaEdit(int? Ttaid)
        {
            if (Ttaid == null)
            {
                return NotFound();
            }

            var ttaEmployee = await _context.TtaEmployees.FindAsync(Ttaid);
            if (ttaEmployee == null)
            {
                return NotFound();
            }
            return View(ttaEmployee);
        }

        // POST: TtaEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TtaEdit(int Ttaid, [Bind("TtaEmpId,TtaEmpName,TtaEmpLevel,TtaEmpStartDate,TtaEmpStatus")] TtaEmployee ttaEmployee)
        {
            if (Ttaid != ttaEmployee.TtaEmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ttaEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TtaEmployeeExists(ttaEmployee.TtaEmpId))
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
            return View(ttaEmployee);
        }

        // GET: TtaEmployees/Delete/5
        public async Task<IActionResult> TtaDelete(int? Ttaid)
        {
            if (Ttaid == null)
            {
                return NotFound();
            }

            var ttaEmployee = await _context.TtaEmployees
                .FirstOrDefaultAsync(m => m.TtaEmpId == Ttaid);
            if (ttaEmployee == null)
            {
                return NotFound();
            }

            return View(ttaEmployee);
        }

        // POST: TtaEmployees/Delete/5
        [HttpPost, ActionName("TtaDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TtaDeleteConfirmed(int Ttaid)
        {
            var ttaEmployee = await _context.TtaEmployees.FindAsync(Ttaid);
            if (ttaEmployee != null)
            {
                _context.TtaEmployees.Remove(ttaEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(TtaIndex));
        }

        private bool TtaEmployeeExists(int Ttaid)
        {
            return _context.TtaEmployees.Any(e => e.TtaEmpId == Ttaid);
        }
    }
}
