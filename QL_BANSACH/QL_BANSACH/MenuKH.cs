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
    public partial class MenuKH : Form
    {
        public string maaNDMN;
        public string username;
        SqlConnection conn = new SqlConnection();

        Function func = new Function();

        public MenuKH(string maKH, string us)    
        {
            InitializeComponent();
            maaNDMN = maKH;
            username = us;
        }

        private void btnEditPf_Click(object sender, EventArgs e)
        {
            TTKH tTKH = new TTKH(username);
            tTKH.FormClosed += MenuKH_FormClosed;
            this.Hide();
            tTKH.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            DatSach ds = new DatSach(maaNDMN);
            ds.FormClosed += MenuKH_FormClosed;
            this.Hide();
            ds.Show();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            OrderHistory orderHistory = new OrderHistory(maaNDMN);
            orderHistory.FormClosed += MenuKH_FormClosed;
            this.Hide();
            orderHistory.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();    
        }

        private void MenuKH_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void MenuKH_Load(object sender, EventArgs e)
        {
            func.ketnoi(conn);

            tailaiThongTinKH();

        }

        ///
        public void tailaiThongTinKH()
        {
            string sql = "SELECT TENKH FROM KHACH_HANG, TAI_KHOAN WHERE TAI_KHOAN.MaKH = KHACH_HANG.MAKH AND TAI_KHOAN.username = '"+username+"'";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@username", username);


            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string tenKH = reader.GetString(0);
                showName.Text = "Xin Chào, " +tenKH;

            }

            reader.Close();

        }

        private void showName_Click(object sender, EventArgs e)
        {

        }
    }
}
