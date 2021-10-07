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
        private string IdWhenClickNV;
        #region TAB_PAPE_NHÂN VIÊN
        private IServiceNhanVien_BUS nv_BUS;
        private List<NhanVien> listNhanViens;
        #endregion

        private IServiceKhachHang_BUS KH_Bus;

        public frmQuan_Tri()
        {
            InitializeComponent();
            #region TAB_PAPE_NHÂN VIÊN

            nv_BUS = new ServiceNhanVien_BUS();
            listNhanViens = new List<NhanVien>();
            loatDAtaNHANVIEN();

            #endregion

            KH_Bus = new ServiceKhachHang_BUS();
            loadDGV_Khachhang();


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
                DGV_Nhanvien.Rows.Add(x.Email, x.TenNv, x.DiaChi, x.VaiTro == 1 ? "Nhân Viên" : x.VaiTro == 0 ? "Quản trị" : "", x.TinhTrang == false ? "Ngừng Hoạt Động" : x.TinhTrang == true ? "Hoạt Động" : "", x.MatKhau, x.MaNV);
            }

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.Email = txt_gmail.Text;
            nv.TenNv = txt_nameNV.Text;
            nv.DiaChi = txt_diaChiNV.Text;
            nv.VaiTro = rbtn_QuanTri.Checked ? 0 : 1;
            nv.TinhTrang = Cbx_HoatDong.Checked ? true : false;
            nv.MatKhau = txt_PassWord.Text;
            if (MessageBox.Show($"bạn muốn thêm tài Khoản nhân viên {nv.TenNv} chứ??", Error, MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                MessageBox.Show(nv_BUS.AddNhanvien_BUS(nv), Error);
            }

            loatDAtaNHANVIEN();
            flag = 2;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nv_BUS.SaveData_BUS(), Error);
        }

        private void DGV_Nhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (rowindex == nv_BUS.getListNhanVien_BUS().Count /*|| rowindex == 0*/) return;
            txt_gmail.Text = DGV_Nhanvien.Rows[rowindex].Cells[0].Value.ToString();
            txt_nameNV.Text = DGV_Nhanvien.Rows[rowindex].Cells[1].Value.ToString();
            txt_diaChiNV.Text = DGV_Nhanvien.Rows[rowindex].Cells[2].Value.ToString();
            rbtn_NhanVien.Checked = DGV_Nhanvien.Rows[rowindex].Cells[3].Value.ToString() == "Nhân Viên" ? true : false;
            rbtn_QuanTri.Checked = DGV_Nhanvien.Rows[rowindex].Cells[3].Value.ToString() == "Quản trị" ? true : false;
            Cbx_HoatDong.Checked = DGV_Nhanvien.Rows[rowindex].Cells[4].Value.ToString() == "Hoạt Động" ? true : false;
            cbx_KhongHD.Checked = DGV_Nhanvien.Rows[rowindex].Cells[4].Value.ToString() == "Ngừng Hoạt Động" ? true : false;
            txt_PassWord.Text = DGV_Nhanvien.Rows[rowindex].Cells[5].Value.ToString();
            IdWhenClickNV = DGV_Nhanvien.Rows[rowindex].Cells[6].Value.ToString();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv = nv_BUS.getListNhanVien_BUS().Find(c => c.MaNV == IdWhenClickNV);
            nv.Email = txt_gmail.Text;
            nv.TenNv = txt_nameNV.Text;
            nv.DiaChi = txt_diaChiNV.Text;
            nv.VaiTro = rbtn_QuanTri.Checked ? 0 : 1;
            nv.TinhTrang = Cbx_HoatDong.Checked ? true : false;
            nv.MatKhau = txt_PassWord.Text;
            if (MessageBox.Show($"bạn muốn Sửa tài Khoản nhân viên {nv.TenNv} chứ??", Error, MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                MessageBox.Show(nv_BUS.EditNhanVien_BUS(nv), Error);
            }
            loatDAtaNHANVIEN();
            flag = 3;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var nv= nv_BUS.getListNhanVien_BUS().Find(c => c.MaNV == IdWhenClickNV);
            if (MessageBox.Show($"bạn muốn xóa tài Khoản nhân viên {nv.TenNv} chứ??", Error, MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                MessageBox.Show(nv_BUS.DeleteNhanVien_BUS(nv), Error);
            }
            loatDAtaNHANVIEN();
            flag = 3;
        }
        #endregion

        void loadDGV_Khachhang()
        {
            DGV_KhachHang.ColumnCount = 5;
            DGV_KhachHang.Columns[0].Name = "Tên Khách hàng";
            DGV_KhachHang.Columns[1].Name = "Số điện thoại";
            DGV_KhachHang.Columns[2].Name = "Giới tính";
            DGV_KhachHang.Columns[3].Name = "Địa Chỉ";
            DGV_KhachHang.Columns[4].Name = "Nhân Viên tiếp";
            DGV_KhachHang.Rows.Clear();
            foreach (var x in KH_Bus.GetListKaKhachHangs())
            {
                DGV_KhachHang.Rows.Add(x.TenKhach, x.DienThoai, x.GioiTinh, x.DiaChi, x.NameNV);
            }
        }
    }



}
