using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASPnetPhone.Models
{
    public class Giohang
    {
        public int Id { get; set; }

        public int NguoidungId { get; set; }

        // Navigation reference property cho khóa ngoại đến Account
        [DisplayName("Khách hàng")]
        public Nguoidung Nguoidung { get; set; }

        public int SanphamId { get; set; }

        // Navigation reference property cho khóa ngoại đến Product
        [DisplayName("Sản phẩm")]
        public Sanpham Sanpham { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DefaultValue(1)]
        public int SoLuongMua { get; set; } = 1;

    }
}
