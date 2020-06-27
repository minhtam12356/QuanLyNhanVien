using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data_Tier;

namespace Business_Tier
{
    public class B_NhanVien
    {
        D_NhanVien objNhanVien = new D_NhanVien();
        public DataTable getTableNhanVien()
        {
            return objNhanVien.getAllTable("NhanVien").Tables["NhanVien"];
        }
        public void CapNhatTable_NhanVien(DataTable tbNhanVien)
        {
            objNhanVien.updateData(tbNhanVien, "NhanVien");
        }

        
    }
}
