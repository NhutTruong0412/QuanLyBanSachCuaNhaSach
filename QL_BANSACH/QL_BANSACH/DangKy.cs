using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QL_BANSACH
{
    public partial class DangKy : Form
    {
        public SqlConnection conn = new SqlConnection();
        Function func = new Function();

        public DangKy()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            func.ketnoi(conn);

            txtbTen.Text = "Nhập vào họ và tên";
            txtbDC.Text = "Nhập vào địa chỉ";
            txtbUsername.Text = "";
            txtbPassword.Text = "";
            txtbRestypePw.Text = "";

            string sql_makh = " SELECT MAX(SUBSTRING(MaKH,3,3)) FROM KHACH_HANG ";
            SqlCommand comd = new SqlCommand(sql_makh, conn);
            SqlDataReader reader = comd.ExecuteReader();

            if (reader.Read())
            {
                int newMaKH = Convert.ToInt16(reader.GetValue(0).ToString()) + 1;
                if(newMaKH < 10)
                {
                    txtbMaKH.Text = "KH00" + newMaKH;
                }
                else
                {
                    txtbMaKH.Text = "KH" + newMaKH;
                }
                txtbMaKH.Enabled = false;
            }
            reader.Close();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string makh = txtbMaKH.Text;
            string tenkh = txtbTen.Text;
            string diachi = txtbDC.Text;  
            string username = txtbUsername.Text;
            string password = txtbPassword.Text;
            string rtpw = txtbRestypePw.Text;

            string sql_InsertTable_KH = " INSERT INTO KHACH_HANG(MAKH, TENKH, DIACHIKH) VALUES('"+makh+"', N'"+tenkh+"', N'"+diachi+"') ";
            string sql_InsertTable_TK = " INSERT INTO TAI_KHOAN VALUES('"+username+"', '"+makh+"', '"+password+"') ";

            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) 
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(password != rtpw) 
            {
                MessageBox.Show("Mật khẩu không khớp! Vui lòng nhập lại!!!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtbRestypePw.Focus();
            }
            else
            {
                func.CapNhat(sql_InsertTable_KH, conn);
                func.CapNhat(sql_InsertTable_TK, conn);
                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DangNhap back = new DangNhap();
                back.Show();
            }


        }

        private void btnSignIn_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSignIn.PerformClick();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtbTen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
