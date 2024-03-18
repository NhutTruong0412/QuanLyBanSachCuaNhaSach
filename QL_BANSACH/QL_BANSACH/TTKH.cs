using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QL_BANSACH
{
    public partial class TTKH : Form
    {

        public string tenanh;

        public SqlConnection conn = new SqlConnection();
        Function func = new Function();
        public string usernameDN;

        public TTKH(string userDN)
        {
            InitializeComponent();
            usernameDN = userDN;
        }

        public void tailaiThongTinKH()
        {
            txtbMa.Enabled = false;

            string sql = "SELECT TENKH, SDT, DIACHIKH, ANHKH FROM KHACH_HANG, TAI_KHOAN WHERE TAI_KHOAN.MaKH = KHACH_HANG.MAKH AND TAI_KHOAN.username = @username";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@username", usernameDN);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string tenKH = reader.IsDBNull(0) ? "không có dữ liệu" : reader.GetString(0);
                string sdtkh = reader.IsDBNull(1) ? "không có dữ liệu" : reader.GetString(1);
                string dckh = reader.IsDBNull(2) ? "không có dữ liệu" : reader.GetString(2);
                string linkanh = reader.IsDBNull(3) ? "không có dữ liệu" : reader.GetString(3);

                if (string.IsNullOrEmpty(tenKH))
                {
                    tenKH = "không có dữ liệu";
                }

                if (string.IsNullOrEmpty(sdtkh))
                {
                    sdtkh = "không có dữ liệu";
                }

                if (string.IsNullOrEmpty(dckh))
                {
                    dckh = "không có dữ liệu";
                }

                if (string.IsNullOrEmpty(linkanh))
                {
                    linkanh = "không có dữ liệu";
                }

                labelShowName.Text = tenKH;
                labelShowSDT.Text = sdtkh;
                labelShowDC.Text = dckh;

                // Hiển thị ảnh trong pictureBox
                if (string.IsNullOrEmpty(linkanh) || linkanh == "NULL")
                {
                    MessageBox.Show("Không tìm thấy ảnh");
                }
                else
                {
                    string linkanhkh = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imgs", linkanh);
                    if (File.Exists(linkanhkh))
                    {
                        picbShowImg.Image = Image.FromFile(linkanhkh);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy ảnh");
                    }
                }
            }

            reader.Close();
        }

        private void TTKH_Load(object sender, EventArgs e)
        {
            func.ketnoi(conn);
            tailaiThongTinKH();
        }

        private void txtbMa_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtbMa.Enabled = false;

            string sql = "SELECT TENKH, SDT,DIACHIKH, TAI_KHOAN.MAKH, ANhKH FROM KHACH_HANG, TAI_KHOAN WHERE TAI_KHOAN.MaKH = KHACH_HANG.MAKH AND TAI_KHOAN.username = @username";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@username", usernameDN);

           
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string tenKH = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                string sdtkh = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                string dckh = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                string makh = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                string anhkh = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                txtbMa.Text = makh;
                txtbTen.Text = tenKH;
                txtbPhone.Text = sdtkh;
                txtbDC.Text = dckh;
            }

            reader.Close();
        }

        private void btnUpImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            DialogResult digresult = openFD.ShowDialog();
            if (digresult == DialogResult.OK)
            {
                string filename = openFD.FileName;
                picb.Image = new Bitmap(filename);
                labelHinh.Text = filename;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            string tenkh = txtbTen.Text;
            string sdtkh = txtbPhone.Text;
            string dckh = txtbDC.Text;
            string makh = txtbMa.Text;

            string sql;

            if(labelHinh.Text != "label7")
            {
                string linkanhkh = AppDomain.CurrentDomain.BaseDirectory + "\\Imgs\\" + Path.GetFileName(labelHinh.Text);
                File.Copy(labelHinh.Text, linkanhkh);
                sql = "UPDATE KHACH_HANG SET TenKH = N'" + tenkh + "', DiachiKH = N'" + dckh + "', sdt = '" + sdtkh + "', anhKH = '" + Path.GetFileName(labelHinh.Text) + "' WHERE MaKH = '" + makh + "'";

            }
            else
            {
                sql = "UPDATE KHACH_HANG SET TenKH = N'" + tenkh + "', DiachiKH = N'" + dckh + "', sdt = '" + sdtkh + "' WHERE MaKH = '" + makh + "'";
            }

            //sql = "UPDATE KHACH_HANG SET TenKH = N'" + tenkh + "', DiachiKH = N'" + dckh + "', sdt_KH = '" + sdtkh + "', anhKH = '" + Path.GetFileName(labelHinh.Text) + "' WHERE MaKH = '" + makh + "'";

            DialogResult result = MessageBox.Show("Bạn có muốn sửa thông tin không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                func.CapNhat(sql, conn);
            }

            tailaiThongTinKH();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}