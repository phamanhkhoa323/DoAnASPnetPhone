using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoAnASPnetPhone.Models
{
    public class Hedieuhanh
    {
        public int Id { get; set; }
        [DisplayName("Mã hệ điều hành")]
        public int Mahdh { get; set; }
        [DisplayName("Tên hệ điều hành")]
        public string Tenhdh { get; set; }
        public List<Sanpham> Sanphams { get; set; }
    }
}
