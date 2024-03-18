using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BANSACH
{
    public partial class DatSach : Form
    {
        public string makh;
        public int isCreated = 0;
        public int onClickGridView = 0;
        public string MaNV;
        public string MADDH;
        public int showInfo = 0;
        public string bookID;
        string chuoiketnoi = "SERVER = DESKTOP-I8A0V3S; database = QL_BanSach; integrated Security = True";
        public DatSach(string MaKH)
        {
            InitializeComponent();
            LoadDataToComboBox();
            cbxLoai.SelectedIndexChanged += cbxLoai_SelectedIndexChanged;
            makh = MaKH;
            orderBookList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            orderBookList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MaNV = randomMANV();
            ShowCustomerInfoByMAKH(makh);
            enableTxt(false);
        }
        private void DeleteRowFromChiTietDonDatHang(string maDDH, string tenSach)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();

                    string queryDelete = "DELETE FROM CHI_TIET_DON_DAT_HANG WHERE MADDH = @MADDH AND MASACH = (SELECT MASACH FROM SACH WHERE TENSACH = @TENSACH)";

                    using (SqlCommand commandDelete = new SqlCommand(queryDelete, connection))
                    {
                        commandDelete.Parameters.AddWithValue("@MADDH", maDDH);
                        commandDelete.Parameters.AddWithValue("@TENSACH", tenSach);

                        int rowsAffected = commandDelete.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Đã xóa hàng dữ liệu thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Không có hàng dữ liệu nào được xóa.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void afterOrder()
        {
            cbxLoai.Text = "";
            cbxSach.Text = "";
            txtSL.Text = "";
            txtGia.Text = "";
        }
        private void enableTxt(Boolean a)
        {
            txtName.Enabled = a;
            txtSdt.Enabled = a;
            txtDiachi.Enabled = a;
        }
        private void LoadDataToComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();
                    string query = "SELECT MALOAI, TENLOAI FROM LOAI_SACH";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbxLoai.Items.Add(new LoaiSach
                                {
                                    MALOAI = reader["MALOAI"].ToString(),
                                    TENLOAI = reader["TENLOAI"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private string GetImagePathFromDatabase(string masach)
        {
            string imagePath = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();

                    string query = "SELECT ANHSACH FROM SACH WHERE MASACH = @MASACH";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MASACH", masach);
                        var result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            imagePath = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            return imagePath;
        }
        private void cbxLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxSach.Text = "";
            txtGia.Text = "";
            txtSL.Text = "";
            LoaiSach selectedLoaiSach = (LoaiSach)cbxLoai.SelectedItem;
            LoadSachTheoLoai(selectedLoaiSach.MALOAI);
        }
        private void LoadSachTheoLoai(string maLoai)
        {
            cbxSach.Items.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();
                    string query = "SELECT MASACH, TENSACH FROM SACH WHERE MALOAI = @MALOAI";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MALOAI", maLoai);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbxSach.Items.Add(new Sach
                                {
                                    MASACH = reader["MASACH"].ToString(),
                                    TENSACH = reader["TENSACH"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void LoadGiaSach(string tenSach)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();
                    string query = "SELECT GIA FROM SACH WHERE TENSACH = @TENSACH";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TENSACH", tenSach);
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            decimal gia = Convert.ToDecimal(result);
                            txtGia.Text = gia.ToString();
                        }
                        else
                        {
                            txtGia.Text = "Không có thông tin giá cho sách này.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        string GetNextOrderID()
        {
            string nextOrderID = "DH001"; // Mã mặc định nếu chưa có đơn hàng nào

            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();
                    string query = "SELECT TOP 1 MADDH FROM DON_DAT_HANG ORDER BY MADDH DESC";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        var result = command.ExecuteScalar();

                        if (result != DBNull.Value && result != null)
                        {
                            string latestOrderID = result.ToString();
                            // Lấy 3 kí tự cuối cùng của mã đơn hàng cuối cùng
                            string numericPart = latestOrderID.Substring(2, 3);
                            int number = int.Parse(numericPart);
                            number++; // Tăng mã đơn hàng lên 1
                            nextOrderID = "DH" + number.ToString("000"); // Format lại mã đơn hàng với 3 chữ số
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            return nextOrderID;
        }
        private void DisplayImage(string image)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            string imagePath = Environment.CurrentDirectory + "\\Imgs_sach\\" + image;
            if (File.Exists(imagePath))
            {
                pictureBox1.Image = Image.FromFile(imagePath);
            }
            else
            {
                MessageBox.Show("Không tìm thấy hình ảnh tại đường dẫn cung cấp.");
            }
        }
        private void ShowCustomerInfoByMAKH(string makh)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();

                    string queryCustomerInfo = "SELECT TENKH, DIACHIKH, SDT FROM KHACH_HANG WHERE MAKH = @MAKH";
                    using (SqlCommand commandCustomerInfo = new SqlCommand(queryCustomerInfo, connection))
                    {
                        commandCustomerInfo.Parameters.AddWithValue("@MAKH", makh);
                        SqlDataReader reader = commandCustomerInfo.ExecuteReader();

                        if (reader.Read())
                        {
                            txtName.Text = reader["TENKH"].ToString();
                            txtDiachi.Text = reader["DIACHIKH"].ToString();
                            txtSdt.Text = reader["SDT"].ToString();
                          
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin khách hàng.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void cbxSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sach selectedSach = (Sach)cbxSach.SelectedItem;
            LoadGiaSach(selectedSach.TENSACH);
            string masach = selectedSach.MASACH;
            string imagePath = GetImagePathFromDatabase(masach);
            DisplayImage(imagePath);
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
        private string randomMANV()
        {
            string newMANV = "NV";

            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();

                    string queryLatestMANV = "SELECT TOP 1 MANV FROM NHAN_VIEN ORDER BY MANV DESC";
                    using (SqlCommand commandLatestMANV = new SqlCommand(queryLatestMANV, connection))
                    {
                        string latestMANV = commandLatestMANV.ExecuteScalar().ToString();
                        if (!string.IsNullOrEmpty(latestMANV))
                        {

                            int lastThreeDigits = Convert.ToInt32(latestMANV.Substring(2, 3));
                            Random rand = new Random();
                            int randomNumber = rand.Next(1, lastThreeDigits+1);

 
                            newMANV += randomNumber.ToString("D3");
                        }
                        else
                        {
                            MessageBox.Show("chua co nhan vien duoc tao");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            return newMANV;
        }
        private void btnDs_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtSdt.Text) &&
                !string.IsNullOrEmpty(txtDiachi.Text) && cbxLoai.SelectedItem != null && cbxSach.SelectedItem != null 
                && !string.IsNullOrEmpty(txtSL.Text) && !string.IsNullOrEmpty(txtGia.Text))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                    {
                        connection.Open();

                        if(isCreated == 0)
                        {
                        string queryDonDatHang = "INSERT INTO DON_DAT_HANG (MADDH, MAKH, MANV, NGAYDAT, DIACHI, SDT, TRANGTHAI) VALUES (@MADDH, @MAKH, @MANV, @NGAYDAT, @DIACHI, @SDT, @TT)";
                        using (SqlCommand commandDonDatHang = new SqlCommand(queryDonDatHang, connection))
                        {
                            string nextOrderID = GetNextOrderID();
                                MADDH = nextOrderID;
                                MaNV = randomMANV();
                            commandDonDatHang.Parameters.AddWithValue("@MADDH",nextOrderID);
                            commandDonDatHang.Parameters.AddWithValue("@MAKH", makh);
                            commandDonDatHang.Parameters.AddWithValue("@MANV", MaNV);
                            commandDonDatHang.Parameters.AddWithValue("@NGAYDAT", DateTime.Now);
                            commandDonDatHang.Parameters.AddWithValue("@DIACHI", txtDiachi.Text);
                            commandDonDatHang.Parameters.AddWithValue("@SDT", txtSdt.Text);
                            commandDonDatHang.Parameters.AddWithValue("@TT", "CHƯA XÁC NHẬN");
                                commandDonDatHang.ExecuteNonQuery();
                            MessageBox.Show("Đơn đặt "+nextOrderID+" đã được tạo!");
                            isCreated = 1;
                            btnReset.Enabled = true;
                            btnSave.Enabled = true;
                            btnInfo.Enabled = true;
                            }
                        }
                        // Lấy MADDH vừa được tạo
                        string querySelectMADDH = "SELECT TOP 1 MADDH FROM DON_DAT_HANG ORDER BY MADDH DESC";
                        using (SqlCommand commandSelectMADDH = new SqlCommand(querySelectMADDH, connection))
                        {
                            string MADDH = commandSelectMADDH.ExecuteScalar().ToString();

                            // Thêm dữ liệu vào bảng CHI_TIET_DON_DAT
                            string queryChiTietDonDat = "INSERT INTO CHI_TIET_DON_DAT_HANG (MADDH, MASACH, SOLUONG, DONGIA) VALUES (@MADDH, @MASACH, @SOLUONG, @DONGIA)";
                            using (SqlCommand commandChiTietDonDat = new SqlCommand(queryChiTietDonDat, connection))
                            {
                                Sach selectedSach = (Sach)cbxSach.SelectedItem;
                                commandChiTietDonDat.Parameters.AddWithValue("@MADDH", MADDH);
                                commandChiTietDonDat.Parameters.AddWithValue("@MASACH", selectedSach.MASACH);
                                commandChiTietDonDat.Parameters.AddWithValue("@SOLUONG", Convert.ToInt32(txtSL.Text));
                                commandChiTietDonDat.Parameters.AddWithValue("@DONGIA", Convert.ToDecimal(txtGia.Text));
                                commandChiTietDonDat.ExecuteNonQuery();
                                if (showInfo == 0)
                                {
                                    btnInfo_Click(sender, new EventArgs());
                                    showInfo = 1;
                                }
                                btnUpdate.Enabled = true;
                                btnDelete.Enabled = true;
                                btnPay.Enabled = true;
                                btnCancelOrder.Enabled = true;
                                afterOrder();
                                // Lấy dữ liệu chi tiết đơn đặt hàng sau khi tạo đơn hàng
                                DataTable orderDetails = GetOrderDetailsByOrderID(MADDH);
                                // Hiển thị dữ liệu trong DataGridView
                                orderBookList.DataSource = orderDetails;
                            }
                        }
                     

                        MessageBox.Show("Đã thêm 1 quyển vào đơn đặt hàng thành công!");
                        }
                    
                }
                catch (Exception ex)
                {
                   MessageBox.Show("Sách này đã được thêm trước đó");
                   //MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }

        }
        public string LayMaSachTuTenSach(string tenSach)
        {
            string maSach = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();

                    string query = "SELECT MASACH FROM SACH WHERE TENSACH = @TenSach";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TenSach", tenSach);
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            maSach = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return maSach;
        }

        private void orderBookList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem người dùng đã chọn một hàng hợp lệ hay không
            {
                
                    DataGridViewRow selectedRow = orderBookList.Rows[e.RowIndex];

                    // Lấy dữ liệu từ các cột của hàng được chọn
                    string tenloai = selectedRow.Cells["TENLOAI"].Value.ToString();
                    string tensach = selectedRow.Cells["TENSACH"].Value.ToString();
                    string soluong = selectedRow.Cells["SOLUONG"].Value.ToString();
                    string dongia = selectedRow.Cells["DONGIA"].Value.ToString();

                    // Hiển thị dữ liệu trên các control tương ứng
                    cbxLoai.Text = tenloai;
                    cbxSach.Text = tensach;
                    txtSL.Text = soluong;
                    txtGia.Text = dongia;
                    bookID = LayMaSachTuTenSach(tensach);
                    onClickGridView = 1;
            }
        }
        public class LoaiSach
        {
            public string MALOAI { get; set; }
            public string TENLOAI { get; set; }
            public override string ToString()
            {
                return TENLOAI;
            }
        }

        public class Sach
        {
            public string MASACH { get; set; }
            public string TENSACH { get; set; }

            public override string ToString()
            {
                return TENSACH;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (isCreated == 0)
            {
                MessageBox.Show("Chưa thể sửa do đơn đặt chưa được tạo\n*Vui lòng đặt sách để đơn được tạo*");
            }
            else
            {
            enableTxt(true);
            }
          
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (onClickGridView == 0)
            {
                MessageBox.Show("Hãy nhấn chọn cụ thể vào 1 quyển sách được hiển thị trong đơn để cập nhật !");
            }
            if (onClickGridView == 1)
            {
                // Lấy thông tin từ các nguồn dữ liệu
                Sach selectedSach = (Sach)cbxSach.SelectedItem;
                string MaDDUpdate = MADDH; // Thay thế bằng MADDH của đơn đặt hàng hiện tại

                if (!string.IsNullOrEmpty(txtSL.Text) && !string.IsNullOrEmpty(txtGia.Text))
                {
                    int SOLUONG = Convert.ToInt32(txtSL.Text);
                    decimal DONGIA = Convert.ToDecimal(txtGia.Text);

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                        {
                            connection.Open();

                           
                                    string queryUpdate = "UPDATE CHI_TIET_DON_DAT_HANG " +
                                                         "SET SOLUONG = @SOLUONG, MASACH = @newMS " +
                                                         "WHERE MADDH = @MADDH AND MASACH = @MASACH";

                                    using (SqlCommand commandUpdate = new SqlCommand(queryUpdate, connection))
                                    {
                                        commandUpdate.Parameters.AddWithValue("@MADDH", MaDDUpdate);
                                        commandUpdate.Parameters.AddWithValue("@newMS", selectedSach.MASACH);
                                        commandUpdate.Parameters.AddWithValue("@MASACH", bookID);
                                        commandUpdate.Parameters.AddWithValue("@SOLUONG", Convert.ToInt32(txtSL.Text));
                                            
                                        int rowsAffected = commandUpdate.ExecuteNonQuery();

                                        if (rowsAffected > 0)
                                        {
                                            // Lấy dữ liệu chi tiết đơn đặt hàng sau khi tạo đơn hàng
                                            DataTable orderDetails = GetOrderDetailsByOrderID(MADDH);
                                            // Hiển thị dữ liệu trong DataGridView
                                            orderBookList.DataSource = orderDetails;
                                            MessageBox.Show("Dữ liệu đã được cập nhật thành công.");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Không có dữ liệu nào được cập nhật.");
                                        }
                                    }
                                }
                            
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra và lấy thông tin từ các TextBox
            string newDiachi = txtDiachi.Text;
            string newSdt = txtSdt.Text;

            // Tạo truy vấn cập nhật thông tin vào bảng DON_DAT_HANG
            string query = "UPDATE DON_DAT_HANG SET DIACHI = @Diachi, SDT = @Sdt WHERE MADDH = @MADDH"; 
            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MADDH", MADDH);
                        command.Parameters.AddWithValue("@Diachi", newDiachi);
                        command.Parameters.AddWithValue("@Sdt", newSdt);

                        int rowsUpdated = command.ExecuteNonQuery();
                        if (rowsUpdated > 0)
                        {
                            enableTxt(false);
                            MessageBox.Show("Thông tin khách hàng trong đơn đặt được cập nhật thành công");
                            btnInfo_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Không có thay đổi so với thông tin cũ");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            decimal total = 0;

            foreach (DataGridViewRow row in orderBookList.Rows)
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

            txtTotal.Text = total.ToString();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            if (isCreated == 1)
            {
                    ThongTinDonDat info = new ThongTinDonDat(MADDH, txtName.Text, MaNV, txtSdt.Text, txtDiachi.Text);
                    info.Show();
            }
            else
            {
                MessageBox.Show("Thông tin chưa có do đơn chưa đc tạo");
            }
           
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ShowCustomerInfoByMAKH(makh);
            btnSave_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (onClickGridView == 0)
            {
                MessageBox.Show("Hãy nhấn chọn cụ thể vào 1 quyển sách được hiển thị trong đơn để xóa !");
            }
            if(onClickGridView == 1)
            {
                DeleteRowFromChiTietDonDatHang(MADDH, cbxSach.Text);
                DataTable orderDetails = GetOrderDetailsByOrderID(MADDH);
                orderBookList.DataSource = orderDetails;
                afterOrder();
            }
            
        }
        private void cancelOrder(int a, string ma)
        {
            
            string tableName = (a==1)?"DON_DAT_HANG":"CHI_TIET_DON_DAT_HANG";
              string condition="'"+ma+"'";
            string query = "DELETE FROM "+tableName+ " WHERE MADDH = "+condition;
            try
            {
              using (SqlConnection connection = new SqlConnection(chuoiketnoi))
               {
                    connection.Open();
                   using(SqlCommand command = new SqlCommand(query, connection))
                  {
                       // MessageBox.Show(query);
                       command.ExecuteNonQuery();

                    }

               }
           }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
           
        }
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            cancelOrder(2, MADDH);
            cancelOrder(1, MADDH);     
            MessageBox.Show("HỦY ĐƠN ĐẶT "+MADDH+" THÀNH CÔNG");
           orderBookList.DataSource = "";
            btnCancelOrder.Enabled = false;
            isCreated = 0;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
    }


