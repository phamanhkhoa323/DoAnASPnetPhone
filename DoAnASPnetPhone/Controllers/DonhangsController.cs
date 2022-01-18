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
    public class DonhangsController : Controller
    {
        private readonly DoAnASPnetPhoneContext _context;

        public DonhangsController(DoAnASPnetPhoneContext context)
        {
            _context = context;
        }

        // GET: Donhangs
        public async Task<IActionResult> Index()
        {
            var doAnASPnetPhoneContext = _context.Donhang.Include(d => d.Nguoidung);
            return View(await doAnASPnetPhoneContext.ToListAsync());
        }

        // GET: Donhangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhang = await _context.Donhang
                .Include(d => d.Nguoidung)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donhang == null)
            {
                return NotFound();
            }

            return View(donhang);
        }

        // GET: Donhangs/Create
        public IActionResult Create()
        {
            ViewData["NguoidungId"] = new SelectList(_context.Nguoidung, "Id", "Email");
            return View();
        }

        // POST: Donhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Madon,Ngaydat,Tinhtrang,NguoidungId,Tongtien")] Donhang donhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NguoidungId"] = new SelectList(_context.Nguoidung, "Id", "Email", donhang.NguoidungId);
            return View(donhang);
        }

        // GET: Donhangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhang = await _context.Donhang.FindAsync(id);
            if (donhang == null)
            {
                return NotFound();
            }
            ViewData["NguoidungId"] = new SelectList(_context.Nguoidung, "Id", "Email", donhang.NguoidungId);
            return View(donhang);
        }

        // POST: Donhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Madon,Ngaydat,Tinhtrang,NguoidungId,Tongtien")] Donhang donhang)
        {
            if (id != donhang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonhangExists(donhang.Id))
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
            ViewData["NguoidungId"] = new SelectList(_context.Nguoidung, "Id", "Email", donhang.NguoidungId);
            return View(donhang);
        }

        // GET: Donhangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhang = await _context.Donhang
                .Include(d => d.Nguoidung)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donhang == null)
            {
                return NotFound();
            }

            return View(donhang);
        }

        // POST: Donhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donhang = await _context.Donhang.FindAsync(id);
            _context.Donhang.Remove(donhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonhangExists(int id)
        {
            return _context.Donhang.Any(e => e.Id == id);
        }
    }
}
