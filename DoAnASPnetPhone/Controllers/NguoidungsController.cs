using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnASPnetPhone.Data;
using DoAnASPnetPhone.Models;
using Microsoft.AspNetCore.Http;

namespace DoAnASPnetPhone.Controllers
{
    public class NguoidungsController : Controller
    {
        private readonly DoAnASPnetPhoneContext _context;

        public NguoidungsController(DoAnASPnetPhoneContext context)
        {
            _context = context;
        }

        // GET: Nguoidungs
        public async Task<IActionResult> Index()
        {
            var doAnASPnetPhoneContext = _context.Nguoidung.Include(n => n.Phanquyen);
            return View(await doAnASPnetPhoneContext.ToListAsync());
        }

        // GET: Nguoidungs/Details/5
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

        // GET: Nguoidungs/Create
        public IActionResult Create()
        {
            ViewData["PhanquyenId"] = new SelectList(_context.Phanquyen, "Id", "Id");
            return View();
        }

        // POST: Nguoidungs/Create
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

        // GET: Nguoidungs/Edit/5
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

        // POST: Nguoidungs/Edit/5
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

        // GET: Nguoidungs/Delete/5
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

        // POST: Nguoidungs/Delete/5
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

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string Email, string MatKhau)
        {
            Nguoidung acc = _context.Nguoidung.Where(a => a.Email == Email
                && a.Matkhau == MatKhau).FirstOrDefault();
            if (acc != null)
            {
                /*CookieOptions cookieOptions = new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(7)
                };
                HttpContext.Response.Cookies.Append("AccountId", account.Id.ToString(), cookieOptions);
                HttpContext.Response.Cookies.Append("AccountUsername", account.Username.ToString(), cookieOptions);*/
                //tạo session
                HttpContext.Session.SetInt32("NguoidungId", acc.Id);
                HttpContext.Session.SetString("NguoidungEmail", acc.Email);
                return RedirectToAction("Index", "Home");
            }
            else
            {

                return View();
            }

        }
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Append("NguoidungId", "",
                new CookieOptions { Expires = DateTime.Now.AddDays(-1) });

            HttpContext.Response.Cookies.Append("NguoidungEmail", "",
                new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
            // Hủy Session
            HttpContext.Session.Remove("NguoidungId");
            //Hủy toàn bộ Session
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Nguoidungs");
        }
    }
}
