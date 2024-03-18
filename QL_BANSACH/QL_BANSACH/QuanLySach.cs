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
using System.IO;

namespace QL_BANSACH
{
    public partial class QuanLySach : Form
    {
        public SqlConnection conn = new SqlConnection();
        Function func = new Function();

        public QuanLySach()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbMaSach.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            combLoaiSach.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtbTenSach.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtbNXB.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtbTenTG.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtbMoTa.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtbPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

            string filename = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + "\\Imgs_sach\\" + filename;

            if (File.Exists(fullPath))
            {
                picbSach.Image = new Bitmap(fullPath);
                labelHinh.Text = filename;
            }
            else
            {
                // Nếu không tìm thấy ảnh, bạn có thể hiển thị một ảnh mặc định hoặc thông báo lỗi tùy ý.
                picbSach.Image = null;
                labelHinh.Text = "Không tìm thấy ảnh";
            }

            btnEditSach.Enabled = true;
            btnDeleteSach.Enabled = true;
            btnSave.Enabled = false;

        }

        private void QuanLySach_Load(object sender, EventArgs e)
        {
            func.ketnoi(conn);

            txtbMaSach.Enabled = false;

            btnSave.Enabled = false;

            func.HienThiDuLieuDG(dataGridView1, "SELECT * FROM SACH", conn);

            FormatDataGridViewColumns();
        }

        private void FormatDataGridViewColumns()
        {
            if (dataGridView1.Columns.Count == 0) return;

            int columnWidth = dataGridView1.Width / dataGridView1.Columns.Count;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = columnWidth;
            }
        }

        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            DialogResult digresult = openFD.ShowDialog();
            if (digresult == DialogResult.OK)
            {
                string filename = openFD.FileName;
                picbSach.Image = new Bitmap(filename);

                labelHinh.Text = filename;

            }

        }

        private void btnAddSach_Click(object sender, EventArgs e)
        {
            txtbMaSach.Enabled = false;
            btnEditSach.Enabled = false;
            btnDeleteSach.Enabled = false;
            btnSave.Enabled = true;
            txtbTenSach.Text = "Nhập tên sách";
            txtbNXB.Text = "Nhập tên nhà xuất bản";
            txtbTenTG.Text = "Nhập tên tác giả";
            txtbPrice.Text = "Nhập giá sách";
            txtbMoTa.Text = "Nhập mô tả";
            labelHinh.Text = "";
            picbSach.Image = null;

            func.loadComb(combLoaiSach, "SELECT MALOAI, TENLOAI FROM LOAI_SACH", conn, "TENLOAI", "MALOAI");

            string sql_maSach = " SELECT MAX(SUBSTRING(MASACH,3,3)) FROM SACH ";
            SqlCommand comd = new SqlCommand(sql_maSach, conn);
            SqlDataReader reader = comd.ExecuteReader();

            if (reader.Read())
            {
                int newMaSach = Convert.ToInt16(reader.GetValue(0).ToString()) + 1;
                if (newMaSach < 10)
                {
                    txtbMaSach.Text = "MS00" + newMaSach;
                }
                else if(newMaSach < 100)
                {
                    txtbMaSach.Text = "MS0" + newMaSach;
                }
                else
                {
                    txtbMaSach.Text = "MS" + newMaSach;
                }
            }
            reader.Close();

        }

        //SU KIEN BUTTON SAVE
        private void btnSave_Click(object sender, EventArgs e)
        {
            string maSach = txtbMaSach.Text;
            string tenSach = txtbTenSach.Text;
            string loaiSach = combLoaiSach.SelectedValue.ToString();
            string nxb = txtbNXB.Text;
            string tacGia = txtbTenTG.Text;
            int gia = Convert.ToInt32(txtbPrice.Text);
            string mota = txtbMoTa.Text;           

            if(string.IsNullOrEmpty(tenSach) || txtbTenSach.Text == "Nhập tên sách")
            {
                MessageBox.Show("Tên sách không được để trống!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbTenSach.Focus();
                return;
            }else if(!int.TryParse(txtbPrice.Text,out gia))
            {
                MessageBox.Show("Giá sách không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbPrice.Focus();
                return;
            }else if (string.IsNullOrEmpty(nxb) || txtbNXB.Text == "Nhập tên nhà xuất bản")
            {
                MessageBox.Show("Tên NXB không được để trống!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbTenSach.Focus();
                return;
            }else if (string.IsNullOrEmpty(tacGia) || txtbNXB.Text == "Nhập tên tác giả")
            {
                MessageBox.Show("Tên tác giả không được để trống!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbTenSach.Focus();
                return;
            }
            else
            {
                if(string.IsNullOrEmpty(mota) || txtbMoTa.Text == "Nhập mô tả")
                {
                    mota = null;
                }

                string linksach = Environment.CurrentDirectory + "\\Imgs_sach\\" + Path.GetFileName(labelHinh.Text);
                File.Copy(labelHinh.Text, linksach, true);

                string sql_insert_table_sach = " INSERT INTO SACH(MASACH, MALOAI, TENSACH, NXB, TENTACGIA, ANHSACH, MOTA, GIA) VALUES('" + maSach + "', '" + loaiSach + "', N'" + tenSach + "', N'" + nxb + "', N'" + tacGia + "', '" + Path.GetFileName(labelHinh.Text) + "', N'" + mota + "', '" + gia + "') ";
                func.CapNhat(sql_insert_table_sach, conn);
                func.HienThiDuLieuDG(dataGridView1, "SELECT * FROM SACH", conn);
                btnEditSach.Enabled = true;
                btnDeleteSach.Enabled = true;
            }

            

        }

        //SU KIEN BUTTON EDIT
        private void btnEditSach_Click(object sender, EventArgs e)
        {
            string sql_update_table_sach = " UPDATE SACH SET TENSACH = N'"+txtbTenSach.Text+"', NXB = N'"+txtbNXB.Text+"', TENTACGIA = N'"+txtbTenTG.Text+"', ANHSACH = '" + Path.GetFileName(labelHinh.Text) + "', MOTA = N'"+txtbMoTa.Text+"', GIA = '"+txtbPrice.Text+"' WHERE MASACH = '"+txtbMaSach.Text+"' ";

            DialogResult result = MessageBox.Show("Bạn có muốn sửa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }

            func.CapNhat(sql_update_table_sach, conn);

            func.HienThiDuLieuDG(dataGridView1, "SELECT * FROM SACH", conn);

        }

        //SU KIEN BUTTON DELETE
        private void btnDeleteSach_Click(object sender, EventArgs e)
        {
            string sql_delete_table_sach = "DELETE FROM SACH WHERE MASACH = '" + txtbMaSach.Text + "'";

            DialogResult result = MessageBox.Show("Bạn có muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }

            func.CapNhat(sql_delete_table_sach, conn);

            func.HienThiDuLieuDG(dataGridView1, "SELECT * FROM SACH", conn);

        }

        private void txtbFind_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtbFind.Text;
            string sql = "SELECT * FROM SACH, LOAI_SACH WHERE SACH.MALOAI=LOAI_SACH.MALOAI AND (tensach like N'%" + tukhoa + "%' or tentacgia like N'%" + tukhoa + "%' or nxb like N'%\" + tukhoa + \"%')";
            func.HienThiDuLieuDG(dataGridView1, sql, conn);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
