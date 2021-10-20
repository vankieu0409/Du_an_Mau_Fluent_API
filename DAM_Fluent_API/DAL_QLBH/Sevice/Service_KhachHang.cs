using System.Collections.Generic;
using System.Linq;
using DAL_QLBH.DBContext;
using DAL_QLBH.Entites;
using DAL_QLBH.InterfaceService;

namespace DAL_QLBH.Sevice
{
    public class Service_KhachHang:IServiceKhachHang
    {
        private List<KhachHang> listKahchHangs;
        private DBContext_kieu DB;
        public Service_KhachHang()
        {
            DB = new DBContext_kieu();
            listKahchHangs = new List<KhachHang>();
            listKahchHangs = DB.KhachHangs.ToList();
        }
        public List<KhachHang> GetListKaKhachHangs()
        {
            return listKahchHangs;
        }

        public string Add_Khachhang(KhachHang kh)
        {
            DB.KhachHangs.Add(kh);
            return " thêm thành Công";
        }

        public string Edit_KhachHang(KhachHang kh)
        {
            if (DB.KhachHangs.ToList().Any(c => c.DienThoai == kh.DienThoai))
            {
                DB.KhachHangs.Update(kh);
                return " Sửa thành Công";
            }
            else
            {
                return " Sửa thành Công";
            }

        }

        public string Delete_KhachHang(KhachHang kh)
        {
            
           if (DB.KhachHangs.ToList().Any(c => c.DienThoai == kh.DienThoai))
            {
                DB.KhachHangs.Remove(kh);
                return " Xóa thành Công";
            }
            else
            {
                return " Xóa thành Công";
            } 
        }

        public string Save_KhachHang()
        {
            DB.SaveChanges();
            return " Lưu Thành Công";
        }
        
    }
}