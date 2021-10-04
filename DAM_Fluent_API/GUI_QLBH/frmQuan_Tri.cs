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
    public partial class frmQuan_Tri : Form
    {
        private string Error = " Thông báo của UBND xã Tuân Chính";
        private int flag = 0;
        #region TAB_PAPE_NHÂN VIÊN
        private IServiceNhanVien_BUS nv_BUS;
        private List<NhanVien> listNhanViens;
        #endregion
        public frmQuan_Tri()
        {
            InitializeComponent();
            #region TAB_PAPE_NHÂN VIÊN

            nv_BUS = new ServiceNhanVien_BUS();
            listNhanViens = new List<NhanVien>();
            loatDAtaNHANVIEN();

            #endregion

        }

        #region TAB_PAPE_NHÂN VIÊN

        void loatDAtaNHANVIEN()
        {
            DGV_Nhanvien.ColumnCount = 7;
            DGV_Nhanvien.Columns[0].Name = "Email";
            DGV_Nhanvien.Columns[1].Name = "Tên Nhân Viên";
            DGV_Nhanvien.Columns[2].Name = "Địa Chỉ";
            DGV_Nhanvien.Columns[3].Name = "Vai Trò";
            DGV_Nhanvien.Columns[4].Name = "Trạng Thái";
            DGV_Nhanvien.Columns[5].Name = "Mật Khẩu";
            DGV_Nhanvien.Columns[6].Name = "maNV";
            DGV_Nhanvien.Columns["maNV"].Visible = false;
            DGV_Nhanvien.Rows.Clear();
            foreach (var x in nv_BUS.getListNhanVien_BUS())
            {
                DGV_Nhanvien.Rows.Add(x.Email, x.TenNv, x.DiaChi, x.VaiTro == 1 ? "Nhân Viên" : x.VaiTro == 0 ? "Quản trị" : "", x.TinhTrang == 0 ? "Ngừng Hoạt Động" : x.TinhTrang == 1 ? "Hoạt Động" : "", x.MatKhau,x.MaNv);
            }

        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.Email = txt_gmail.Text;
            nv.TenNv = txt_nameNV.Text;
            nv.DiaChi = txt_diaChiNV.Text;
            nv.VaiTro = rbtn_QuanTri.Checked ? 0 : 1;
            nv.TinhTrang = Cbx_HoatDong.Checked ? 1 : 0;
            nv.MatKhau = txt_PassWord.Text;
            if (MessageBox.Show("bạn muốn thêm tài Khoản nhân viên mới chứ??",Error,MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                MessageBox.Show(nv_BUS.AddNhanvien_BUS(nv), Error);
            }
            loatDAtaNHANVIEN();
            flag = 2;

        }
        #endregion
    }

       
     
}
