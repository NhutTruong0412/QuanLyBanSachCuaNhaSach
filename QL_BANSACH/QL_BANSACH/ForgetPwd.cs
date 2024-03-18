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
    public partial class ForgetPwd : Form
    {
        public ForgetPwd()
        {
            InitializeComponent();
        }
        string chuoiketnoi = "SERVER = DESKTOP-I8A0V3S; database=QL_BanSach;integrated Security=True";
        public string LayMaKHTuSDT(string sdt)
        {
            string maKH = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();

                    string query = "SELECT MAKH FROM KHACH_HANG WHERE SDT = @SDT";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SDT", sdt);
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            maKH = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return maKH;
        }
        public string LayMaKHTuUsername(string username)
        {
            string maKH = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();

                    string query = "SELECT MAKH FROM TAI_KHOAN WHERE USERNAME = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            maKH = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return maKH;
        }
        public string LayMatKhauTuUsername(string username)
        {
            string matKhau = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();

                    string query = "SELECT PASSWORD FROM TAI_KHOAN WHERE USERNAME = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            matKhau = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return matKhau;
        }

        private void btnComfirm_Click(object sender, EventArgs e)
        {
            string MAKH_1 =LayMaKHTuUsername(txtbUserName.Text);      
            string MAKH_2 =  LayMaKHTuSDT(txtSdt.Text);
            if (MAKH_1 == "") MessageBox.Show("Tên tài khoản không tồn tài");
            if (MAKH_2 == "") MessageBox.Show("Số điện thoại không tồn tài");
            if(MAKH_2 != "" &&  MAKH_1 != "") { 
                if (MAKH_1 == MAKH_2)
                {
                    MessageBox.Show("Mật khẩu của tài khoản " + txtbUserName.Text + " là " + LayMatKhauTuUsername(txtbUserName.Text));
                }
            }
        }
    }
}
