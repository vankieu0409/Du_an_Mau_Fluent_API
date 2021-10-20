
namespace GUI_QLBH
{
    partial class frmDangNhap
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbx_nhotk = new System.Windows.Forms.CheckBox();
            this.btnDangnhap = new System.Windows.Forms.Button();
            this.llb_QuenMK = new System.Windows.Forms.LinkLabel();
            this.txt_gmail = new System.Windows.Forms.TextBox();
            this.txt_matkhau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnthoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(147, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng Nhập Hệ Thống";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(38, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhập Email";
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = global::GUI_QLBH.Properties.Resources.images;
            this.pictureBox1.Location = new System.Drawing.Point(195, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // cbx_nhotk
            // 
            this.cbx_nhotk.AutoSize = true;
            this.cbx_nhotk.Checked = true;
            this.cbx_nhotk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_nhotk.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbx_nhotk.Location = new System.Drawing.Point(38, 337);
            this.cbx_nhotk.Name = "cbx_nhotk";
            this.cbx_nhotk.Size = new System.Drawing.Size(178, 29);
            this.cbx_nhotk.TabIndex = 4;
            this.cbx_nhotk.Text = "Ghi Nhớ tài Khoản";
            this.cbx_nhotk.UseVisualStyleBackColor = true;
            // 
            // btnDangnhap
            // 
            this.btnDangnhap.BackColor = System.Drawing.Color.LimeGreen;
            this.btnDangnhap.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDangnhap.Location = new System.Drawing.Point(131, 372);
            this.btnDangnhap.Name = "btnDangnhap";
            this.btnDangnhap.Size = new System.Drawing.Size(261, 51);
            this.btnDangnhap.TabIndex = 5;
            this.btnDangnhap.Text = "Đăng Nhập";
            this.btnDangnhap.UseVisualStyleBackColor = false;
            this.btnDangnhap.Click += new System.EventHandler(this.btnDangnhap_Click);
            // 
            // llb_QuenMK
            // 
            this.llb_QuenMK.AutoSize = true;
            this.llb_QuenMK.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.llb_QuenMK.Location = new System.Drawing.Point(320, 336);
            this.llb_QuenMK.Name = "llb_QuenMK";
            this.llb_QuenMK.Size = new System.Drawing.Size(135, 25);
            this.llb_QuenMK.TabIndex = 7;
            this.llb_QuenMK.TabStop = true;
            this.llb_QuenMK.Text = "Quên Mật Khẩu";
            this.llb_QuenMK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llb_QuenMK_LinkClicked);
            // 
            // txt_gmail
            // 
            this.txt_gmail.Location = new System.Drawing.Point(38, 214);
            this.txt_gmail.Multiline = true;
            this.txt_gmail.Name = "txt_gmail";
            this.txt_gmail.Size = new System.Drawing.Size(453, 33);
            this.txt_gmail.TabIndex = 8;
            this.txt_gmail.Text = "vankieu0409@gmail.com";
            // 
            // txt_matkhau
            // 
            this.txt_matkhau.Location = new System.Drawing.Point(38, 289);
            this.txt_matkhau.Multiline = true;
            this.txt_matkhau.Name = "txt_matkhau";
            this.txt_matkhau.PasswordChar = '*';
            this.txt_matkhau.Size = new System.Drawing.Size(453, 31);
            this.txt_matkhau.TabIndex = 9;
            this.txt_matkhau.Text = "0409";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(38, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 28);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nhập Mật Khẩu";
            // 
            // btnthoat
            // 
            this.btnthoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnthoat.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnthoat.Location = new System.Drawing.Point(131, 438);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(261, 47);
            this.btnthoat.TabIndex = 11;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = false;
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 497);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_matkhau);
            this.Controls.Add(this.txt_gmail);
            this.Controls.Add(this.llb_QuenMK);
            this.Controls.Add(this.btnDangnhap);
            this.Controls.Add(this.cbx_nhotk);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDangNhap";
            this.Text = "Đăng Nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDangNhap_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox cbx_nhotk;
        private System.Windows.Forms.Button btnDangnhap;
        private System.Windows.Forms.LinkLabel llb_QuenMK;
        private System.Windows.Forms.TextBox txt_gmail;
        private System.Windows.Forms.TextBox txt_matkhau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnthoat;
    }
}