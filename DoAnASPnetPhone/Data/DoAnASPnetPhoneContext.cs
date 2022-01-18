using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DoAnASPnetPhone.Models;

namespace DoAnASPnetPhone.Data
{
    public class DoAnASPnetPhoneContext : DbContext
    {
        public DoAnASPnetPhoneContext (DbContextOptions<DoAnASPnetPhoneContext> options)
            : base(options)
        {
        }

        public DbSet<DoAnASPnetPhone.Models.Phanquyen> Phanquyen { get; set; }

        public DbSet<DoAnASPnetPhone.Models.Nguoidung> Nguoidung { get; set; }

        public DbSet<DoAnASPnetPhone.Models.Hangsanxuat> Hangsanxuat { get; set; }

        public DbSet<DoAnASPnetPhone.Models.Hedieuhanh> Hedieuhanh { get; set; }

        public DbSet<DoAnASPnetPhone.Models.Sanpham> Sanpham { get; set; }

        public DbSet<DoAnASPnetPhone.Models.Giohang> Giohang { get; set; }

        public DbSet<DoAnASPnetPhone.Models.Donhang> Donhang { get; set; }

        public DbSet<DoAnASPnetPhone.Models.Chitietdonhang> Chitietdonhang { get; set; }
    }
}
