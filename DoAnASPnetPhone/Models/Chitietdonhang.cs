using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnASPnetPhone.Models
{
    public class Chitietdonhang
    {
        public int Id { get; set; }
        public int DonhangId { get; set; }
        
        [DisplayName("Mã đơn hàng")]
        public Donhang Donhang{ get; set; }
        public int SanphamId { get; set; }
        
        [DisplayName("Mã sản phẩm")]
        public Sanpham Sanpham { get; set; }
        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DefaultValue(1)]
        public int Soluong { get; set; } = 1;
        [DisplayName("Giá (VNĐ)")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [DefaultValue(0)]
        public int Dongia { get; set; } = 0;
        
    }
}
