using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using AForge.Video;
using AForge.Video.DirectShow;

using BUS_QLBH.BUS_Interface;
using BUS_QLBH.BUS_SeVice;
using BUS_QLBH.untities;

using DAL_QLBH.Entites;

using ZXing;

namespace GUI_QLBH
{
    public partial class frmQuan_Tri : Form
    {
        private string Error = " Thông báo của UBND xã Tuân Chính";
        private int flag = 0;
        private NhanVien NvForKH;
        private IQuenMatKhau matKhau;
        private ICheck Check;

        #region TAB_PAPE_NHÂN VIÊN

        private IServiceNhanVien_BUS nv_BUS;
        private string IdWhenClickNV;
        private string nameOfSigningIn;

        #endregion

        #region TAB KHÁCH HÀNG

        private IServiceKhachHang_BUS KH_Bus;
        private string IdWhenClickkh;


        #endregion

        #region TAB SẢN PHẨM

        IServiceSanPham_BUS sp_BUS;
        private string pathImage;
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        private string fileName;
        private string fileAddress;
        string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 27));

        #endregion
        public frmQuan_Tri()
        {
            InitializeComponent();
            NvForKH = new NhanVien();
            Check = new CheckEveryThing();

            #region TAB_PAPE_NHÂN VIÊN

            nv_BUS = new ServiceNhanVien_BUS();
            rbtn_nam_Khach.Checked = true;
            Cbx_HoatDong.Checked = true;
            loatDAtaNHANVIEN();

            #endregion

            #region TAB KHÁCH HÀNG

            KH_Bus = new ServiceKhachHang_BUS();
            loadDGV_Khachhang();

            #endregion

            #region Tab Sản Phẩm

            sp_BUS = new ServiceSanPham_BUS();
            pt_hang.SizeMode = PictureBoxSizeMode.StretchImage;
            loadData_SP();


            #endregion
        }

        #region TAB_PAPE_NHÂN VIÊN

        public void tenNguoiDangNhap(string name)
        {
            nameOfSigningIn = name;
            lbl_Taikhoan.Text = nameOfSigningIn;
        }
        void loatDAtaNHANVIEN()
        {
            DGV_Nhanvien.ColumnCount = 7;
            DGV_Nhanvien.Columns[0].Name = "Email";
            DGV_Nhanvien.Columns[1].Name = "Tên Nhân Viên";
            DGV_Nhanvien.Columns[2].Name = "Địa Chỉ";
            DGV_Nhanvien.Columns[3].Name = "Vai Trò";
            DGV_Nhanvien.Columns[4].Name = "Trạng Thái";
            DGV_Nhanvien.Columns[5].Name = "Mật Khẩu";
            DGV_Nhanvien.Columns["Mật Khẩu"].Visible = false;
            DGV_Nhanvien.Columns[6].Name = "maNV";
            DGV_Nhanvien.Columns["maNV"].Visible = false;
            DGV_Nhanvien.Rows.Clear();
            foreach (var x in nv_BUS.getListNhanVien_BUS().Where(c => c.flag == true))
            {
                DGV_Nhanvien.Rows.Add(x.Email, x.TenNv, x.DiaChi,
                    x.VaiTro == 0 ? "Nhân Viên" : x.VaiTro == 1 ? "Quản trị" : "",
                    x.TinhTrang == false ? "Ngừng Hoạt Động" : x.TinhTrang == true ? "Hoạt Động" : "", x.MatKhau,
                    x.MaNV);
            }

        }

        bool CheckNhanVien()
        {
            if (string.IsNullOrWhiteSpace(txt_nameNV.Text))
            {
                MessageBox.Show(" Không được để trống tên Nhân Viên ", Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_PassWord.Text))
            {
                MessageBox.Show(" Không được để trống Mật Khẩu", Error);
                return false;
            }
            if (Check.checkNull(txt_diaChiNV.Text))
            {
                MessageBox.Show(" Không được để trống Địa Chỉ ", Error);
                return false;
            }
            if (Check.checkNull(txt_gmail.Text))
            {
                MessageBox.Show(" Không được để trống Email ", Error);
                return false;
            }

            if (Check.checkEmail(txt_gmail.Text) == false)
            {
                MessageBox.Show(" Email Không đúng!", Error);
                return false;
            }
            else
            {
                return true;
            }


        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            if (CheckNhanVien() == true)
            {
                if (nv_BUS.getListNhanVien_BUS().Any(c=>c.MatKhau==txt_PassWord.Text))
                {
                    MessageBox.Show("mật Khẩu bị trùng!\n Vui Lòng Đổi mật khẩu khác!", Error);
                }
                else
                {


                    NhanVien nv = new NhanVien();
                    nv.Email = txt_gmail.Text;
                    nv.TenNv = txt_nameNV.Text;
                    nv.DiaChi = txt_diaChiNV.Text;
                    nv.VaiTro = rbtn_QuanTri.Checked ? 1 : 0;
                    nv.TinhTrang = Cbx_HoatDong.Checked ? true : false;
                    nv.MatKhau = txt_PassWord.Text;
                    nv.flag = true;
                    if (MessageBox.Show($"bạn muốn thêm tài Khoản nhân viên {nv.TenNv} chứ??", Error,
                            MessageBoxButtons.YesNo) ==
                        DialogResult.Yes)
                    {
                        MessageBox.Show(nv_BUS.AddNhanvien_BUS(nv), Error);
                    }
                }

                loatDAtaNHANVIEN();
                flag = 2;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nv_BUS.SaveData_BUS(), Error);
        }

        private void DGV_Nhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (rowindex >= nv_BUS.getListNhanVien_BUS().Count || rowindex < 0) return;
            txt_gmail.Text = DGV_Nhanvien.Rows[rowindex].Cells[0].Value.ToString();
            txt_nameNV.Text = DGV_Nhanvien.Rows[rowindex].Cells[1].Value.ToString();
            txt_diaChiNV.Text = DGV_Nhanvien.Rows[rowindex].Cells[2].Value.ToString();
            rbtn_NhanVien.Checked = DGV_Nhanvien.Rows[rowindex].Cells[3].Value.ToString() == "Nhân Viên" ? true : false;
            rbtn_QuanTri.Checked = DGV_Nhanvien.Rows[rowindex].Cells[3].Value.ToString() == "Quản trị" ? true : false;
            Cbx_HoatDong.Checked = DGV_Nhanvien.Rows[rowindex].Cells[4].Value.ToString() == "Hoạt Động" ? true : false;
            cbx_KhongHD.Checked = DGV_Nhanvien.Rows[rowindex].Cells[4].Value.ToString() == "Ngừng Hoạt Động"
                ? true
                : false;
            txt_PassWord.Text = DGV_Nhanvien.Rows[rowindex].Cells[5].Value.ToString();
            IdWhenClickNV = DGV_Nhanvien.Rows[rowindex].Cells[6].Value.ToString();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (CheckNhanVien())
            {
                NhanVien nv = new NhanVien();
                nv = nv_BUS.getListNhanVien_BUS().Find(c => c.MaNV == IdWhenClickNV);
                nv.Email = txt_gmail.Text;
                nv.TenNv = txt_nameNV.Text;
                nv.DiaChi = txt_diaChiNV.Text;
                nv.VaiTro = rbtn_QuanTri.Checked ? 1 : 0;
                nv.TinhTrang = Cbx_HoatDong.Checked ? true : false;
                nv.MatKhau = txt_PassWord.Text;
                if (MessageBox.Show($"bạn muốn Sửa tài Khoản nhân viên {nv.TenNv} chứ??", Error,
                        MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                {
                    MessageBox.Show(nv_BUS.EditNhanVien_BUS(nv), Error);
                }
                loatDAtaNHANVIEN();
                flag = 3;
            }


        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var nv = nv_BUS.getListNhanVien_BUS().Find(c => c.MaNV == IdWhenClickNV);
            nv.flag = false;
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
            DGV_hang.Columns["Mật Khẩu"].Visible = false;
            DGV_Nhanvien.Columns[6].Name = "maNV";
            DGV_Nhanvien.Columns["maNV"].Visible = false;
            DGV_Nhanvien.Rows.Clear();
            foreach (var x in nv_BUS.getListNhanVien_BUS().Where(c => c.TenNv.StartsWith(txt_Search.Text) && c.flag == true))
            {
                DGV_Nhanvien.Rows.Add(x.Email, x.TenNv, x.DiaChi,
                    x.VaiTro == 0 ? "Nhân Viên" : x.VaiTro == 1 ? "Quản trị" : "",
                    x.TinhTrang == false ? "Ngừng Hoạt Động" : x.TinhTrang == true ? "Hoạt Động" : "", x.MatKhau,
                    x.MaNV);
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

        #region TAB Khách Hàng

        void loadDGV_Khachhang()
        {
            DGV_KhachHang.ColumnCount = 5;
            DGV_KhachHang.Columns[0].Name = "Tên Khách hàng";
            DGV_KhachHang.Columns[1].Name = "Số điện thoại";
            DGV_KhachHang.Columns[2].Name = "Giới tính";
            DGV_KhachHang.Columns[3].Name = "Địa Chỉ";
            DGV_KhachHang.Columns[4].Name = "Nhân Viên tiếp";
            DGV_KhachHang.Rows.Clear();
            foreach (var x in KH_Bus.GetlissKhachHangs().Where(c => c.flag == true))
            {
                DGV_KhachHang.Rows.Add(x.TenKhach, x.DienThoai, x.GioiTinh == 1 ? "Nam" : x.GioiTinh == 0 ? "Nữ" : "",
                    x.DiaChi,
                    nv_BUS.getListNhanVien_BUS().Where(c => c.MaNV == x.MaNV).Select(c => c.TenNv).FirstOrDefault());
            }
        }

        public NhanVien getNV_toKhachHang(NhanVien nv)
        {
            return NvForKH = nv;
        }

        bool CheckKhachHang()
        {
            if (Check.checkNull(txt_SDTKhach.Text))
            {
                MessageBox.Show("Không được để trông SĐT Khách hàng");
                return false;
            }

            if (Check.checkNull(txt_nameKhach.Text))
            {
                MessageBox.Show("Không được để trống Tên Khách hàng");
                return false;
            }

            if (Check.checkNull(txt_AddressKhach.Text))
            {
                MessageBox.Show("Không được để trống  Dịa Chỉ Khách hàng");
                return false;
            }

            if (Check.checkSDT(txt_SDTKhach.Text))
            {
                MessageBox.Show("Không được để trông SĐT Khách hàng");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_ThemKhach_Click(object sender, EventArgs e)
        {
            if (CheckKhachHang())
            {

                KhachHang kh = new KhachHang();
                kh.DienThoai = txt_SDTKhach.Text;
                kh.TenKhach = txt_nameKhach.Text;
                kh.GioiTinh = rbtn_nam_Khach.Checked ? 1 : 0;
                kh.DiaChi = txt_AddressKhach.Text;
                kh.flag = true;
                kh.MaNV = NvForKH.MaNV;
                if (MessageBox.Show($"Bạn có muốn thêm Khách hàng {kh.TenKhach} vào DS người mua hàng", Error,
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MessageBox.Show(KH_Bus.Add_Khachhang(kh), Error);
                }
                loadDGV_Khachhang();
            }
        }

        private void DGV_KhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (rowindex == KH_Bus.GetlissKhachHangs().Count || rowindex < 0) return;
            txt_SDTKhach.Text = DGV_KhachHang.Rows[rowindex].Cells[1].Value.ToString();
            txt_nameKhach.Text = DGV_KhachHang.Rows[rowindex].Cells[0].Value.ToString();
            rbtn_nam_Khach.Checked = DGV_KhachHang.Rows[rowindex].Cells[2].Value.ToString() == "Nam" ? true : false;
            rbtn_Nu_Khach.Checked = DGV_KhachHang.Rows[rowindex].Cells[2].Value.ToString() == "Nữ" ? true : false;
            txt_AddressKhach.Text = DGV_KhachHang.Rows[rowindex].Cells[3].Value.ToString();
            IdWhenClickkh = txt_SDTKhach.Text;
        }

        private void btn_SuaKhach_Click(object sender, EventArgs e)
        {
            if (CheckKhachHang())
            {
                var kh1 = KH_Bus.GetlissKhachHangs().FirstOrDefault(c => c.DienThoai == IdWhenClickkh);
                kh1.DienThoai = txt_SDTKhach.Text;
                kh1.TenKhach = txt_nameKhach.Text;
                kh1.GioiTinh = rbtn_nam_Khach.Checked ? 1 : 0;
                kh1.DiaChi = txt_AddressKhach.Text;
                if (MessageBox.Show($"bạn có muốn Sửa thông tin của khách hàng {kh1.TenKhach} Không?", Error,
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MessageBox.Show(KH_Bus.Edit_KhachHang(kh1), Error);
                }
                loadDGV_Khachhang();
            }
        }

        private void btn_XoaKhach_Click(object sender, EventArgs e)
        {
            var kh1 = KH_Bus.GetlissKhachHangs().FirstOrDefault(c => c.DienThoai == IdWhenClickkh);
            if (MessageBox.Show($"bạn có muốn Xóa thông tin của khách hàng {kh1.TenKhach} Không?", Error,
                MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            foreach (var x in KH_Bus.GetlissKhachHangs().Where(c => c.TenKhach.StartsWith(txt_TimKhach.Text) && c.flag == true))
            {
                DGV_KhachHang.Rows.Add(x.TenKhach, x.DienThoai, x.GioiTinh == 1 ? "Nam" : x.GioiTinh == 0 ? "Nữ" : "",
                    x.DiaChi,
                    nv_BUS.getListNhanVien_BUS().Where(c => c.MaNV == x.MaNV).Select(c => c.TenNv).FirstOrDefault());
            }
        }

        private void txt_TimKhach_MouseDown(object sender, MouseEventArgs e)
        {
            txt_TimKhach.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txt_TimKhach.Text = "";
            txt_SDTKhach.Text = "";
            txt_nameKhach.Text = "";
            txt_diaChiNV.Text = "";
            rbtn_nam_Khach.Checked = true;
        }

        #endregion

        #region TAB PAGE SẢN PHẨM

        void loadData_SP()
        {
            DGV_hang.ColumnCount = 8;
            DGV_hang.Columns[0].Name = " Mã hàng";
            DGV_hang.Columns[0].Visible = false;
            DGV_hang.Columns[1].Name = "  Tên Sản Phẩm";
            DGV_hang.Columns[2].Name = "  Số Lượng";
            DGV_hang.Columns[3].Name = "  Đơn Giá Nhập ";
            DGV_hang.Columns[4].Name = "  Đơn Giá Xuất";
            DGV_hang.Columns[5].Name = "  Ghi Chú ";
            DGV_hang.Columns[6].Name = " Nhân Viên bán";
            DGV_hang.Columns[7].Name = "Ảnh";
            DGV_hang.Columns[7].Visible = false;


            //DataGridViewButtonColumn button1 = new DataGridViewButtonColumn();
            //{

            //    button1.Name = "Dẫn Ảnh";
            //    button1.HeaderText = "Dẫn Ảnh";
            //    button1.Text = "Dẫn Ảnh";
            //    button1.UseColumnTextForButtonValue = true; //dont forget this line
            //    this.DGV_hang.Columns.Add(button1);

            //}
            DataGridViewComboBoxColumn cbService = new DataGridViewComboBoxColumn();
            {
                cbService.Name = "Option";
                cbService.HeaderText = " Option";
                cbService.Items.Add("Create");
                cbService.Items.Add("Edit");
                cbService.Items.Add("Remove");

                DGV_hang.Columns.Add(cbService);
            }

            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "Select";
                button.HeaderText = "Select";
                button.Text = "Select";
                button.UseColumnTextForButtonValue = true; //dont forget this line
                this.DGV_hang.Columns.Add(button);
            }
            DGV_hang.Rows.Clear();

            foreach (var x in sp_BUS.getlisHangs())
            {
                DGV_hang.Rows.Add(x.MaHang, x.TenHang, x.SoLuong == 0 ? "Hết hàng" : $"{x.SoLuong}", x.DonGiaNhap, x.DonGiaBan, x.GhiChu,
                    nv_BUS.getListNhanVien_BUS().Where(c => c.MaNV == x.MaNV).Select(c => c.TenNv).FirstOrDefault());
            }

            //DataGridViewImageColumn img = new DataGridViewImageColumn();
            //{
            //    img.HeaderText = "Hình ảnh đã tải lên";
            //    img.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //    img.Image = image;
            //    DGV_hang.Columns.Insert(7, img);
            //    img.HeaderText = "Image";
            //    img.Name = "img";

            //}

        }

        private void DGV_hang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // int rowindex = e.RowIndex;
            //int idhang= Convert.ToInt32(DGV_hang.Rows[rowindex].Cells[0].Value.ToString());
            //var Sp = sp_BUS.getlisHangs().Where(c => c.MaHang == idhang).Select(c=>c.HinhAnh).FirstOrDefault();
            // pt_hang.Image= Image.FromFile(Sp);

            //if (e.ColumnIndex == DGV_hang.Columns["Dẫn Ảnh"].Index)
            //{
            //    // open file dialog   
            //    OpenFileDialog open = new OpenFileDialog();
            //    // image filters  
            //    open.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            //    open.FilterIndex = 2;
            //    open.Title = "Chọn Ảnh Minh Họa";
            //    if (open.ShowDialog() == DialogResult.OK)
            //    {
            //        fileAddress = open.FileName;
            //        // display image in picture box  
            //        pt_hang.Image = Image.FromFile(fileAddress);
            //        pt_hang.SizeMode = PictureBoxSizeMode.StretchImage;
            //        fileName = Path.GetFileName(open.FileName);
            //        string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            //        // image file path  
            //        txt_linkAnh.Text = "\\image\\" + fileName;

            //    }
            //}
            int row = e.RowIndex;
            //bool CheckSP()
            //{
            //    if (Check.checkNull(DGV_hang.Rows[row].Cells[1].Value.ToString()))
            //    {
            //        MessageBox.Show("Không được để trống Tên SP");
            //        return false;
            //    }
            //    if (Check.checkNull(DGV_hang.Rows[row].Cells[2].Value.ToString()))
            //    {
            //        MessageBox.Show("Không được để trống Số Lượng SP");
            //        return false;
            //    }
            //    if (Check.checkNull(DGV_hang.Rows[row].Cells[3].Value.ToString()))
            //    {
            //        MessageBox.Show("Không được để trống Đơn giá Nhập SP");
            //        return false;
            //    }
            //    if (Check.checkNull(DGV_hang.Rows[row].Cells[4].Value.ToString()))
            //    {
            //        MessageBox.Show("Không được để trống Giá bán SP");
            //        return false;
            //    }
            //    if (Check.checkNull(DGV_hang.Rows[row].Cells[6].Value.ToString()))
            //    {
            //        MessageBox.Show("Không được để trống Tên người Nhập SP");
            //        return false;
            //    }
            //    if (Check.checkNull(DGV_hang.Rows[row].Cells[1].Value.ToString()))
            //    {
            //        MessageBox.Show("Không được để trống Tên SP");
            //        return false;
            //    }
            //    if (Check.checkSo(DGV_hang.Rows[row].Cells[2].Value.ToString()) == false)
            //    {
            //        MessageBox.Show("bạn nhập sai kiểu DL của  Số Lượng SP");
            //        return false;
            //    }
            //    if (Check.checkSo(DGV_hang.Rows[row].Cells[3].Value.ToString()) == false)
            //    {
            //        MessageBox.Show("bạn nhập sai kiểu DL của Đơn giá Nhập SP");
            //        return false;
            //    }
            //    if (Check.checkSo(DGV_hang.Rows[row].Cells[4].Value.ToString()) == false)
            //    {
            //        MessageBox.Show("bạn nhập sai kiểu DL của Giá bán SP");
            //        return false;
            //    }

            //    return true;
            //}

            if (e.ColumnIndex == DGV_hang.Columns["Select"].Index)
            {
                if (DGV_hang.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString() == "Create")
                {
                    //if (CheckSP())
                    //{
                        Hang sp = new Hang();
                        //sp.MaHang = sp_BUS.getlisHangs().Max(c => c.MaHang) + 1;
                        sp.TenHang = DGV_hang.Rows[row].Cells[1].Value.ToString();
                        sp.SoLuong = Convert.ToInt32(DGV_hang.Rows[row].Cells[2].Value);
                        sp.DonGiaNhap = double.Parse(DGV_hang.Rows[row].Cells[3].Value.ToString());
                        sp.DonGiaBan = double.Parse(DGV_hang.Rows[row].Cells[4].Value.ToString());
                        sp.GhiChu = DGV_hang.Rows[row].Cells[5].Value.ToString();
                        sp.MaNV = nv_BUS.getListNhanVien_BUS()
                            .Where(c => c.TenNv == DGV_hang.Rows[row].Cells[6].Value.ToString())
                            .Select(c => c.MaNV).FirstOrDefault();
                        if (MessageBox.Show("bạn có muốn thêm không??", Error, MessageBoxButtons.YesNo) ==
                            DialogResult.Yes)
                        {
                            MessageBox.Show(sp_BUS.Add_SanPham(sp), Error);
                        }
                    
                }

                if (DGV_hang.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString() == "Edit")
                {
                    //if (CheckSP())
                    //{


                        var sp = sp_BUS.getlisHangs()
                            .Where(c => c.MaHang == Convert.ToInt32(DGV_hang.Rows[row].Cells[0].Value.ToString()))
                            .FirstOrDefault();

                        sp.TenHang = DGV_hang.Rows[row].Cells[1].Value.ToString();
                        sp.SoLuong = Convert.ToInt32(DGV_hang.Rows[row].Cells[2].Value);
                        sp.DonGiaNhap = double.Parse(DGV_hang.Rows[row].Cells[3].Value.ToString());
                        sp.DonGiaBan = double.Parse(DGV_hang.Rows[row].Cells[4].Value.ToString());
                        sp.GhiChu = DGV_hang.Rows[row].Cells[5].Value.ToString();
                        sp.MaNV = nv_BUS.getListNhanVien_BUS()
                            .Where(c => c.TenNv == DGV_hang.Rows[row].Cells[6].Value.ToString())
                            .Select(c => c.MaNV).FirstOrDefault();
                        if (MessageBox.Show($"bạn có sửa thông tin SP {sp.TenHang} thêm không??", Error,
                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            MessageBox.Show(sp_BUS.Edit_SanPham(sp), Error);

                        }
                    //}
                }

                if (DGV_hang.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString() == "Remove")
                {

                    var sp = sp_BUS.getlisHangs()
                        .Where(c => c.MaHang == Convert.ToInt32(DGV_hang.Rows[row].Cells[0].Value.ToString()))
                        .FirstOrDefault();
                    if (MessageBox.Show($"bạn có muốn xóa SP {sp.TenHang} thêm không??", Error,
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        MessageBox.Show(sp_BUS.delete_SanPham(sp), Error);
                    }
                }

                loadData_SP();
            }
        }


        private void Btn_SaveHang_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"bạn có lưu không??", Error,
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show(sp_BUS.save_SanPham(), Error);
            }
        }



        private void frmQuan_Tri_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in filterInfoCollection)
                cboCamera.Items.Add(Device.Name);
            cboCamera.SelectedIndex = 1;
            videoCaptureDevice = new VideoCaptureDevice();
        }

        private void Btn_LOgout_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboCamera.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
            videoCaptureDevice.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BarcodeReader Reader = new BarcodeReader();
            Result result = Reader.Decode((Bitmap)pt_hang.Image);
            if (result != null)
                txt_Barcode.Text = result.ToString();
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //throw new NotImplementedException();
            pt_hang.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void frmQuan_Tri_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice.IsRunning == true)
            {
                videoCaptureDevice.Stop();
            }
        }

        private void Btn_listHang_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void DGV_hang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length-27));
            //int rowindex = e.RowIndex;
            //if (rowindex < 0 && rowindex > sp_BUS.getlisHangs().Count) return;
            //int idhang = Convert.ToInt32(DGV_hang.Rows[rowindex].Cells[0].Value.ToString());
            //var Sp = sp_BUS.getlisHangs().Where(c => c.MaHang == idhang).Select(c => c.HinhAnh).FirstOrDefault();
            //pt_hang.Image = Image.FromFile(saveDirectory+Sp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_timhang_KeyUp(object sender, KeyEventArgs e)
        {

            DGV_hang.ColumnCount = 8;
            DGV_hang.Columns[0].Name = " Mã hàng";
            DGV_hang.Columns[0].Visible = false;
            DGV_hang.Columns[1].Name = "  Tên Sản Phẩm";
            DGV_hang.Columns[2].Name = "  Số Lượng";
            DGV_hang.Columns[3].Name = "  Đơn Giá Nhập ";
            DGV_hang.Columns[4].Name = "  Đơn Giá Xuất";
            DGV_hang.Columns[5].Name = "  Ghi Chú ";
            DGV_hang.Columns[6].Name = " Nhân Viên bán";
            DGV_hang.Columns[7].Name = "Ảnh";
            DGV_hang.Columns[7].Visible = false;


            //DataGridViewButtonColumn button1 = new DataGridViewButtonColumn();
            //{

            //    button1.Name = "Dẫn Ảnh";
            //    button1.HeaderText = "Dẫn Ảnh";
            //    button1.Text = "Dẫn Ảnh";
            //    button1.UseColumnTextForButtonValue = true; //dont forget this line
            //    this.DGV_hang.Columns.Add(button1);

            //}
            DataGridViewComboBoxColumn cbService = new DataGridViewComboBoxColumn();
            {
                cbService.Name = "Option";
                cbService.HeaderText = " Option";
                cbService.Items.Add("Create");
                cbService.Items.Add("Edit");
                cbService.Items.Add("Remove");

                DGV_hang.Columns.Add(cbService);
            }

            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "Select";
                button.HeaderText = "Select";
                button.Text = "Select";
                button.UseColumnTextForButtonValue = true; //dont forget this line
                this.DGV_hang.Columns.Add(button);
            }
            DGV_hang.Rows.Clear();

            foreach (var x in sp_BUS.getlisHangs().Where(c=>c.TenHang.StartsWith(txt_timhang.Text)&& c.trangthai==true))
            {
                DGV_hang.Rows.Add(x.MaHang, x.TenHang, x.SoLuong == 0 ? "Hết hàng" : $"{x.SoLuong}", x.DonGiaNhap, x.DonGiaBan, x.GhiChu,
                    nv_BUS.getListNhanVien_BUS().Where(c => c.MaNV == x.MaNV).Select(c => c.TenNv).FirstOrDefault());
            }
        }

        bool CheckSpbarCode()
        {
            if (Check.checkNull(txt_Tenhang.Text))
            {
                MessageBox.Show("Không được để trống Tên SP");
                return false;
            }
            if (Check.checkNull(txt_SoLuong.Text))
            {
                MessageBox.Show("Không được để trống Số Lượng SP");
                return false;
            }
            if (Check.checkNull(txt_giaNhap.Text))
            {
                MessageBox.Show("Không được để trống Đơn giá Nhập SP");
                return false;
            }
            if (Check.checkNull(txt_giaBan.Text))
            {
                MessageBox.Show("Không được để trống Giá bán SP");
                return false;
            }

            if (Check.checkSo(txt_SoLuong.Text) == false)
            {
                MessageBox.Show("bạn nhập sai kiểu DL của  Số Lượng SP");
                return false;
            }
            if (Check.checkSo(txt_giaBan.Text) == false)
            {
                MessageBox.Show("bạn nhập sai kiểu DL của Đơn giá Nhập SP");
                return false;
            }
            if (Check.checkSo(txt_giaNhap.Text) == false)
            {
                MessageBox.Show("bạn nhập sai kiểu DL của Giá bán SP");
                return false;
            }

            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckSpbarCode())
            {
                Hang sp = new Hang();
                sp.TenHang = txt_Tenhang.Text;
                sp.SoLuong = Convert.ToInt32(txt_SoLuong.Text);
                sp.DonGiaNhap = double.Parse(txt_giaNhap.Text);
                sp.DonGiaBan = double.Parse(txt_giaBan.Text);
                sp.GhiChu = txt_note.Text;
                sp.MaNV = NvForKH.MaNV;
                sp.trangthai = true;
                if (MessageBox.Show("bạn có muốn thêm không??", Error, MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                {
                    MessageBox.Show(sp_BUS.Add_SanPham(sp), Error);
                }
            }

            loadData_SP();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            txt_Tenhang.Text = String.Empty;
            txt_SoLuong.Text = String.Empty;
            txt_giaNhap.Text = String.Empty;
            txt_giaBan.Text = String.Empty;
            txt_note.Text = String.Empty;
        }



        private void button3_Click(object sender, EventArgs e)
        {
            txt_Tenhang.Text = String.Empty;
            txt_SoLuong.Text = String.Empty;
            txt_giaNhap.Text = String.Empty;
            txt_giaBan.Text = String.Empty;
            txt_note.Text = String.Empty;
            var ListBarCode = sp_BUS.GetlisBarcodeSps().ToList();
            if (ListBarCode.Any(c => c.barCode == txt_Barcode.Text))
            {
                var spBarCode = ListBarCode.Where(c => c.barCode == txt_Barcode.Text).FirstOrDefault();
                txt_Tenhang.Text = spBarCode.TenHang;
                txt_SoLuong.Text = spBarCode.SoLuong.ToString();
                txt_giaNhap.Text = spBarCode.DonGiaNhap.ToString();
                txt_giaBan.Text = spBarCode.DonGiaBan.ToString();
                txt_note.Text = spBarCode.GhiChu;
            }
            else
            {
                MessageBox.Show(" Mã Vạch này đang được cập nhật.\n" +
                                " Xin thử lại sau!", Error);
            }

        }
        #endregion

        #region Thông Kê

        private void btn_nvNhaphang_Click(object sender, EventArgs e)
        {
            var maNhanVien = nv_BUS.getListNhanVien_BUS().Where(c => c.TenNv == txt_TenNV.Text).Select(c => c.MaNV)
                .FirstOrDefault();
            DGV_ThongKe.ColumnCount = 8;
            DGV_ThongKe.Columns[0].Name = " Mã hàng";
            DGV_ThongKe.Columns[1].Name = "  Tên Sản Phẩm";
            DGV_ThongKe.Columns[2].Name = "  Số Lượng";
            DGV_ThongKe.Columns[3].Name = "  Đơn Giá Nhập ";
            DGV_ThongKe.Columns[4].Name = "  Đơn Giá Xuất";
            DGV_ThongKe.Columns[5].Name = "  Ghi Chú ";
            DGV_ThongKe.Columns[6].Name = " Nhân Viên nhập";
            DGV_ThongKe.Rows.Clear();

            foreach (var x in sp_BUS.getlisHangs().Where(c => c.MaNV == maNhanVien))
            {
                DGV_ThongKe.Rows.Add(x.MaHang, x.TenHang, x.SoLuong, x.DonGiaNhap, x.DonGiaBan, x.GhiChu,
                    nv_BUS.getListNhanVien_BUS().Where(c => c.MaNV == x.MaNV).Select(c => c.TenNv).FirstOrDefault());
            }


        }

        private void btn_hangTon_Click(object sender, EventArgs e)
        {
            DGV_ThongKe.ColumnCount = 6;
            DGV_ThongKe.Columns[0].Name = "  Tên Sản Phẩm";
            DGV_ThongKe.Columns[1].Name = "  Số Lượng";
            DGV_ThongKe.Columns[2].Name = "  Đơn Giá Nhập ";
            DGV_ThongKe.Columns[3].Name = "  Đơn Giá Xuất";
            DGV_ThongKe.Columns[4].Name = "  Ghi Chú ";
            DGV_ThongKe.Columns[5].Name = " Nhân Viên nhập";
            DGV_ThongKe.Rows.Clear();

            foreach (var x in sp_BUS.getlisHangs().Where(c => c.SoLuong > 0 && c.trangthai == true))
            {
                DGV_ThongKe.Rows.Add(x.TenHang, x.SoLuong, x.DonGiaNhap, x.DonGiaBan, x.GhiChu,
                    nv_BUS.getListNhanVien_BUS().Where(c => c.MaNV == x.MaNV).Select(c => c.TenNv).FirstOrDefault());
            }

        }

        #endregion

        
    }
}





