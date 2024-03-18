using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BANSACH
{
    public partial class OrderHistory : Form

    {
        public OrderHistory(string maKH)
        {
            InitializeComponent();
           HienThiDuLieuLenGridView(maKH);
            makh = maKH;
            orderBookList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            orderBookList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        string chuoiketnoi = "SERVER = DESKTOP-I8A0V3S; database = QL_BanSach; integrated Security = True";
     
        public int isChecked = 0;
        public string MADDH;
        public string makh;
        public DataTable LayThongTinDonDatHang(string a)

        {
            string query = "SELECT DDH.MADDH, NHAN_VIEN.TENNV, DDH.NGAYDAT, DDH.DIACHI, DDH.SDT, DDH.TRANGTHAI " +
               "FROM DON_DAT_HANG DDH " +
               "INNER JOIN KHACH_HANG ON DDH.MAKH = KHACH_HANG.MAKH " +
               "INNER JOIN NHAN_VIEN ON DDH.MANV = NHAN_VIEN.MANV " +
               "WHERE DDH.MAKH = @MAKH";
            DataTable thongTinDonDatHang = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))

                    {
                        command.Parameters.AddWithValue("@MAKH", a);
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
        private void HienThiDuLieuLenGridView(string a)
        {
            DataTable data = LayThongTinDonDatHang(a);
            orderBookList.DataSource = data;
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

        private void orderBookList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (orderBookList.Columns[e.ColumnIndex].Name == "MADDH")
                {
                    string maddh = orderBookList.Rows[e.RowIndex].Cells["MADDH"].Value.ToString();
                    DataTable data = GetOrderDetailsByOrderID(maddh);
                    gvDetail.DataSource = data;
                    gvDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    gvDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    totalPrice();
                }
                if (orderBookList.Columns[e.ColumnIndex].Name == "TRANGTHAI")
                {
                    string trangThai = orderBookList.Rows[e.RowIndex].Cells["TRANGTHAI"].Value.ToString();
                    if (trangThai == "ĐÃ XÁC NHẬN")
                    {
                         btnCancelOrder.Visible = false;
                      
                    }
                    else if (trangThai == "CHƯA XÁC NHẬN")
                    {
                        btnCancelOrder.Visible = true;
                        DataGridViewRow selectedRow = orderBookList.Rows[e.RowIndex];
                        string firstColumnValue = Convert.ToString(selectedRow.Cells[0].Value);
                        MADDH = firstColumnValue;
                    }
                }
            }
        }

        private void totalPrice()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in gvDetail.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells["DONGIA"].Value != null && row.Cells["SOLUONG"].Value != null)
                    {
                        decimal dongia = Convert.ToDecimal(row.Cells["DONGIA"].Value);
                        int soluong = Convert.ToInt32(row.Cells["SOLUONG"].Value);
                        decimal subtotal = dongia * soluong;
                        total += subtotal;
                    }
                }
            }

            lbTotal.Text = FormatNumber(total.ToString()) + "đ";
        }
        private string FormatNumber(string c)
        {
            int numLength = c.Length;
            if (numLength >= 4)
            {
                int firstDotPosition = numLength % 3 == 0 ? 3 : numLength % 3;
                string result = c.Substring(0, firstDotPosition);
                for (int i = firstDotPosition; i < numLength; i += 3)
                {
                    result += "." + c.Substring(i, Math.Min(3, numLength - i));
                }
                return result;
            }
            return c;
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
        private void cancelOrder(int a, string ma)
        {

            string tableName = (a == 1) ? "DON_DAT_HANG" : "CHI_TIET_DON_DAT_HANG";
            string condition = "'" + ma + "'";
            string query = "DELETE FROM " + tableName + " WHERE MADDH = " + condition;
            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // MessageBox.Show(query);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            cancelOrder(2, MADDH);
            cancelOrder(1, MADDH);
            MessageBox.Show("HỦY ĐƠN ĐẶT " + MADDH + " THÀNH CÔNG");
            HienThiDuLieuLenGridView(makh);
        }

        private void OrderHistory_MouseClick(object sender, MouseEventArgs e)
        {
            btnCancelOrder.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OrderHistory_Load(object sender, EventArgs e)
        {

        }
    }
}
