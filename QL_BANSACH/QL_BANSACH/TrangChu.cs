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
using System.Runtime.InteropServices;

namespace QL_BANSACH
{
    public partial class TrangChu : Form
    {
        public SqlConnection conn = new SqlConnection();
        Function fun = new Function();

        public TrangChu()
        {
            InitializeComponent();
        }

        private void llableSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy dk = new DangKy();
            dk.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtbUserName.Text;
            string password = txtbPassword.Text;
            string sql_getAcc = "SELECT username, password FROM TAI_KHOAN WHERE username = '" + username + "' AND password = '" + password + "' ";

            SqlCommand comd = new SqlCommand(sql_getAcc, conn);
            SqlDataReader reader = comd.ExecuteReader();

            if (reader.Read())
            {
                DatSach datSach = new DatSach();
                datSach.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!");
            }

            reader.Close();

        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            fun.ketnoi(conn);
        }

        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) 
            { 
                btnLogin.PerformClick();
            }
        }
    }
}
