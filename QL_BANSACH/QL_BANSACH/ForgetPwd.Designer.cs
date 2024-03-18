namespace QL_BANSACH
{
    partial class ForgetPwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgetPwd));
            this.lbUsername = new System.Windows.Forms.Label();
            this.lbSdt = new System.Windows.Forms.Label();
            this.txtbUserName = new System.Windows.Forms.TextBox();
            this.txtSdt = new System.Windows.Forms.TextBox();
            this.btnComfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.BackColor = System.Drawing.Color.Transparent;
            this.lbUsername.Font = new System.Drawing.Font("UVN Nhan Nang", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbUsername.Location = new System.Drawing.Point(81, 47);
            this.lbUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(140, 26);
            this.lbUsername.TabIndex = 0;
            this.lbUsername.Text = "Tên tài khoản";
            // 
            // lbSdt
            // 
            this.lbSdt.AutoSize = true;
            this.lbSdt.BackColor = System.Drawing.Color.Transparent;
            this.lbSdt.Font = new System.Drawing.Font("UVN Nhan Nang", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSdt.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbSdt.Location = new System.Drawing.Point(84, 103);
            this.lbSdt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSdt.Name = "lbSdt";
            this.lbSdt.Size = new System.Drawing.Size(137, 26);
            this.lbSdt.TabIndex = 1;
            this.lbSdt.Text = "Số điện thoại";
            // 
            // txtbUserName
            // 
            this.txtbUserName.Location = new System.Drawing.Point(226, 53);
            this.txtbUserName.Name = "txtbUserName";
            this.txtbUserName.Size = new System.Drawing.Size(151, 20);
            this.txtbUserName.TabIndex = 2;
            // 
            // txtSdt
            // 
            this.txtSdt.Location = new System.Drawing.Point(226, 109);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.Size = new System.Drawing.Size(151, 20);
            this.txtSdt.TabIndex = 3;
            // 
            // btnComfirm
            // 
            this.btnComfirm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnComfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComfirm.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnComfirm.Location = new System.Drawing.Point(180, 163);
            this.btnComfirm.Name = "btnComfirm";
            this.btnComfirm.Size = new System.Drawing.Size(83, 32);
            this.btnComfirm.TabIndex = 4;
            this.btnComfirm.Text = "Xác nhận";
            this.btnComfirm.UseVisualStyleBackColor = false;
            this.btnComfirm.Click += new System.EventHandler(this.btnComfirm_Click);
            // 
            // ForgetPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(456, 220);
            this.Controls.Add(this.btnComfirm);
            this.Controls.Add(this.txtSdt);
            this.Controls.Add(this.txtbUserName);
            this.Controls.Add(this.lbSdt);
            this.Controls.Add(this.lbUsername);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ForgetPwd";
            this.Text = "ForgetPwd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label lbSdt;
        private System.Windows.Forms.TextBox txtbUserName;
        private System.Windows.Forms.TextBox txtSdt;
        private System.Windows.Forms.Button btnComfirm;
    }
}