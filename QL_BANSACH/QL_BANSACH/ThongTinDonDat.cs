using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BANSACH
{
    public partial class ThongTinDonDat : Form
    {
        string chuoiketnoi = "SERVER=DESKTOP-I8A0V3S;database=QL_BanSach;integrated Security=True";
        public ThongTinDonDat(string MaDon, string TenKh, string maNv, string Sdt, string Diachi)
        {
            InitializeComponent();
            lb1.Text = MaDon;
            lb2.Text = TenKh;
            lb3.Text = GetEmployeeNameByMANV(maNv);
            lb4.Text = GetOrderDateByMADDH(MaDon);
            lb5.Text = Sdt;
            lb6.Text = Diachi;
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private string GetEmployeeNameByMANV(string manv)
        {
            string employeeName = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();

                    string queryEmployeeName = "SELECT TENNV FROM NHAN_VIEN WHERE MANV = @MANV";
                    using (SqlCommand commandEmployeeName = new SqlCommand(queryEmployeeName, connection))
                    {
                        commandEmployeeName.Parameters.AddWithValue("@MANV", manv);
                        object result = commandEmployeeName.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            employeeName = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            return employeeName;
        }
        private string GetOrderDateByMADDH(string madon)
        {
            string orderDate = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();

                    string queryorderDate = "SELECT NGAYDAT FROM DON_DAT_HANG WHERE MADDH = @MADDH";
                    using (SqlCommand commandorderDate = new SqlCommand(queryorderDate, connection))
                    {
                        commandorderDate.Parameters.AddWithValue("@MADDH", madon);
                        object result = commandorderDate.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            orderDate = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            return orderDate;
        }

        private void ThongTinDonDat_Load(object sender, EventArgs e)
        {

        }
    }
}
