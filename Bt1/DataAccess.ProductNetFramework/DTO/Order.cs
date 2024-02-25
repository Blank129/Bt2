using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ProductNetFramework.DTO
{
    public class Order
    {
        public string Ma_DonHang { get; set; }
        public string TenKhachHang { get; set; }
        public string Diachi_khachHang { get; set; }
        public string SoDienThoai_KhachHang { get; set; }
        public int TongTien { get; set; }
        public DateTime NgayDatHang { get; set; }
    }
}
