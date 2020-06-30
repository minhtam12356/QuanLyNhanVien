using System;
using System.Windows.Forms;
using Business_Tier;
using Data_Tier;


namespace QuanLyNhanVienApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        QuanLyNhanVienDataContext db = new QuanLyNhanVienDataContext();
        B_NhanVien busNV = new B_NhanVien();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            busNV.layDSDonHang(dGVNhanVien);

        }


        private void LoadComboBox()
        {
            busNV.getChucVu(cbChucVu);
           
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();              
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        

        private void cbChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dGVNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            txtMaNhanVien.Enabled = false;
            NhanVien nv = new NhanVien();
            nv.HoTenNhanVien = txtHoTen.Text;
            nv.MaChucVu = cbChucVu.SelectedValue.ToString();

            nv.NgayThangNamSinh = Convert.ToDateTime(dateTimeNgaySinh.Text);

            if (radNu.Checked == true)
            {
                nv.GioiTinh = false;
            }
            else
            {
                nv.GioiTinh = true;
            }

            nv.SoDienThoai = txtSoDienThoai.Text;
            busNV.themNV(nv);
            busNV.layDSDonHang(dGVNhanVien);

        }

        

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Enabled = false;
            NhanVien nv = new NhanVien();
            nv.HoTenNhanVien = txtHoTen.Text;
            nv.MaChucVu = cbChucVu.SelectedValue.ToString();
            nv.NgayThangNamSinh = Convert.ToDateTime(dateTimeNgaySinh.Text);
            if (radNu.Checked == true)
            {
                nv.GioiTinh = false;
            }
            else
            {
                nv.GioiTinh = true;
            }
            nv.SoDienThoai = txtSoDienThoai.Text;
          
           

            foreach (DataGridViewRow item in dGVNhanVien.SelectedRows)
            {
                busNV.suaNV(nv, int.Parse(item.Cells[0].Value.ToString()));
            }
            busNV.layDSDonHang(dGVNhanVien);

            MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow item in dGVNhanVien.SelectedRows)
            {
                busNV.xoaNV(int.Parse(item.Cells[0].Value.ToString()));

            }
            busNV.layDSDonHang(dGVNhanVien);
        }

        private void gbThongTin_Enter(object sender, EventArgs e)
        {

        }

        private void dGVNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int i = dGVNhanVien.CurrentRow.Index;
            txtMaNhanVien.Text = dGVNhanVien.Rows[i].Cells[0].Value.ToString();
            txtHoTen.Text = dGVNhanVien.Rows[i].Cells[1].Value.ToString();

            if (dGVNhanVien.Rows[i].Cells[2].Value.ToString() == "True")
                radNam.Checked = true;
            else
                radNu.Checked = true;

            dateTimeNgaySinh.Text = dGVNhanVien.Rows[i].Cells[3].Value.ToString();
            cbChucVu.Text = dGVNhanVien.Rows[i].Cells[4].Value.ToString();
            txtSoDienThoai.Text = dGVNhanVien.Rows[i].Cells[5].Value.ToString();
        }
    }
}
