using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnASPnetPhone.Data;
using DoAnASPnetPhone.Models;

namespace DoAnASPnetPhone.Controllers
{
    public class ChitietdonhangsController : Controller
    {
        private readonly DoAnASPnetPhoneContext _context;

        public ChitietdonhangsController(DoAnASPnetPhoneContext context)
        {
            _context = context;
        }

        // GET: Chitietdonhangs
        public async Task<IActionResult> Index()
        {
            var doAnASPnetPhoneContext = _context.Chitietdonhang.Include(c => c.Donhang).Include(c => c.Sanpham);
            return View(await doAnASPnetPhoneContext.ToListAsync());
        }

        // GET: Chitietdonhangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietdonhang = await _context.Chitietdonhang
                .Include(c => c.Donhang)
                .Include(c => c.Sanpham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chitietdonhang == null)
            {
                return NotFound();
            }

            return View(chitietdonhang);
        }

        // GET: Chitietdonhangs/Create
        public IActionResult Create()
        {
            ViewData["DonhangId"] = new SelectList(_context.Donhang, "Id", "Madon");
            ViewData["SanphamId"] = new SelectList(_context.Sanpham, "Id", "Tensp");
            return View();
        }

        // POST: Chitietdonhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DonhangId,SanphamId,Soluong,Dongia")] Chitietdonhang chitietdonhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chitietdonhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DonhangId"] = new SelectList(_context.Donhang, "Id", "Madon", chitietdonhang.DonhangId);
            ViewData["SanphamId"] = new SelectList(_context.Sanpham, "Id", "Tensp", chitietdonhang.SanphamId);
            return View(chitietdonhang);
        }

        // GET: Chitietdonhangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietdonhang = await _context.Chitietdonhang.FindAsync(id);
            if (chitietdonhang == null)
            {
                return NotFound();
            }
            ViewData["DonhangId"] = new SelectList(_context.Donhang, "Id", "Madon", chitietdonhang.DonhangId);
            ViewData["SanphamId"] = new SelectList(_context.Sanpham, "Id", "Tensp", chitietdonhang.SanphamId);
            return View(chitietdonhang);
        }

        // POST: Chitietdonhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DonhangId,SanphamId,Soluong,Dongia")] Chitietdonhang chitietdonhang)
        {
            if (id != chitietdonhang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chitietdonhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChitietdonhangExists(chitietdonhang.Id))
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
            ViewData["DonhangId"] = new SelectList(_context.Donhang, "Id", "Madon", chitietdonhang.DonhangId);
            ViewData["SanphamId"] = new SelectList(_context.Sanpham, "Id", "Tensp", chitietdonhang.SanphamId);
            return View(chitietdonhang);
        }

        // GET: Chitietdonhangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietdonhang = await _context.Chitietdonhang
                .Include(c => c.Donhang)
                .Include(c => c.Sanpham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chitietdonhang == null)
            {
                return NotFound();
            }

            return View(chitietdonhang);
        }

        // POST: Chitietdonhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chitietdonhang = await _context.Chitietdonhang.FindAsync(id);
            _context.Chitietdonhang.Remove(chitietdonhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChitietdonhangExists(int id)
        {
            return _context.Chitietdonhang.Any(e => e.Id == id);
        }
    }
}
