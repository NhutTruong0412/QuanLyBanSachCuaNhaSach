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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QL_BANSACH
{
    public partial class DonDatQL : Form
    {
        public DonDatQL()
        {
            InitializeComponent();
            orderBookList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            orderBookList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LayVaHienThiMA(1);
            LayVaHienThiMA(2);
            comboboxTT();
            HienThiDuLieuLenGridView();
        }
        public DataTable data_orgin;
        public string MADDH;
        string chuoiketnoi = "SERVER = DESKTOP-I8A0V3S; database = QL_BanSach; integrated Security = True";
       public string query = "SELECT DDH.MADDH, KHACH_HANG.TENKH, NHAN_VIEN.TENNV, DDH.NGAYDAT, DDH.DIACHI, DDH.SDT, DDH.TRANGTHAI " +
                          "FROM DON_DAT_HANG DDH " + "INNER JOIN KHACH_HANG ON DDH.MAKH = KHACH_HANG.MAKH " +
                          "INNER JOIN NHAN_VIEN ON DDH.MANV = NHAN_VIEN.MANV"   ;
        public int isChecked = 0;

        private void comboboxTT()
        {
            cbxTT.Items.Add("CHƯA XÁC NHẬN");
            cbxTT.Items.Add("ĐÃ XÁC NHẬN");

        }
        private void LayVaHienThiMA(int a)
        {
            try
            {
                string b = "";
                if (a == 1) b = "MAKH";
                if (a == 2) b = "MANV";
                string query = "SELECT DISTINCT "+b+" FROM DON_DAT_HANG";

                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string ma = reader[b].ToString();
                       if(a==1) cbxKH.Items.Add(ma); 
                       else cbxNV.Items.Add(ma);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

      
        public DataTable LayThongTinDonDatHang()
        {
            DataTable thongTinDonDatHang = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        thongTinDonDatHang.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            return thongTinDonDatHang;
        }


        // Hàm để hiển thị dữ liệu trên DataGridView (GridView) có tên orderBookList
        private void HienThiDuLieuLenGridView()
        {
            DataTable data = LayThongTinDonDatHang();
            data_orgin = data;
            orderBookList.DataSource = data;
           
        }
        private void SearchDataByTENKH(string objectSearch ,string searchText)
        {
            // Chuẩn bị chuỗi truy vấn SQL với điều kiện lọc theo cột TENKH
            string query = "SELECT DDH.MADDH, KHACH_HANG.TENKH, NHAN_VIEN.TENNV, DDH.NGAYDAT, DDH.DIACHI, DDH.SDT " +
               "FROM DON_DAT_HANG DDH " +
               "INNER JOIN KHACH_HANG ON DDH.MAKH = KHACH_HANG.MAKH " +
               "INNER JOIN NHAN_VIEN ON DDH.MANV = NHAN_VIEN.MANV " +
               "WHERE "+ objectSearch + "LIKE @SearchText";
            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchText", searchText + "%"); // Lọc theo chuỗi bắt đầu

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Hiển thị dữ liệu lọc được lên orderBookList (DataGridView)
                            orderBookList.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(isChecked==1) SearchDataByTENKH("KHACH_HANG.TENKH ", txtSearch.Text.Trim());
            if (isChecked == 2) SearchDataByTENKH("NHAN_VIEN.TENNV ", txtSearch.Text.Trim());
            if (isChecked == 3) SearchDataByTENKH("DDH.SDT ", txtSearch.Text.Trim());
        }

        private void cbKH_CheckedChanged(object sender, EventArgs e)
        {

                isChecked = 1;
                cbNV.Checked = false;
                cbSDT.Checked = false;
                  txtSearch.Enabled = true;
            if (!cbKH.Checked){
                txtSearch.Enabled = false;
            }
            
        }

        private void cbNV_CheckedChanged(object sender, EventArgs e)
        {

                isChecked = 2;
                cbKH.Checked = false;
                cbSDT.Checked = false;
            txtSearch.Enabled = true;
            if (!cbNV.Checked)
            {
                txtSearch.Enabled = false;
            }
        }

        private void cbSDT_CheckedChanged(object sender, EventArgs e)
        {
                isChecked = 3;
                cbKH.Checked = false;
                cbNV.Checked = false;
            txtSearch.Enabled = true;
            if (!cbSDT.Checked)
            {
                txtSearch.Enabled = false;
            }
        }
        private DataTable GetOrderDetailsByOrderID(string orderID)
        {
            DataTable orderDetails = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();

                    string queryChiTietDonDat = "SELECT C.MADDH, S.TENSACH, L.TENLOAI, S.MOTA, C.SOLUONG, C.DONGIA " +
                                                "FROM CHI_TIET_DON_DAT_HANG C " +
                                                "INNER JOIN SACH S ON C.MASACH = S.MASACH " +
                                                "INNER JOIN LOAI_SACH L ON S.MALOAI = L.MALOAI " +
                                                "WHERE C.MADDH = @MADDH";

                    using (SqlCommand commandChiTietDonDat = new SqlCommand(queryChiTietDonDat, connection))
                    {
                        commandChiTietDonDat.Parameters.AddWithValue("@MADDH", orderID);
                        orderDetails.Load(commandChiTietDonDat.ExecuteReader());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            return orderDetails;
        }
        private void orderBookList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) 
            {
                if (orderBookList.Columns[e.ColumnIndex].Name == "MADDH")
                {
                    string maddh = orderBookList.Rows[e.RowIndex].Cells["MADDH"].Value.ToString();
                    DataTable data = GetOrderDetailsByOrderID(maddh);
                    ChiTietDonDat order = new ChiTietDonDat(data);
                   order.Show();
                }
                if(orderBookList.Columns[e.ColumnIndex].Name == "TRANGTHAI")
                {
                    string trangThai = orderBookList.Rows[e.RowIndex].Cells["TRANGTHAI"].Value.ToString();
                    if (trangThai == "ĐÃ XÁC NHẬN")
                    {
                        btnComfirm.Visible = false;
                    }
                    else if (trangThai == "CHƯA XÁC NHẬN")
                    {
                        btnComfirm.Visible = true;
                        DataGridViewRow selectedRow = orderBookList.Rows[e.RowIndex];
                        string firstColumnValue = Convert.ToString(selectedRow.Cells[0].Value);
                        MADDH = firstColumnValue;
                    }
                }
            }
        }
        public DataTable LayThongTinDonDatHang(int b,string a, string d, string e)

        {
            string c = "";
            if(b==1) {
                c = "DDH.MAKH = @MA";
            }
            if(b==2)
            {
                c = "DDH.MANV = @MA";
            }
            if(b==3)
            {
                c = "DDH.MAKH = @MA_1 AND DDH.MANV = @MA_2";
            }
            if(b==4) {
                c = "DDH.TRANGTHAI = @TT";
            }
            if(b==5)
            {
                c = "DDH.MAKH = @MA_1 AND DDH.TRANGTHAI = @TT";
            }
            if (b == 6)
            {
                c = "DDH.MANV = @MA_2 AND DDH.TRANGTHAI = @TT";
            }
            if (b == 7)
            {
                c = "DDH.MAKH = @MA_1 AND DDH.TRANGTHAI = @TT AND DDH.MANV = @MA_2";
            }
            string query = "SELECT DDH.MADDH, KHACH_HANG.TENKH, NHAN_VIEN.TENNV, DDH.NGAYDAT, DDH.DIACHI, DDH.SDT, DDH.TRANGTHAI " +
               "FROM DON_DAT_HANG DDH " +
               "INNER JOIN KHACH_HANG ON DDH.MAKH = KHACH_HANG.MAKH " +
               "INNER JOIN NHAN_VIEN ON DDH.MANV = NHAN_VIEN.MANV " +
               "WHERE "+c;
            DataTable thongTinDonDatHang = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))

                    {
                       if(b==1) command.Parameters.AddWithValue("@MA", a);
                       if(b==2) command.Parameters.AddWithValue("@MA", d);
                        
                        if(b==3){
                            command.Parameters.AddWithValue("@MA_1", a);
                            command.Parameters.AddWithValue("@MA_2", d);
                        }
                        if (b == 4) {
                            command.Parameters.AddWithValue("@TT", e);
                        }
                        if (b==5)
                        {
                            command.Parameters.AddWithValue("@MA_1", a);
                            command.Parameters.AddWithValue("@TT", e);
                        }
                        if (b == 6)
                        {
                            command.Parameters.AddWithValue("@MA_2", d);
                            command.Parameters.AddWithValue("@TT", e);
                        }
                        if(b==7)
                        {

                            command.Parameters.AddWithValue("@MA_1", a);
                            command.Parameters.AddWithValue("@TT", e);
                            command.Parameters.AddWithValue("@MA_2", d);
                        }
                        SqlDataReader reader = command.ExecuteReader();
                        thongTinDonDatHang.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            return thongTinDonDatHang;
        }

        private void orderBookList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (orderBookList.Columns[e.ColumnIndex].Name == "TRANGTHAI" && e.RowIndex >= 0)
            {
                if (e.Value != null)
                {
                    string trangThaiValue = e.Value.ToString();

                    if (trangThaiValue == "ĐÃ XÁC NHẬN")
                    {
                        e.CellStyle.ForeColor = Color.Green; 
                    }
                    else if (trangThaiValue == "CHƯA XÁC NHẬN")
                    {
                        e.CellStyle.ForeColor = Color.Red; 
                    }
                }
            }
        }

        private void btnComfirm_Click(object sender, EventArgs e)
        {

            comfirmOrder(MADDH);
            MessageBox.Show("ĐƠN ĐÃ ĐƯỢC XÁC NHẬN");
            HienThiDuLieuLenGridView();
        }
        private void comfirmOrder(string ma)
        {
            string query = "UPDATE DON_DAT_HANG SET TRANGTHAI = @TT WHERE MADDH = @ma";
            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))

                    {
                        command.Parameters.AddWithValue("@TT", "ĐÃ XÁC NHẬN");
                        command.Parameters.AddWithValue("@ma", ma);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void cbxKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxNV.SelectedIndex < 0 && cbxTT.SelectedIndex < 0 && cbxKH.SelectedIndex >= 0) { 
                  DataTable data = LayThongTinDonDatHang(1, cbxKH.SelectedItem.ToString(), "", "");
                  orderBookList.DataSource = data;
            }else
            if(cbxNV.SelectedIndex >= 0 && cbxTT.SelectedIndex < 0 && cbxKH.SelectedIndex >= 0)
            {
                DataTable data = LayThongTinDonDatHang(3, cbxKH.SelectedItem.ToString(), cbxNV.SelectedItem.ToString(), "");
                orderBookList.DataSource = data;
            }else
            if (cbxNV.SelectedIndex < 0 && cbxTT.SelectedIndex >= 0 && cbxKH.SelectedIndex >= 0)
            {
                DataTable data = LayThongTinDonDatHang(5, cbxKH.SelectedItem.ToString(), "", cbxTT.SelectedItem.ToString());
                orderBookList.DataSource = data;
            }else
            if (cbxNV.SelectedIndex >= 0 && cbxTT.SelectedIndex >= 0 && cbxKH.SelectedIndex >= 0)
            {
                DataTable data = LayThongTinDonDatHang(7, cbxKH.SelectedItem.ToString(), cbxNV.SelectedItem.ToString(), cbxTT.SelectedItem.ToString());
                orderBookList.DataSource = data;
            }
            else
            {
                HienThiDuLieuLenGridView();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbxKH.SelectedIndex = -1; ;
            cbxKH.Text = "";
            if (cbxNV.SelectedIndex < 0 && cbxTT.SelectedIndex < 0)
            {
                HienThiDuLieuLenGridView();
            }
            if (cbxNV.SelectedIndex >= 0 && cbxTT.SelectedIndex >= 0)
            {
                DataTable data = LayThongTinDonDatHang(6, "", cbxNV.SelectedItem.ToString(), cbxTT.SelectedItem.ToString());
                orderBookList.DataSource = data;
            }
            if (cbxNV.SelectedIndex >= 0 && cbxTT.SelectedIndex < 0)
            {
                DataTable data = LayThongTinDonDatHang(2, "", cbxNV.SelectedItem.ToString(), "");
                orderBookList.DataSource = data;
            }
            if (cbxNV.SelectedIndex < 0 && cbxTT.SelectedIndex >= 0)
            {
                DataTable data = LayThongTinDonDatHang(4, "", "", cbxTT.SelectedItem.ToString());
                orderBookList.DataSource = data;

            }
        }
        private void cbxNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxKH.SelectedIndex < 0 && cbxTT.SelectedIndex < 0 && cbxNV.SelectedIndex >=0)
            {
                DataTable data = LayThongTinDonDatHang(2, "", cbxNV.SelectedItem.ToString(), "");
                orderBookList.DataSource = data;
            }
            else
            if (cbxKH.SelectedIndex >= 0 && cbxTT.SelectedIndex < 0 && cbxNV.SelectedIndex >= 0)
            {
                DataTable data = LayThongTinDonDatHang(3, cbxKH.SelectedItem.ToString(), cbxNV.SelectedItem.ToString(), "");
                orderBookList.DataSource = data;
            }
            else
            if (cbxKH.SelectedIndex < 0 && cbxTT.SelectedIndex >= 0 && cbxNV.SelectedIndex >= 0)
            {
                DataTable data = LayThongTinDonDatHang(6, "", cbxNV.SelectedItem.ToString(), cbxTT.SelectedItem.ToString());
                orderBookList.DataSource = data;
            }
            else
            if (cbxNV.SelectedIndex >= 0 && cbxTT.SelectedIndex >= 0 && cbxNV.SelectedIndex >= 0)
            {
                DataTable data = LayThongTinDonDatHang(7, cbxKH.SelectedItem.ToString(), cbxNV.SelectedItem.ToString(), cbxTT.SelectedItem.ToString());
                orderBookList.DataSource = data;
            }
            else 
            {
                HienThiDuLieuLenGridView();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            cbxNV.SelectedIndex = -1;
            cbxNV.Text = "";
            if (cbxKH.SelectedIndex < 0 && cbxTT.SelectedIndex < 0)
            {
                HienThiDuLieuLenGridView();
            }
            if (cbxKH.SelectedIndex >= 0 && cbxTT.SelectedIndex >= 0)
            {
                DataTable data = LayThongTinDonDatHang(5, cbxKH.SelectedItem.ToString(), "", cbxTT.SelectedItem.ToString());
                orderBookList.DataSource = data;
            }
            if (cbxKH.SelectedIndex >= 0 && cbxTT.SelectedIndex < 0)
            {
                DataTable data = LayThongTinDonDatHang(1, cbxKH.SelectedItem.ToString(), "", "");
                orderBookList.DataSource = data;
            }
            if (cbxNV.SelectedIndex < 0 && cbxTT.SelectedIndex >= 0)
            {
                DataTable data = LayThongTinDonDatHang(4, "", "", cbxTT.SelectedItem.ToString());
                orderBookList.DataSource = data;

            }
        }
        private void cbxTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxNV.SelectedIndex < 0 && cbxKH.SelectedIndex < 0 && cbxTT.SelectedIndex >= 0)
            {
                DataTable data = LayThongTinDonDatHang(4, "", "", cbxTT.SelectedItem.ToString());
                orderBookList.DataSource = data;
            }else
            if (cbxNV.SelectedIndex < 0 && cbxKH.SelectedIndex >= 0 && cbxTT.SelectedIndex >= 0)
            {
                 DataTable data = LayThongTinDonDatHang(5, cbxKH.SelectedItem.ToString(), "", cbxTT.SelectedItem.ToString());
                 orderBookList.DataSource = data;
            }
            else
             if (cbxNV.SelectedIndex >= 0 && cbxKH.SelectedIndex < 0 && cbxTT.SelectedIndex >= 0)
            {
                DataTable data = LayThongTinDonDatHang(6, "", cbxNV.SelectedItem.ToString(), cbxTT.SelectedItem.ToString());
                orderBookList.DataSource = data;
            }
            else
            if (cbxNV.SelectedIndex >= 0 && cbxKH.SelectedIndex >= 0 && cbxTT.SelectedIndex >= 0)
            {
                 DataTable data = LayThongTinDonDatHang(7, cbxKH.SelectedItem.ToString(), cbxNV.SelectedItem.ToString(), cbxTT.SelectedItem.ToString());
                 orderBookList.DataSource = data;
            }
            else
            {
                HienThiDuLieuLenGridView();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cbxTT.SelectedIndex = -1;
            cbxTT.Text = "";
            if (cbxKH.SelectedIndex < 0 && cbxNV.SelectedIndex < 0)
            {
                HienThiDuLieuLenGridView();
            }
            if (cbxKH.SelectedIndex >= 0 && cbxNV.SelectedIndex >= 0)
            {
                DataTable data = LayThongTinDonDatHang(3, cbxKH.SelectedItem.ToString(), cbxNV.SelectedItem.ToString(), "");
                orderBookList.DataSource = data;
            }
            if (cbxKH.SelectedIndex >= 0 && cbxNV.SelectedIndex < 0)
            {
                DataTable data = LayThongTinDonDatHang(1, cbxKH.SelectedItem.ToString(), "", "");
                orderBookList.DataSource = data;
            }
            if (cbxNV.SelectedIndex >= 0 && cbxKH.SelectedIndex < 0)
            {
                DataTable data = LayThongTinDonDatHang(2, "", cbxNV.SelectedItem.ToString(), "");
                orderBookList.DataSource = data;

            }
        }

        private void DonDatQL_MouseClick(object sender, MouseEventArgs e)
        {
            btnComfirm.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
