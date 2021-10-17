
namespace GUI_QLBH
{
    partial class frmQuenMatKhau
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
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.Txt_XacNhan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_SendtoEmail = new System.Windows.Forms.Button();
            this.btn_XacNhan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(264, 122);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(195, 27);
            this.txt_Email.TabIndex = 0;
            // 
            // Txt_XacNhan
            // 
            this.Txt_XacNhan.Location = new System.Drawing.Point(265, 205);
            this.Txt_XacNhan.Name = "Txt_XacNhan";
            this.Txt_XacNhan.Size = new System.Drawing.Size(195, 27);
            this.Txt_XacNhan.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Xác nhận Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("UTM Alberta Heavy", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(170, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(327, 58);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quên Mật Khẩu";
            // 
            // btn_SendtoEmail
            // 
            this.btn_SendtoEmail.Location = new System.Drawing.Point(170, 266);
            this.btn_SendtoEmail.Name = "btn_SendtoEmail";
            this.btn_SendtoEmail.Size = new System.Drawing.Size(94, 29);
            this.btn_SendtoEmail.TabIndex = 5;
            this.btn_SendtoEmail.Text = "Send";
            this.btn_SendtoEmail.UseVisualStyleBackColor = true;
            this.btn_SendtoEmail.Click += new System.EventHandler(this.btn_SendtoEmail_Click);
            // 
            // btn_XacNhan
            // 
            this.btn_XacNhan.Location = new System.Drawing.Point(333, 266);
            this.btn_XacNhan.Name = "btn_XacNhan";
            this.btn_XacNhan.Size = new System.Drawing.Size(94, 29);
            this.btn_XacNhan.TabIndex = 6;
            this.btn_XacNhan.Text = "Xác Nhận";
            this.btn_XacNhan.UseVisualStyleBackColor = true;
            this.btn_XacNhan.Click += new System.EventHandler(this.btn_XacNhan_Click);
            // 
            // frmQuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 479);
            this.Controls.Add(this.btn_XacNhan);
            this.Controls.Add(this.btn_SendtoEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txt_XacNhan);
            this.Controls.Add(this.txt_Email);
            this.Name = "frmQuenMatKhau";
            this.Text = "frmQuenMatKhau";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox Txt_XacNhan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_SendtoEmail;
        private System.Windows.Forms.Button btn_XacNhan;
    }
}