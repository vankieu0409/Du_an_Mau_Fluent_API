using System.Collections.Generic;
using System.Linq;

using BUS_QLBH.BUS_Interface;
using BUS_QLBH.models;

using DAL_QLBH.Entites;
using DAL_QLBH.InterfaceService;
using DAL_QLBH.Sevice;

namespace BUS_QLBH.BUS_SeVice
{
    public class ServiceKhachHang_BUS : IServiceKhachHang_BUS
    {
        private IServiceKhachHang dalKhachHang;
        private ISeviceNhanVien dalNhanVien;
        private List<KhachHang> ListKhachHangs_BUS;
        private List<NhanVien> listNhanViens_kh_bus;
        private List<KH_NV> listKH_NV;

        public ServiceKhachHang_BUS()
        {
            dalKhachHang = new Service_KhachHang();
            ListKhachHangs_BUS = new List<KhachHang>();
            listKH_NV = new List<KH_NV>();
           ListKhachHangs_BUS = dalKhachHang.GetListKaKhachHangs();
           // listNhanViens_kh_bus = dalNhanVien.getListNhanVien();

        }

        public List<KhachHang> GetlissKhachHangs()
        {
            return ListKhachHangs_BUS;
        }
        public List<KH_NV> GetListKaKhachHangs()
        {
            var alistKH_NV = (from nhanVien in dalNhanVien.getListNhanVien()
                              join KhachHang in dalKhachHang.GetListKaKhachHangs() on nhanVien.MaNV equals KhachHang.MaNV
                              select new
                              {
                                  KhachHang.TenKhach,
                                  KhachHang.DienThoai,
                                  KhachHang.DiaChi,
                                  KhachHang.GioiTinh,
                                  KhachHang.trangthai,
                                  nhanVien.TenNv
                              }).ToList();
            foreach (var x in alistKH_NV)
            {
                KH_NV kk = new KH_NV();
                kk.DienThoai = x.DienThoai;
                kk.TenKhach = x.TenKhach;
                kk.GioiTinh = x.GioiTinh;
                kk.DiaChi = x.DiaChi;
                kk.NameNV = x.TenNv;
                kk.trangthai = x.trangthai;
                listKH_NV.Add(kk);

            }
            return listKH_NV;
        }
        public string Add_Khachhang(KhachHang kh)
        {
            ListKhachHangs_BUS.Add(kh);
            return dalKhachHang.Add_Khachhang(kh);
        }

        public string Edit_KhachHang(KhachHang kh)
        {
            ListKhachHangs_BUS[ListKhachHangs_BUS.FindIndex(c => c.DienThoai == kh.DienThoai)] = kh;
            return dalKhachHang.Edit_KhachHang(kh);
        }

        public string Delete_KhachHang(KhachHang kh)
        {
            kh.trangthai = false;
            ListKhachHangs_BUS[ListKhachHangs_BUS.FindIndex(c => c.DienThoai == kh.DienThoai)] = kh;
            return dalKhachHang.Delete_KhachHang(kh);
        }

        public string Save_KhachHang()
        {
            return dalKhachHang.Save_KhachHang();
        }
    }
}