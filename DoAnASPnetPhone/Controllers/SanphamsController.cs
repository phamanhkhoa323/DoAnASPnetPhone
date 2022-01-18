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
    public class SanphamsController : Controller
    {
        private readonly DoAnASPnetPhoneContext _context;

        public SanphamsController(DoAnASPnetPhoneContext context)
        {
            _context = context;
        }

        // GET: Sanphams
        public async Task<IActionResult> Index()
        {
            var doAnASPnetPhoneContext = _context.Sanpham.Include(s => s.Hangsanxuat).Include(s => s.Hedieuhanh);
            return View(await doAnASPnetPhoneContext.ToListAsync());
        }

        // GET: Sanphams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham
                .Include(s => s.Hangsanxuat)
                .Include(s => s.Hedieuhanh)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // GET: Sanphams/Create
        public IActionResult Create()
        {
            ViewData["HangsanxuatId"] = new SelectList(_context.Hangsanxuat, "Id", "Id");
            ViewData["HedieuhanhId"] = new SelectList(_context.Hedieuhanh, "Id", "Id");
            return View();
        }

        // POST: Sanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Masp,Tensp,Giatien,Soluong,Mota,Anhbia,HangsanxuatId,HedieuhanhId")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HangsanxuatId"] = new SelectList(_context.Hangsanxuat, "Id", "Id", sanpham.HangsanxuatId);
            ViewData["HedieuhanhId"] = new SelectList(_context.Hedieuhanh, "Id", "Id", sanpham.HedieuhanhId);
            return View(sanpham);
        }

        // GET: Sanphams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            ViewData["HangsanxuatId"] = new SelectList(_context.Hangsanxuat, "Id", "Id", sanpham.HangsanxuatId);
            ViewData["HedieuhanhId"] = new SelectList(_context.Hedieuhanh, "Id", "Id", sanpham.HedieuhanhId);
            return View(sanpham);
        }

        // POST: Sanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Masp,Tensp,Giatien,Soluong,Mota,Anhbia,HangsanxuatId,HedieuhanhId")] Sanpham sanpham)
        {
            if (id != sanpham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanphamExists(sanpham.Id))
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
            ViewData["HangsanxuatId"] = new SelectList(_context.Hangsanxuat, "Id", "Id", sanpham.HangsanxuatId);
            ViewData["HedieuhanhId"] = new SelectList(_context.Hedieuhanh, "Id", "Id", sanpham.HedieuhanhId);
            return View(sanpham);
        }

        // GET: Sanphams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham
                .Include(s => s.Hangsanxuat)
                .Include(s => s.Hedieuhanh)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // POST: Sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanpham = await _context.Sanpham.FindAsync(id);
            _context.Sanpham.Remove(sanpham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanphamExists(int id)
        {
            return _context.Sanpham.Any(e => e.Id == id);
        }
    }
}
