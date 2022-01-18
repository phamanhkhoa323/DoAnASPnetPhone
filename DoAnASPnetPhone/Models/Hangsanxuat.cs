using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoAnASPnetPhone.Models
{
    public class Hangsanxuat
    {
        public int Id { get; set; }
        [DisplayName("Mã hãng sản xuất")]
        public int Mahang { get; set; }
        [DisplayName("Tên hãng sản xuất")]
        public string Tenhang { get; set; }
        public List<Sanpham> Sanphams { get; set; }
    }
}
