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
    public class NguoidungsController : Controller
    {
        private readonly DoAnASPnetPhoneContext _context;

        public NguoidungsController(DoAnASPnetPhoneContext context)
        {
            _context = context;
        }

        // GET: Admin/Nguoidungs
        public async Task<IActionResult> Index()
        {
            var doAnASPnetPhoneContext = _context.Nguoidung.Include(n => n.Phanquyen);
            return View(await doAnASPnetPhoneContext.ToListAsync());
        }

        // GET: Admin/Nguoidungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoidung = await _context.Nguoidung
                .Include(n => n.Phanquyen)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nguoidung == null)
            {
                return NotFound();
            }

            return View(nguoidung);
        }

        // GET: Admin/Nguoidungs/Create
        public IActionResult Create()
        {
            ViewData["PhanquyenId"] = new SelectList(_context.Phanquyen, "Id", "Id");
            return View();
        }

        // POST: Admin/Nguoidungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaNguoiDung,Hoten,Email,Matkhau,Dienthoai,PhanquyenId,Diachi")] Nguoidung nguoidung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguoidung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhanquyenId"] = new SelectList(_context.Phanquyen, "Id", "Id", nguoidung.PhanquyenId);
            return View(nguoidung);
        }

        // GET: Admin/Nguoidungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoidung = await _context.Nguoidung.FindAsync(id);
            if (nguoidung == null)
            {
                return NotFound();
            }
            ViewData["PhanquyenId"] = new SelectList(_context.Phanquyen, "Id", "Id", nguoidung.PhanquyenId);
            return View(nguoidung);
        }

        // POST: Admin/Nguoidungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaNguoiDung,Hoten,Email,Matkhau,Dienthoai,PhanquyenId,Diachi")] Nguoidung nguoidung)
        {
            if (id != nguoidung.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguoidung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguoidungExists(nguoidung.Id))
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
            ViewData["PhanquyenId"] = new SelectList(_context.Phanquyen, "Id", "Id", nguoidung.PhanquyenId);
            return View(nguoidung);
        }

        // GET: Admin/Nguoidungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoidung = await _context.Nguoidung
                .Include(n => n.Phanquyen)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nguoidung == null)
            {
                return NotFound();
            }

            return View(nguoidung);
        }

        // POST: Admin/Nguoidungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nguoidung = await _context.Nguoidung.FindAsync(id);
            _context.Nguoidung.Remove(nguoidung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguoidungExists(int id)
        {
            return _context.Nguoidung.Any(e => e.Id == id);
        }
    }
}
