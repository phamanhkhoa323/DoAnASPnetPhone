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
    public class HangsanxuatsController : Controller
    {
        private readonly DoAnASPnetPhoneContext _context;

        public HangsanxuatsController(DoAnASPnetPhoneContext context)
        {
            _context = context;
        }

        // GET: Hangsanxuats
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hangsanxuat.ToListAsync());
        }

        // GET: Hangsanxuats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangsanxuat = await _context.Hangsanxuat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hangsanxuat == null)
            {
                return NotFound();
            }

            return View(hangsanxuat);
        }

        // GET: Hangsanxuats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hangsanxuats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mahang,Tenhang")] Hangsanxuat hangsanxuat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hangsanxuat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hangsanxuat);
        }

        // GET: Hangsanxuats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangsanxuat = await _context.Hangsanxuat.FindAsync(id);
            if (hangsanxuat == null)
            {
                return NotFound();
            }
            return View(hangsanxuat);
        }

        // POST: Hangsanxuats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mahang,Tenhang")] Hangsanxuat hangsanxuat)
        {
            if (id != hangsanxuat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hangsanxuat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangsanxuatExists(hangsanxuat.Id))
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
            return View(hangsanxuat);
        }

        // GET: Hangsanxuats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangsanxuat = await _context.Hangsanxuat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hangsanxuat == null)
            {
                return NotFound();
            }

            return View(hangsanxuat);
        }

        // POST: Hangsanxuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hangsanxuat = await _context.Hangsanxuat.FindAsync(id);
            _context.Hangsanxuat.Remove(hangsanxuat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HangsanxuatExists(int id)
        {
            return _context.Hangsanxuat.Any(e => e.Id == id);
        }
    }
}
