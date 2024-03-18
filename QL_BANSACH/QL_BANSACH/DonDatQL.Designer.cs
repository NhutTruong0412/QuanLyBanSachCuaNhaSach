namespace QL_BANSACH
{
    partial class DonDatQL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DonDatQL));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.orderBookList = new System.Windows.Forms.DataGridView();
            this.cbNV = new System.Windows.Forms.CheckBox();
            this.cbKH = new System.Windows.Forms.CheckBox();
            this.cbSDT = new System.Windows.Forms.CheckBox();
            this.lbMa = new System.Windows.Forms.Label();
            this.cbxKH = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbxNV = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnComfirm = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cbxTT = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderBookList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("UVN Nhan Nang", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(328, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ ĐƠN ĐẶT";
            // 
            // txtSearch
            // 
            this.txtSearch.Enabled = false;
            this.txtSearch.Location = new System.Drawing.Point(447, 117);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(203, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("UVN Nhan Nang", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(350, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "TÌM KIẾM";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.orderBookList);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 208);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(974, 279);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DANH SÁCH ĐƠN ĐẶT";
            // 
            // orderBookList
            // 
            this.orderBookList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.orderBookList.DefaultCellStyle = dataGridViewCellStyle2;
            this.orderBookList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderBookList.Location = new System.Drawing.Point(2, 15);
            this.orderBookList.Margin = new System.Windows.Forms.Padding(2);
            this.orderBookList.Name = "orderBookList";
            this.orderBookList.RowHeadersWidth = 51;
            this.orderBookList.Size = new System.Drawing.Size(970, 262);
            this.orderBookList.TabIndex = 0;
            this.orderBookList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderBookList_CellContentClick);
            this.orderBookList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.orderBookList_CellFormatting);
            // 
            // cbNV
            // 
            this.cbNV.AutoSize = true;
            this.cbNV.BackColor = System.Drawing.Color.Transparent;
            this.cbNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNV.Location = new System.Drawing.Point(466, 145);
            this.cbNV.Margin = new System.Windows.Forms.Padding(2);
            this.cbNV.Name = "cbNV";
            this.cbNV.Size = new System.Drawing.Size(110, 20);
            this.cbNV.TabIndex = 4;
            this.cbNV.Text = "Tên nhân viên";
            this.cbNV.UseVisualStyleBackColor = false;
            this.cbNV.CheckedChanged += new System.EventHandler(this.cbNV_CheckedChanged);
            // 
            // cbKH
            // 
            this.cbKH.AutoSize = true;
            this.cbKH.BackColor = System.Drawing.Color.Transparent;
            this.cbKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKH.Location = new System.Drawing.Point(318, 145);
            this.cbKH.Margin = new System.Windows.Forms.Padding(2);
            this.cbKH.Name = "cbKH";
            this.cbKH.Size = new System.Drawing.Size(122, 20);
            this.cbKH.TabIndex = 1;
            this.cbKH.Text = "Tên khách hàng";
            this.cbKH.UseVisualStyleBackColor = false;
            this.cbKH.CheckedChanged += new System.EventHandler(this.cbKH_CheckedChanged);
            // 
            // cbSDT
            // 
            this.cbSDT.AutoSize = true;
            this.cbSDT.BackColor = System.Drawing.Color.Transparent;
            this.cbSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSDT.Location = new System.Drawing.Point(598, 145);
            this.cbSDT.Margin = new System.Windows.Forms.Padding(2);
            this.cbSDT.Name = "cbSDT";
            this.cbSDT.Size = new System.Drawing.Size(104, 20);
            this.cbSDT.TabIndex = 5;
            this.cbSDT.Text = "Số điện thoại";
            this.cbSDT.UseVisualStyleBackColor = false;
            this.cbSDT.CheckedChanged += new System.EventHandler(this.cbSDT_CheckedChanged);
            // 
            // lbMa
            // 
            this.lbMa.AutoSize = true;
            this.lbMa.BackColor = System.Drawing.Color.Transparent;
            this.lbMa.Font = new System.Drawing.Font("UVN Nhan Nang", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMa.Location = new System.Drawing.Point(21, 183);
            this.lbMa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMa.Name = "lbMa";
            this.lbMa.Size = new System.Drawing.Size(98, 15);
            this.lbMa.TabIndex = 6;
            this.lbMa.Text = "MÃ KHÁCH HÀNG";
            // 
            // cbxKH
            // 
            this.cbxKH.FormattingEnabled = true;
            this.cbxKH.Location = new System.Drawing.Point(122, 181);
            this.cbxKH.Margin = new System.Windows.Forms.Padding(2);
            this.cbxKH.Name = "cbxKH";
            this.cbxKH.Size = new System.Drawing.Size(92, 21);
            this.cbxKH.TabIndex = 7;
            this.cbxKH.SelectedIndexChanged += new System.EventHandler(this.cbxKH_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("UVN Nhan Nang", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(218, 182);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(19, 19);
            this.button1.TabIndex = 8;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Font = new System.Drawing.Font("UVN Nhan Nang", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(449, 184);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(19, 19);
            this.button2.TabIndex = 11;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbxNV
            // 
            this.cbxNV.FormattingEnabled = true;
            this.cbxNV.Location = new System.Drawing.Point(354, 183);
            this.cbxNV.Margin = new System.Windows.Forms.Padding(2);
            this.cbxNV.Name = "cbxNV";
            this.cbxNV.Size = new System.Drawing.Size(92, 21);
            this.cbxNV.TabIndex = 10;
            this.cbxNV.SelectedIndexChanged += new System.EventHandler(this.cbxNV_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("UVN Nhan Nang", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(262, 186);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "MÃ NHÂN VIÊN";
            // 
            // btnComfirm
            // 
            this.btnComfirm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnComfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComfirm.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnComfirm.Location = new System.Drawing.Point(896, 490);
            this.btnComfirm.Name = "btnComfirm";
            this.btnComfirm.Size = new System.Drawing.Size(83, 32);
            this.btnComfirm.TabIndex = 12;
            this.btnComfirm.Text = "Xác nhận";
            this.btnComfirm.UseVisualStyleBackColor = false;
            this.btnComfirm.Visible = false;
            this.btnComfirm.Click += new System.EventHandler(this.btnComfirm_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.Font = new System.Drawing.Font("UVN Nhan Nang", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(672, 184);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(19, 19);
            this.button3.TabIndex = 15;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cbxTT
            // 
            this.cbxTT.FormattingEnabled = true;
            this.cbxTT.Location = new System.Drawing.Point(569, 184);
            this.cbxTT.Margin = new System.Windows.Forms.Padding(2);
            this.cbxTT.Name = "cbxTT";
            this.cbxTT.Size = new System.Drawing.Size(100, 21);
            this.cbxTT.TabIndex = 14;
            this.cbxTT.SelectedIndexChanged += new System.EventHandler(this.cbxTT_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("UVN Nhan Nang", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(494, 187);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "TRẠNG THÁI";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(916, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(46, 16);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Trở về";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // DonDatQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(992, 533);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cbxTT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnComfirm);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbxNV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbxKH);
            this.Controls.Add(this.lbMa);
            this.Controls.Add(this.cbSDT);
            this.Controls.Add(this.cbKH);
            this.Controls.Add(this.cbNV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Name = "DonDatQL";
            this.Text = "HoaDon";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DonDatQL_MouseClick);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderBookList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label01;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView orderBookList;
        private System.Windows.Forms.CheckBox cbNV;
        private System.Windows.Forms.CheckBox cbKH;
        private System.Windows.Forms.CheckBox cbSDT;
        private System.Windows.Forms.Label lbMa;
        private System.Windows.Forms.ComboBox cbxKH;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbxNV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnComfirm;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cbxTT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}