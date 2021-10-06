using System.Collections.Generic;
using System.Linq;
using DAL_QLBH.DBContext;
using DAL_QLBH.Entites;
using DAL_QLBH.InterfaceService;

namespace DAL_QLBH.Sevice
{
    public class SeviceNhanVien : ISeviceNhanVien
    {
        private List<NhanVien> lsstNhanViens;
        private DBContext_kieu DB;

        public SeviceNhanVien()
        {
            lsstNhanViens = new List<NhanVien>();
            DB = new DBContext_kieu();
            activeDB();
        }

        public void activeDB()
        {
            lsstNhanViens = DB.NhanViens.ToList();
        }

        public List<NhanVien> getListNhanVien()
        {
            return lsstNhanViens;
        }

        public string AddNhanvien(NhanVien nv)
        {
            DB.NhanViens.Add(nv);
            return " thêm thành Công";
        }

        public string EditNhanVien(NhanVien nv)
        {
           
            if (DB.NhanViens.ToList().Any(c => c.MaNV == nv.MaNV))
            {
                DB.NhanViens.Update(nv);
                return " Sửa thành Công";
            }
            else
            {
                return " Sửa thành Công";
            }
        }

        public string DeleteNhanVien(NhanVien nv)
        {
            
            if (DB.NhanViens.ToList().Any(c => c.MaNV == nv.MaNV))
            {
                DB.NhanViens.Remove(nv);
                return " Xóa thành Công";
            }
            else
            {
                return " Xóa thành Công";
            }
        }

        public string SaveData()
        {
            DB.SaveChanges();
            return " Lưu Thành Công";
        }
    }
}