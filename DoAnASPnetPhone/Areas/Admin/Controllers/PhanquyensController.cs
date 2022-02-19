using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnASPnetPhone.Data;
using DoAnASPnetPhone.Models;

namespace DoAnASPnetPhone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhanquyensController : Controller
    {
        private readonly DoAnASPnetPhoneContext _context;

        public PhanquyensController(DoAnASPnetPhoneContext context)
        {
            _context = context;
        }

        // GET: Admin/Phanquyens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Phanquyen.ToListAsync());
        }

        // GET: Admin/Phanquyens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanquyen = await _context.Phanquyen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phanquyen == null)
            {
                return NotFound();
            }

            return View(phanquyen);
        }

        // GET: Admin/Phanquyens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Phanquyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IDQuyen,Tenquyen")] Phanquyen phanquyen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phanquyen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phanquyen);
        }

        // GET: Admin/Phanquyens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanquyen = await _context.Phanquyen.FindAsync(id);
            if (phanquyen == null)
            {
                return NotFound();
            }
            return View(phanquyen);
        }

        // POST: Admin/Phanquyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IDQuyen,Tenquyen")] Phanquyen phanquyen)
        {
            if (id != phanquyen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phanquyen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhanquyenExists(phanquyen.Id))
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
            return View(phanquyen);
        }

        // GET: Admin/Phanquyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanquyen = await _context.Phanquyen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phanquyen == null)
            {
                return NotFound();
            }

            return View(phanquyen);
        }

        // POST: Admin/Phanquyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phanquyen = await _context.Phanquyen.FindAsync(id);
            _context.Phanquyen.Remove(phanquyen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhanquyenExists(int id)
        {
            return _context.Phanquyen.Any(e => e.Id == id);
        }
    }
}
