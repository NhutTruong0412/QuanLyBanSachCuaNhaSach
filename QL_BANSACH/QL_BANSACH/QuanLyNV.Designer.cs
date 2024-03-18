namespace QL_BANSACH
{
    partial class QuanLyNV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyNV));
            this.label1 = new System.Windows.Forms.Label();
            this.txtbMaNV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbTenNV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbDC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbSDT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddNV = new System.Windows.Forms.Button();
            this.btnEditNV = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteNV = new System.Windows.Forms.Button();
            this.labelHinh = new System.Windows.Forms.Label();
            this.picbNV = new System.Windows.Forms.PictureBox();
            this.btnUpImg = new System.Windows.Forms.Button();
            this.btnSaveNV = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbNV)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(72, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Nhân Viên";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtbMaNV
            // 
            this.txtbMaNV.Location = new System.Drawing.Point(220, 34);
            this.txtbMaNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbMaNV.Name = "txtbMaNV";
            this.txtbMaNV.Size = new System.Drawing.Size(301, 23);
            this.txtbMaNV.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(72, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên nhân viên";
            // 
            // txtbTenNV
            // 
            this.txtbTenNV.Location = new System.Drawing.Point(219, 76);
            this.txtbTenNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbTenNV.Name = "txtbTenNV";
            this.txtbTenNV.Size = new System.Drawing.Size(301, 23);
            this.txtbTenNV.TabIndex = 2;
            this.txtbTenNV.TextChanged += new System.EventHandler(this.txtbTnv_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(71, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Địa chỉ";
            // 
            // txtbDC
            // 
            this.txtbDC.Location = new System.Drawing.Point(219, 160);
            this.txtbDC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbDC.Multiline = true;
            this.txtbDC.Name = "txtbDC";
            this.txtbDC.Size = new System.Drawing.Size(301, 38);
            this.txtbDC.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(72, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Số điện thoại";
            // 
            // txtbSDT
            // 
            this.txtbSDT.Location = new System.Drawing.Point(219, 119);
            this.txtbSDT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbSDT.Name = "txtbSDT";
            this.txtbSDT.Size = new System.Drawing.Size(301, 23);
            this.txtbSDT.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(316, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(511, 54);
            this.label5.TabIndex = 2;
            this.label5.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // btnAddNV
            // 
            this.btnAddNV.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAddNV.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnAddNV.Location = new System.Drawing.Point(45, 220);
            this.btnAddNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddNV.Name = "btnAddNV";
            this.btnAddNV.Size = new System.Drawing.Size(139, 33);
            this.btnAddNV.TabIndex = 6;
            this.btnAddNV.Text = "Thêm ";
            this.btnAddNV.UseVisualStyleBackColor = false;
            this.btnAddNV.Click += new System.EventHandler(this.btnAddNV_Click);
            // 
            // btnEditNV
            // 
            this.btnEditNV.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEditNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEditNV.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnEditNV.Location = new System.Drawing.Point(219, 220);
            this.btnEditNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditNV.Name = "btnEditNV";
            this.btnEditNV.Size = new System.Drawing.Size(139, 33);
            this.btnEditNV.TabIndex = 7;
            this.btnEditNV.Text = "Sửa";
            this.btnEditNV.UseVisualStyleBackColor = false;
            this.btnEditNV.Click += new System.EventHandler(this.btnEditNV_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnDeleteNV);
            this.groupBox1.Controls.Add(this.labelHinh);
            this.groupBox1.Controls.Add(this.picbNV);
            this.groupBox1.Controls.Add(this.btnUpImg);
            this.groupBox1.Controls.Add(this.txtbSDT);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSaveNV);
            this.groupBox1.Controls.Add(this.txtbDC);
            this.groupBox1.Controls.Add(this.btnEditNV);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAddNV);
            this.groupBox1.Controls.Add(this.txtbTenNV);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtbMaNV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Location = new System.Drawing.Point(28, 97);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1088, 274);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin nhân viên";
            // 
            // btnDeleteNV
            // 
            this.btnDeleteNV.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDeleteNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDeleteNV.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnDeleteNV.Location = new System.Drawing.Point(395, 220);
            this.btnDeleteNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteNV.Name = "btnDeleteNV";
            this.btnDeleteNV.Size = new System.Drawing.Size(139, 33);
            this.btnDeleteNV.TabIndex = 11;
            this.btnDeleteNV.Text = "Xóa";
            this.btnDeleteNV.UseVisualStyleBackColor = false;
            this.btnDeleteNV.Click += new System.EventHandler(this.btnDeleteNV_Click);
            // 
            // labelHinh
            // 
            this.labelHinh.AutoSize = true;
            this.labelHinh.Location = new System.Drawing.Point(807, 244);
            this.labelHinh.Name = "labelHinh";
            this.labelHinh.Size = new System.Drawing.Size(46, 17);
            this.labelHinh.TabIndex = 10;
            this.labelHinh.Text = "label7";
            // 
            // picbNV
            // 
            this.picbNV.Location = new System.Drawing.Point(811, 34);
            this.picbNV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picbNV.Name = "picbNV";
            this.picbNV.Size = new System.Drawing.Size(215, 206);
            this.picbNV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbNV.TabIndex = 8;
            this.picbNV.TabStop = false;
            this.picbNV.Click += new System.EventHandler(this.picbNV_Click);
            // 
            // btnUpImg
            // 
            this.btnUpImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpImg.Location = new System.Drawing.Point(692, 33);
            this.btnUpImg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpImg.Name = "btnUpImg";
            this.btnUpImg.Size = new System.Drawing.Size(111, 37);
            this.btnUpImg.TabIndex = 5;
            this.btnUpImg.Text = "Upload ảnh";
            this.btnUpImg.UseVisualStyleBackColor = true;
            this.btnUpImg.Click += new System.EventHandler(this.btnUpImg_Click);
            // 
            // btnSaveNV
            // 
            this.btnSaveNV.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSaveNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSaveNV.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSaveNV.Location = new System.Drawing.Point(560, 220);
            this.btnSaveNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveNV.Name = "btnSaveNV";
            this.btnSaveNV.Size = new System.Drawing.Size(139, 33);
            this.btnSaveNV.TabIndex = 9;
            this.btnSaveNV.Text = "Lưu";
            this.btnSaveNV.UseVisualStyleBackColor = false;
            this.btnSaveNV.Click += new System.EventHandler(this.btnSaveNV_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(16, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Wings books";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox2.Location = new System.Drawing.Point(28, 379);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1087, 268);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách nhân viên";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 23);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1056, 238);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(1047, 12);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(50, 18);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Trở về";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // QuanLyNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1143, 662);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "QuanLyNV";
            this.Text = "Quản lý nhân viên";
            this.Load += new System.EventHandler(this.ThemNV_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbNV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbMaNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbTenNV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbDC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbSDT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddNV;
        private System.Windows.Forms.Button btnEditNV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picbNV;
        private System.Windows.Forms.Button btnUpImg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSaveNV;
        private System.Windows.Forms.Label labelHinh;
        private System.Windows.Forms.Button btnDeleteNV;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}