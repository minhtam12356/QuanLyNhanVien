using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Tier;

namespace QuanLyNhanVienApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable dtNhanVien;
        B_NhanVien objNhanVien = new B_NhanVien();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            NapDataGridview();
        }

        private void NapDataGridview()
        {
            dGVNhanVien.DataSource = objNhanVien.getTableNhanVien();
            dGVNhanVien.Columns[0].Width = (int)(dGVNhanVien.Width * 0.15);
            dGVNhanVien.Columns[1].Width = (int)(dGVNhanVien.Width * 0.21);
            dGVNhanVien.Columns[2].Width = (int)(dGVNhanVien.Width * 0.1);
            dGVNhanVien.Columns[3].Width = (int)(dGVNhanVien.Width * 0.2);
            dGVNhanVien.Columns[4].Width = (int)(dGVNhanVien.Width * 0.18);
            dGVNhanVien.Columns[5].Width = (int)(dGVNhanVien.Width * 0.1666666666666667);
            
        }

        private void LoadComboBox()
        {
            cbChucVu.DataSource = objNhanVien.getTableNhanVien();
            cbChucVu.DisplayMember = "ChucVu";
            cbChucVu.ValueMember = "ChucVu";
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

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void cbChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
