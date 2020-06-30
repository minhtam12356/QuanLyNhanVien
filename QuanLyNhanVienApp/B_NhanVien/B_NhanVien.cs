using System.Linq;
using System.Data;


using System.Windows.Forms;
using Data_Tier;


namespace Business_Tier
{
    public class B_NhanVien
    {
        D_NhanVien da = new D_NhanVien();
        QuanLyNhanVienDataContext db = new QuanLyNhanVienDataContext();
        public void layDSDonHang(DataGridView g)
        {
            g.DataSource = da.getNV();
        }
        
        public void getChucVu(ComboBox cb)
        {
            var p = db.ChucVus.Select(s => new { ID = s.TenChucVu, Name = s.MaChucVu});
            cb.DataSource = p;
            cb.DisplayMember = "ID";
            cb.ValueMember = "Name";
        }

        public void themNV(NhanVien nv)
        {
            db.NhanViens.InsertOnSubmit(nv);
            db.SubmitChanges();
        }

        public void xoaNV(int maNV)
        {
            var sp = db.NhanViens.Where(s => s.MaNhanVien == maNV).FirstOrDefault();
            db.NhanViens.DeleteOnSubmit(sp);
            db.SubmitChanges();
        }

        public void suaNV(NhanVien nv, int MaNV)
        {
            NhanVien nhanvien = (from sp in db.NhanViens where sp.MaNhanVien == MaNV select sp).FirstOrDefault();
            
            nhanvien.HoTenNhanVien = nv.HoTenNhanVien;
            nhanvien.GioiTinh = nv.GioiTinh;
            nhanvien.NgayThangNamSinh = nv.NgayThangNamSinh;
            nhanvien.MaChucVu = nv.MaChucVu;
            nhanvien.SoDienThoai = nv.SoDienThoai;

            db.SubmitChanges();
        }
    }
}
