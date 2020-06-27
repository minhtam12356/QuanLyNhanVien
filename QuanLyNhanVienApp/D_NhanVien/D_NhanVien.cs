using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data_Tier
{
    public class D_NhanVien
    {
        public SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QuanLyNhanVien;Integrated Security=True");
        public DataSet getAllTable(string strTable)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM " + strTable, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, strTable);
            return ds;
        }

        public void updateData(DataTable dtTable, string strTableName)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM " + strTableName, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, strTableName);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dtTable);
        }
    }
}
