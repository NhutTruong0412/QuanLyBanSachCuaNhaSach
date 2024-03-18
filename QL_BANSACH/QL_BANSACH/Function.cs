using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BANSACH
{
    internal class Function
    {

        public void ketnoi(SqlConnection conn)
        {
            string chuoiketnoi = " SERVER = NHUTTRUONG04; database = QL_BanSach; integrated Security = True ";
            conn.ConnectionString = chuoiketnoi;
            conn.Open();

        }

        public void HienThiDuLieuDG(DataGridView dg, String sql, SqlConnection conn)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "New table");

            dg.DataSource = dataset;
            dg.DataMember = "New table";

        }

        public void loadComb(ComboBox comb, string sql, SqlConnection conn, string hienthi, string giatri)
        {
            SqlCommand comd = new SqlCommand(sql, conn);
            SqlDataReader reader = comd.ExecuteReader();
            DataTable table = new DataTable();

            table.Load(reader);

            comb.DataSource = table;
            comb.DisplayMember = hienthi;
            comb.ValueMember = giatri;

        }

        public void CapNhat(string sql, SqlConnection conn)
        {
            SqlCommand comd = new SqlCommand(sql, conn);
            try
            {
                comd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Your query is " + sql + " with the error is " + e.Message);
            }
        }

    }
}
