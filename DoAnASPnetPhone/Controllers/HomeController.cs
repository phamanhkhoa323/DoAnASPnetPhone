using DoAnASPnetPhone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DoAnASPnetPhone.Data;

namespace DoAnASPnetPhone.Controllers
{
    public class HomeController : Controller
    {
        private readonly DoAnASPnetPhoneContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DoAnASPnetPhoneContext context)
        {
            _logger = logger;
            _context = context;
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        { /*if(HttpContext.Request.Cookies.ContainsKey("AccountUsername"))
            {
                ViewBag.AccountUsername = HttpContext.Request.Cookies["AccountUsername"].ToString(); 
            }  */
            if (HttpContext.Session.Keys.Contains("NguoidungEmail"))
            {
                ViewBag.AccountUsername = HttpContext.Session.GetString("NguoidungEmail");
            }
            return View();
        }
        public IActionResult Giohang()
        {
            List <Giohang> cart = _context.Giohang.ToList();
            return View(cart);
        }
    }
}
