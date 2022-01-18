using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DoAnASPnetPhone.Models
{
    public class Donhang
    {
        public int Id { get; set; }
        [DisplayName("Mã đơn hàng")]
        public int Madon { get; set; }
        [DisplayName("Ngày đặt")]
        [DataType(DataType.DateTime)]
        public DateTime Ngaydat { get; set; } = DateTime.Now;
        [DisplayName("Còn hiệu lực")]
        [DefaultValue(true)]
        public bool Tinhtrang { get; set; } = true;
        public int NguoidungId { get; set; }
        [DisplayName("Mã người dùng")]
        public Nguoidung Nguoidung { get; set; }

        [DisplayName("Tổng tiền")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [DefaultValue(0)]
        public int Tongtien { get; set; }
        public List<Chitietdonhang> Chitietdonhangs { get; set; }
    }
}
