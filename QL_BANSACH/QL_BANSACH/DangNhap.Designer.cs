namespace QL_BANSACH
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.label1 = new System.Windows.Forms.Label();
            this.llableSignIn = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbUserName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtbPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCls = new System.Windows.Forms.Button();
            this.linkfgPwd = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("UVN Nhan Nang", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(143, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 67);
            this.label1.TabIndex = 1;
            this.label1.Text = "WINGS BOOKS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // llableSignIn
            // 
            this.llableSignIn.AutoSize = true;
            this.llableSignIn.BackColor = System.Drawing.Color.Transparent;
            this.llableSignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llableSignIn.Font = new System.Drawing.Font("UVN Nhan Nang", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llableSignIn.Location = new System.Drawing.Point(301, 308);
            this.llableSignIn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llableSignIn.Name = "llableSignIn";
            this.llableSignIn.Size = new System.Drawing.Size(74, 22);
            this.llableSignIn.TabIndex = 4;
            this.llableSignIn.TabStop = true;
            this.llableSignIn.Text = "Đăng ký";
            this.llableSignIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llableSignIn_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("UVN Nhan Nang", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(151, 149);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 22);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tên đăng nhập:";
            // 
            // txtbUserName
            // 
            this.txtbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbUserName.Location = new System.Drawing.Point(282, 153);
            this.txtbUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtbUserName.Name = "txtbUserName";
            this.txtbUserName.Size = new System.Drawing.Size(215, 21);
            this.txtbUserName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("UVN Nhan Nang", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(151, 196);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 22);
            this.label7.TabIndex = 3;
            this.label7.Text = "Mật khẩu:";
            // 
            // txtbPassword
            // 
            this.txtbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbPassword.Location = new System.Drawing.Point(282, 196);
            this.txtbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtbPassword.Name = "txtbPassword";
            this.txtbPassword.Size = new System.Drawing.Size(215, 21);
            this.txtbPassword.TabIndex = 2;
            this.txtbPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnLogin.Location = new System.Drawing.Point(188, 245);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(111, 40);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnLogin_KeyDown);
            // 
            // btnCls
            // 
            this.btnCls.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCls.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCls.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCls.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnCls.Location = new System.Drawing.Point(367, 245);
            this.btnCls.Margin = new System.Windows.Forms.Padding(4);
            this.btnCls.Name = "btnCls";
            this.btnCls.Size = new System.Drawing.Size(111, 40);
            this.btnCls.TabIndex = 5;
            this.btnCls.Text = "Thoát";
            this.btnCls.UseVisualStyleBackColor = false;
            this.btnCls.Click += new System.EventHandler(this.btnCls_Click);
            // 
            // linkfgPwd
            // 
            this.linkfgPwd.AutoSize = true;
            this.linkfgPwd.BackColor = System.Drawing.Color.Transparent;
            this.linkfgPwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkfgPwd.Font = new System.Drawing.Font("UVN Nhan Nang", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkfgPwd.Location = new System.Drawing.Point(278, 340);
            this.linkfgPwd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkfgPwd.Name = "linkfgPwd";
            this.linkfgPwd.Size = new System.Drawing.Size(132, 22);
            this.linkfgPwd.TabIndex = 6;
            this.linkfgPwd.TabStop = true;
            this.linkfgPwd.Text = "Quên mật khẩu";
            this.linkfgPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkfgPwd_LinkClicked);
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(677, 398);
            this.Controls.Add(this.linkfgPwd);
            this.Controls.Add(this.btnCls);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtbPassword);
            this.Controls.Add(this.txtbUserName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.llableSignIn);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DangNhap";
            this.Text = "Đăng nhập";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DangNhap_FormClosed);
            this.Load += new System.EventHandler(this.TrangChu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel llableSignIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtbPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCls;
        private System.Windows.Forms.LinkLabel linkfgPwd;
    }
}

