using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnASPnetPhone.Data;
using DoAnASPnetPhone.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace DoAnASPnetPhone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanphamsController : Controller
    {
        private readonly DoAnASPnetPhoneContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SanphamsController(DoAnASPnetPhoneContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/Sanphams
        public async Task<IActionResult> Index()
        {
            var doAnASPnetPhoneContext = _context.Sanpham.Include(s => s.Hangsanxuat).Include(s => s.Hedieuhanh);
            return View(await doAnASPnetPhoneContext.ToListAsync());
        }

        // GET: Admin/Sanphams/Details/5
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

        // GET: Admin/Sanphams/Create
        public IActionResult Create()
        {
            ViewData["HangsanxuatId"] = new SelectList(_context.Hangsanxuat, "Id", "Tenhang");
            ViewData["HedieuhanhId"] = new SelectList(_context.Hedieuhanh, "Id", "Tenhdh");
            return View();
        }

        // POST: Admin/Sanphams/Create
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
                if(sanpham.ImageFile != null)
                {
                    var filename = sanpham.Id.ToString() + Path.GetExtension(sanpham.ImageFile.FileName);
                    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "product");
                    var filePath = Path.Combine(uploadPath, filename);
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        sanpham.ImageFile.CopyTo(fs);
                        fs.Flush();
                    }
                    sanpham.Anhbia = filename;
                    _context.Sanpham.Update(sanpham);
                    await _context.SaveChangesAsync();
                }
                //return RedirectToAction(nameof(Index));
            }
            ViewData["HangsanxuatId"] = new SelectList(_context.Hangsanxuat, "Id", "Tenhang", sanpham.HangsanxuatId);
            ViewData["HedieuhanhId"] = new SelectList(_context.Hedieuhanh, "Id", "Tenhdh", sanpham.HedieuhanhId);
            return View(sanpham);
        }

        // GET: Admin/Sanphams/Edit/5
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
            ViewData["HangsanxuatId"] = new SelectList(_context.Hangsanxuat, "Id", "Tenhang", sanpham.HangsanxuatId);
            ViewData["HedieuhanhId"] = new SelectList(_context.Hedieuhanh, "Id", "Tenhdh", sanpham.HedieuhanhId);
            return View(sanpham);
        }

        // POST: Admin/Sanphams/Edit/5
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
            ViewData["HangsanxuatId"] = new SelectList(_context.Hangsanxuat, "Id", "Tenhang", sanpham.HangsanxuatId);
            ViewData["HedieuhanhId"] = new SelectList(_context.Hedieuhanh, "Id", "Tenhdh", sanpham.HedieuhanhId);
            return View(sanpham);
        }

        // GET: Admin/Sanphams/Delete/5
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

        // POST: Admin/Sanphams/Delete/5
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
        public IActionResult Search( int? Masp, string tensp, int Giatien, int Soluong, string Mota, string Anhbia, int HangsanxuatId, int HedieuhanhId)
        {

            List<Sanpham> sanpham = _context.Sanpham.ToList();
            if (Masp != null)
            {
                sanpham= sanpham.Where(sp =>sp.Masp == Masp ).ToList();
            }
            if (tensp == null)
            {
                sanpham = sanpham.Where(pro => pro.Tensp == tensp).ToList();
            }
            if (Giatien != null)
            {
                Giatien = 0;
            }
            if (Soluong == null)
            {
                Soluong = int.MaxValue;
            }
            if (Mota != null)
            {
                sanpham = sanpham.Where(mt=>mt.Mota == Mota).ToList();
            }
            if (Anhbia  != null)
            {
                sanpham = sanpham.Where(ab => ab.Anhbia.Contains( Anhbia)).ToList();
            }
            if (HangsanxuatId != null)
            {
                sanpham = sanpham.Where(hsx => hsx.HangsanxuatId == HangsanxuatId).ToList();
            }
            if (HedieuhanhId != null)
            {
                sanpham = sanpham.Where(hdh => hdh.HedieuhanhId  == HedieuhanhId).ToList();
            }
            sanpham =sanpham.Where(prd => prd.Giatien>= Soluong).ToList();

            return View();
                //RedirectToAction(actionName: "Index", controllerName: "SanphamsController", sanpham);
        }
    }
}
