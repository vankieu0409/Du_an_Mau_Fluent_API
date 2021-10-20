using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBH.BUS_Interface;
using BUS_QLBH.BUS_SeVice;
using DAL_QLBH.Entites;

namespace GUI_QLBH
{
    public partial class frmQuenMatKhau : Form
    {
        private IQuenMatKhau QMK = new QuenMatKhau();
        private IServiceNhanVien_BUS nv = new ServiceNhanVien_BUS();
        
        int _TimeNow, _Time;

        public delegate void SendMessage(string Message);

        public SendMessage Sender;
        NhanVien _NhanVien;
        private string mess = "Thông báo";
        private string _pass;
        private string _code;

        private int flag;

        public frmQuenMatKhau()
        {
            InitializeComponent();

        }
        //Hàm có nhiệm vụ lấy tham số truyền vào


        private void btn_XacNhan_Click(object sender, EventArgs e)
        {

            _TimeNow = DateTime.Now.Minute;

            if (_TimeNow - _Time > 1)
            {
                MessageBox.Show("Đã quá thời gian 1 phút .\n Mã code đã vô hiệu hóa");
                
            }
            else if (flag == 3)
            {
                MessageBox.Show("Đã quá 3 lần xác nhân .\n Mã code đã vô hiệu hóa");
                
            }
            else if (Txt_XacNhan.Text == _code)
            {
                _NhanVien = new NhanVien();
                _NhanVien = nv.getListNhanVien_BUS().FirstOrDefault(c=>c.Email==txt_Email.Text);
                _NhanVien.MatKhau = _pass;
                MessageBox.Show(nv.EditNhanVien_BUS(_NhanVien), mess);
                nv.SaveData_BUS();
                this.Close();
            }
            else
            {
                flag += 1;
                MessageBox.Show("Mã code không hợp lệ", mess);
            }
        }

        private void btn_SendtoEmail_Click(object sender, EventArgs e)
        {
            if (btn_SendtoEmail.Text == "Send")
            {
                flag = 0;
                txt_Email.Enabled = false;
                if (nv.getListNhanVien_BUS().Any(c => c.TenNv == txt_Email.Text) == false)
                {
                    MessageBox.Show("Email k tồn tại trong hệ thống", mess);
                    return;
                }
                else
                {
                    var sendPassCode = QMK.SenderMail(txt_Email.Text);
                    if (sendPassCode == null)
                    {
                        MessageBox.Show("Lỗi");
                        return;
                    }
                    else
                    {
                        _pass = sendPassCode.pass;
                        _code = sendPassCode.code;

                        btn_XacNhan.Text = "Send";
                        MessageBox.Show("Mã Code đã được giử vào email", mess);
                        _Time = DateTime.Now.Minute;
                    }
                }
           }

            else if (btn_SendtoEmail.Text == "Send")
            {
                _TimeNow = DateTime.Now.Minute;

                if (_TimeNow - _Time > 1)
                {
                    MessageBox.Show("Đã quá thời gian 1 phút .\n Mã code đã vô hiệu hóa");
                    
                }
                else if (flag == 3)
                {
                    MessageBox.Show("Đã quá 3 lần xác nhân .\n Mã code đã vô hiệu hóa");
                    
                }
                else if (Txt_XacNhan.Text == _code)
                {
                    _NhanVien = new NhanVien();
                    _NhanVien = QMK.nhanViens(txt_Email.Text);
                    _NhanVien.MatKhau = _pass;
                    _NhanVien.TinhTrang = false;
                    MessageBox.Show(QMK.UpdatePass(_NhanVien), mess);
                    this.Close();
                }
                else
                {
                    flag += 1;
                    MessageBox.Show("Mã code không hợp lệ", mess);
                }
            }

        }



    }

    
}

