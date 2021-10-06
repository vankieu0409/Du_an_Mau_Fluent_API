using System.Collections.Generic;
using DAL_QLBH.Entites;

namespace DAL_QLBH.InterfaceService
{
    public interface IServiceKhachHang
    {
        public List<KhachHang> GetListKaKhachHangs();
        public string Add_Khachhang(KhachHang kh);
        public string Edit_KhachHang(KhachHang kh);
        public string Delete_KhachHang(KhachHang kh);
        public string Save_KhachHang();
    }
}