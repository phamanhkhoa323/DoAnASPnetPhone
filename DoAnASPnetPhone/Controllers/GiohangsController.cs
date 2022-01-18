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
    public class GiohangsController : Controller
    {
        private readonly DoAnASPnetPhoneContext _context;

        public GiohangsController(DoAnASPnetPhoneContext context)
        {
            _context = context;
        }

        // GET: Giohangs
        public async Task<IActionResult> Index()
        {
            var doAnASPnetPhoneContext = _context.Giohang.Include(g => g.Nguoidung).Include(g => g.Sanpham);
            return View(await doAnASPnetPhoneContext.ToListAsync());
        }

        // GET: Giohangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giohang = await _context.Giohang
                .Include(g => g.Nguoidung)
                .Include(g => g.Sanpham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giohang == null)
            {
                return NotFound();
            }

            return View(giohang);
        }

        // GET: Giohangs/Create
        public IActionResult Create()
        {
            ViewData["NguoidungId"] = new SelectList(_context.Nguoidung, "Id", "Email");
            ViewData["SanphamId"] = new SelectList(_context.Sanpham, "Id", "Id");
            return View();
        }

        // POST: Giohangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NguoidungId,SanphamId,SoLuongMua")] Giohang giohang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giohang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NguoidungId"] = new SelectList(_context.Nguoidung, "Id", "Email", giohang.NguoidungId);
            ViewData["SanphamId"] = new SelectList(_context.Sanpham, "Id", "Id", giohang.SanphamId);
            return View(giohang);
        }

        // GET: Giohangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giohang = await _context.Giohang.FindAsync(id);
            if (giohang == null)
            {
                return NotFound();
            }
            ViewData["NguoidungId"] = new SelectList(_context.Nguoidung, "Id", "Email", giohang.NguoidungId);
            ViewData["SanphamId"] = new SelectList(_context.Sanpham, "Id", "Id", giohang.SanphamId);
            return View(giohang);
        }

        // POST: Giohangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NguoidungId,SanphamId,SoLuongMua")] Giohang giohang)
        {
            if (id != giohang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giohang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiohangExists(giohang.Id))
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
            ViewData["NguoidungId"] = new SelectList(_context.Nguoidung, "Id", "Email", giohang.NguoidungId);
            ViewData["SanphamId"] = new SelectList(_context.Sanpham, "Id", "Id", giohang.SanphamId);
            return View(giohang);
        }

        // GET: Giohangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giohang = await _context.Giohang
                .Include(g => g.Nguoidung)
                .Include(g => g.Sanpham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giohang == null)
            {
                return NotFound();
            }

            return View(giohang);
        }

        // POST: Giohangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giohang = await _context.Giohang.FindAsync(id);
            _context.Giohang.Remove(giohang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiohangExists(int id)
        {
            return _context.Giohang.Any(e => e.Id == id);
        }
    }
}
