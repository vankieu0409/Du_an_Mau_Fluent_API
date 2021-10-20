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
using BUS_QLBH.untities;
using DAL_QLBH.Entites;

namespace GUI_QLBH
{
    public partial class frmDangNhap : Form
    {
        private string Error = " Thông báo của UBND xã Tuân Chính";
        #region TAB_PAPE_NHÂN VIÊN
        private IServiceNhanVien_BUS nv_BUS;
        private List<NhanVien> listNhanViens;
        private NhanVien nhanVien;
        private IQuenMatKhau matKhau;
        private ICheck Check;
        #endregion
        public frmDangNhap()
        {
            InitializeComponent();
            nv_BUS = new ServiceNhanVien_BUS();
            matKhau = new QuenMatKhau();
            listNhanViens = new List<NhanVien>();
            listNhanViens = nv_BUS.getListNhanVien_BUS();
            nhanVien = new NhanVien();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Check = new CheckEveryThing();
        }

        bool CheckDangNhap()
        {
            if (Check.checkNull(txt_gmail.Text))
            {
                MessageBox.Show(" Bjan Chư nhập EMail", Error);
                return false;
            }
            if (Check.checkNull(txt_matkhau.Text))
            {
                MessageBox.Show(" Bjan Chư nhập EMail", Error);
                return false;
            }
            if (Check.checkEmail(txt_gmail.Text)==false)
            {
                MessageBox.Show(" Bạn nhập chưa đúng đinh dạng mail", Error);
                return false;
            }
            return true;
        }
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (CheckDangNhap())
            {

                nhanVien = nv_BUS.getListNhanVien_BUS()
                    .Where(c => c.Email == txt_gmail.Text && c.MatKhau == txt_matkhau.Text && c.TinhTrang == true)
                    .FirstOrDefault();
                if (nv_BUS.getListNhanVien_BUS().Any(c => c.Email == txt_gmail.Text && c.MatKhau == txt_matkhau.Text && c.TinhTrang == true))
                {
                    if (nhanVien.VaiTro == 1)
                    {
                        frmQuan_Tri quanTri = new frmQuan_Tri();
                        quanTri.tenNguoiDangNhap(nhanVien.TenNv);
                        MessageBox.Show(" Đăng nhập thành công!", Error);
                        quanTri.getNV_toKhachHang(nhanVien);
                        this.Hide();
                        quanTri.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        frmNhanVien nhanVienSignin = new frmNhanVien();
                        nhanVienSignin.tenNguoiDangNhap(nhanVien.TenNv);
                        MessageBox.Show(" Đăng nhập thành công!", Error);
                        nhanVienSignin.getNV_toKhachHang(nhanVien);
                        this.Hide();
                        nhanVienSignin.ShowDialog();
                        this.Show();
                    }

                }
                else
                {
                    MessageBox.Show(" tào khoản hoặc mật khẩu Không đúng", Error);
                }
            }
        }

        private void llb_QuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmQuenMatKhau QMK = new frmQuenMatKhau();
            this.Hide();
            QMK.ShowDialog();
            this.Show();
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn Có Muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel) !=
                System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }

        }
    }
}
