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
    public partial class DangNhap : Form
    {
        public SqlConnection conn = new SqlConnection();
        Function fun = new Function();
        public DangNhap()
        {
            InitializeComponent();
            
        }

        private void llableSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy dk = new DangKy();
            dk.FormClosed += DangNhap_FormClosed;
            this.Hide();
            dk.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtbUserName.Text;
            string password = txtbPassword.Text;
            string sql_getAcc = "SELECT username, password, makh FROM TAI_KHOAN WHERE username = '" + username + "' AND password = '" + password + "' ";

            SqlCommand comd = new SqlCommand(sql_getAcc, conn);
            SqlDataReader reader = comd.ExecuteReader();

            if (txtbUserName.Text == "admin" && txtbPassword.Text == "admin")
            {
                MenuQL menuQL = new MenuQL();
                menuQL.FormClosed += DangNhap_FormClosed;
                this.Hide();
                menuQL.Show();
                
            }
            else if (reader.Read())
            {
                MenuKH menu = new MenuKH(reader["makh"].ToString(), username);
                menu.FormClosed += DangNhap_FormClosed;
                this.Hide();
                menu.Show();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkfgPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetPwd forgetPwd = new ForgetPwd();
            forgetPwd.FormClosed += DangNhap_FormClosed;
            this.Hide();
            forgetPwd.Show();
        }

        private void DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
