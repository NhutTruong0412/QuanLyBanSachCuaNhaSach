using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BANSACH
{
    public partial class ChiTietDonDat : Form
    {
        public ChiTietDonDat(DataTable data)
        {
            InitializeComponent();
          listBook.DataSource = data;
            totalPrice();
        }

        private void totalPrice()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in listBook.Rows)
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

            lbTotal.Text = FormatNumber(total.ToString())+"đ";
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
