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
    public class HedieuhanhsController : Controller
    {
        private readonly DoAnASPnetPhoneContext _context;

        public HedieuhanhsController(DoAnASPnetPhoneContext context)
        {
            _context = context;
        }

        // GET: Hedieuhanhs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hedieuhanh.ToListAsync());
        }

        // GET: Hedieuhanhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hedieuhanh = await _context.Hedieuhanh
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hedieuhanh == null)
            {
                return NotFound();
            }

            return View(hedieuhanh);
        }

        // GET: Hedieuhanhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hedieuhanhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mahdh,Tenhdh")] Hedieuhanh hedieuhanh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hedieuhanh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hedieuhanh);
        }

        // GET: Hedieuhanhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hedieuhanh = await _context.Hedieuhanh.FindAsync(id);
            if (hedieuhanh == null)
            {
                return NotFound();
            }
            return View(hedieuhanh);
        }

        // POST: Hedieuhanhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mahdh,Tenhdh")] Hedieuhanh hedieuhanh)
        {
            if (id != hedieuhanh.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hedieuhanh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HedieuhanhExists(hedieuhanh.Id))
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
            return View(hedieuhanh);
        }

        // GET: Hedieuhanhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hedieuhanh = await _context.Hedieuhanh
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hedieuhanh == null)
            {
                return NotFound();
            }

            return View(hedieuhanh);
        }

        // POST: Hedieuhanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hedieuhanh = await _context.Hedieuhanh.FindAsync(id);
            _context.Hedieuhanh.Remove(hedieuhanh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HedieuhanhExists(int id)
        {
            return _context.Hedieuhanh.Any(e => e.Id == id);
        }
    }
}
