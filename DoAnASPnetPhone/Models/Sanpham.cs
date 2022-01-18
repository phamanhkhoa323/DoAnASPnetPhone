using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DoAnASPnetPhone.Models
{
    public class Sanpham
    {
        public int Id { get; set; }
        [DisplayName("Mã sản phẩm")]
        public int Masp { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string Tensp { get; set; }
        [DisplayName("Giá (VNĐ)")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [DefaultValue(0)]
        public int Giatien { get; set; } = 0;
        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DefaultValue(1)]
        public int Soluong { get; set; } = 1;
        [DisplayName("Mô tả")]
        public string Mota { get; set; }
        [DisplayName("Ảnh minh họa")]
        public string Anhbia { get; set; }
        public int HangsanxuatId { get; set; }
        [DisplayName("Mã hãng sản xuất")]
        public Hangsanxuat Hangsanxuat { get; set; }
        public int HedieuhanhId { get; set; }
        [DisplayName("Mã hệ điều hành")]
        
        public Hedieuhanh Hedieuhanh { get; set; }
        public List<Chitietdonhang> Chitietdonhangs { get; set; }
    }
}
