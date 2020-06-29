using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Data_Tier;


namespace Data_Tier
{
    
    public class D_NhanVien
    {
        QuanLyNhanVienDataContext db = new QuanLyNhanVienDataContext();
        public dynamic getNV()
        {
            var p = db.NhanViens.Select(s => new { s.MaNhanVien, s.HoTenNhanVien, s.GioiTinh, s.NgayThangNamSinh, ChucVu = s.ChucVu.TenChucVu, s.SoDienThoai }).ToList();
            return p;
        }
    }
}
