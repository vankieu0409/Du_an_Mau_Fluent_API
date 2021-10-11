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
        private NhanVien NvForKH;
        #region TAB_PAPE_NHÂN VIÊN
        private IServiceNhanVien_BUS nv_BUS;
        private List<NhanVien> listNhanViens;

        #endregion

        private IServiceKhachHang_BUS KH_Bus;
        private string IdWhenClickkh;

        public frmQuan_Tri()
        {
            InitializeComponent();
            NvForKH = new NhanVien();
            #region TAB_PAPE_NHÂN VIÊN

            nv_BUS = new ServiceNhanVien_BUS();
            listNhanViens = new List<NhanVien>();
            rbtn_nam_Khach.Checked = true;
            Cbx_HoatDong.Checked = true;
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
                DGV_Nhanvien.Rows.Add(x.Email, x.TenNv, x.DiaChi, x.VaiTro == 0 ? "Nhân Viên" : x.VaiTro == 1 ? "Quản trị" : "", x.TinhTrang == false ? "Ngừng Hoạt Động" : x.TinhTrang == true ? "Hoạt Động" : "", x.MatKhau, x.MaNV);
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
            var nv = nv_BUS.getListNhanVien_BUS().Find(c => c.MaNV == IdWhenClickNV);
            if (MessageBox.Show($"bạn muốn xóa tài Khoản nhân viên {nv.TenNv} chứ??", Error, MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                MessageBox.Show(nv_BUS.DeleteNhanVien_BUS(nv), Error);
            }
            loatDAtaNHANVIEN();
            flag = 3;
        }

        private void txt_Search_MouseDown(object sender, MouseEventArgs e)
        {
            txt_Search.Text = "";
        }

        private void txt_Search_KeyUp(object sender, KeyEventArgs e)
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
            foreach (var x in nv_BUS.getListNhanVien_BUS().Where(c => c.TenNv.StartsWith(txt_Search.Text)))
            {
                DGV_Nhanvien.Rows.Add(x.Email, x.TenNv, x.DiaChi, x.VaiTro == 0 ? "Nhân Viên" : x.VaiTro == 1 ? "Quản trị" : "", x.TinhTrang == false ? "Ngừng Hoạt Động" : x.TinhTrang == true ? "Hoạt Động" : "", x.MatKhau, x.MaNV);
            }

        }

        private void Btn_Skip_Click(object sender, EventArgs e)
        {
            txt_nameNV.Text = "";
            txt_Search.Text = "";
            txt_PassWord.Text = "";
            txt_diaChiNV.Text = "";
            rbtn_nam_Khach.Checked = true;
            Cbx_HoatDong.Checked = true;

        }

        private void Cbx_HoatDong_CheckedChanged(object sender, EventArgs e)
        {
            if (Cbx_HoatDong.Checked)
            {
                cbx_KhongHD.Checked = false;
            }
        }

        private void cbx_KhongHD_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_KhongHD.Checked)
            {
                Cbx_HoatDong.Checked = false;
            }
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
            foreach (var x in KH_Bus.GetlissKhachHangs())
            {
                DGV_KhachHang.Rows.Add(x.TenKhach, x.DienThoai, x.GioiTinh == 1 ? "Nam" : x.GioiTinh == 0 ? "Nữ" : "", x.DiaChi, nv_BUS.getListNhanVien_BUS().Where(c => c.MaNV == x.MaNV).Select(c => c.TenNv).FirstOrDefault());
            }
        }
        public NhanVien getNV_toKhachHang(NhanVien nv)
        {
            return NvForKH = nv;
        }
        private void btn_ThemKhach_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.DienThoai = txt_SDTKhach.Text;
            kh.TenKhach = txt_nameKhach.Text;
            kh.GioiTinh = rbtn_nam_Khach.Checked ? 1 : 0;
            kh.DiaChi = txt_AddressKhach.Text;
            kh.trangthai = true;
            kh.MaNV = NvForKH.MaNV;
            if (MessageBox.Show($"Bạn có muốn thêm Khách hàng {kh.TenKhach} vào DS người mua hàng", Error,
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show(KH_Bus.Add_Khachhang(kh), Error);
            }
            loadDGV_Khachhang();
        }

        private void DGV_KhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (rowindex == KH_Bus.GetlissKhachHangs().Count || rowindex < 0) return;
            txt_SDTKhach.Text = DGV_KhachHang.Rows[rowindex].Cells[1].ToString();
            txt_nameKhach.Text = DGV_KhachHang.Rows[rowindex].Cells[0].ToString();
            rbtn_nam_Khach.Checked = DGV_KhachHang.Rows[rowindex].Cells[2].ToString() == "Nam" ? true : false;
            rbtn_Nu_Khach.Checked = DGV_KhachHang.Rows[rowindex].Cells[2].ToString() == "Nữ" ? true : false;
            txt_AddressKhach.Text = DGV_KhachHang.Rows[rowindex].Cells[3].ToString();
            IdWhenClickkh = txt_SDTKhach.Text;
        }

        private void btn_SuaKhach_Click(object sender, EventArgs e)
        {
            var kh1 = KH_Bus.GetlissKhachHangs().FirstOrDefault(c => c.DienThoai == IdWhenClickkh);
            if (MessageBox.Show($"bạn có muốn Sửa thông tin của khách hàng {kh1.TenKhach} Không?", Error, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show(KH_Bus.Edit_KhachHang(kh1), Error);
            }
            loadDGV_Khachhang();
        }

        private void btn_XoaKhach_Click(object sender, EventArgs e)
        {
            var kh1 = KH_Bus.GetlissKhachHangs().FirstOrDefault(c => c.DienThoai == IdWhenClickkh);
            if (MessageBox.Show($"bạn có muốn Xóa thông tin của khách hàng {kh1.TenKhach} Không?", Error, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show(KH_Bus.Delete_KhachHang(kh1), Error);
            }
            loadDGV_Khachhang();
        }

        private void btn_LuuKhach_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"bạn có muốn Lưu không?", Error, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show(KH_Bus.Save_KhachHang(), Error);
            }
            loadDGV_Khachhang();
        }

        private void txt_TimKhach_KeyUp(object sender, KeyEventArgs e)
        {
            DGV_KhachHang.ColumnCount = 5;
            DGV_KhachHang.Columns[0].Name = "Tên Khách hàng";
            DGV_KhachHang.Columns[1].Name = "Số điện thoại";
            DGV_KhachHang.Columns[2].Name = "Giới tính";
            DGV_KhachHang.Columns[3].Name = "Địa Chỉ";
            DGV_KhachHang.Columns[4].Name = "Nhân Viên tiếp";
            DGV_KhachHang.Rows.Clear();
            foreach (var x in KH_Bus.GetlissKhachHangs().Where(c=>c.TenKhach.StartsWith(txt_nameKhach.Text)))
            {
                DGV_KhachHang.Rows.Add(x.TenKhach, x.DienThoai, x.GioiTinh == 1 ? "Nam" : x.GioiTinh == 0 ? "Nữ" : "", x.DiaChi, nv_BUS.getListNhanVien_BUS().Where(c => c.MaNV == x.MaNV).Select(c => c.TenNv).FirstOrDefault());
            }
        }
    }
}




