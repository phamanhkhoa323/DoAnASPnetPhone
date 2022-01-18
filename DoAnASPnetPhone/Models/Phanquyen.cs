using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoAnASPnetPhone.Models
{
    public class Phanquyen
    {
        public int Id { get; set; }
        [DisplayName("ID quyền")]
        public string IDQuyen { get; set; }
        [DisplayName("Tên quyền")]
        public string Tenquyen { get; set; }
        public List<Nguoidung> Nguoidungs { get; set; }
    }
}
