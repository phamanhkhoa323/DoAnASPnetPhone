using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoAnASPnetPhone.Models
{
    public class Nguoidung
    {
        public int Id { get; set; }
        [DisplayName("Mã người dùng")]
        public int MaNguoiDung { get; set; }
        [DisplayName("Họ tên")]
        public string Hoten { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} từ 6-20 kí tự")]
        [EmailAddress(ErrorMessage = "{0} không hợp lệ")]
        public string Email { get; set; }
        [DisplayName("Mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} từ 6-20 kí tự")]
        public string Matkhau { get; set; }
        [DisplayName("Số diện thoại")]
        [RegularExpression("0\\d{9}", ErrorMessage = "Số diện thoại không hợp lệ")]
        public string Dienthoai { get; set; }
        public int PhanquyenId { get; set; }
        [DisplayName("ID Quyền")]
        public Phanquyen Phanquyen { get; set; }
        [DisplayName("Địa chỉ")]
        public string Diachi { get; set; }
        public List<Donhang> Donhangs { get; set; }
        

    }
}
