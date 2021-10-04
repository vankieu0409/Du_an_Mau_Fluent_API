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
            nv.Id = lsstNhanViens.Max(c => c.Id) + 1;
            nv.MaNv = "NV" + nv.Id;
            lsstNhanViens.Add(nv);// Add thêm vào list
            DB.NhanViens.Add(nv);
            return " thêm thành Công";
        }

        public string EditNhanVien(NhanVien nv)
        {
            lsstNhanViens[lsstNhanViens.FindIndex(c => c.MaNv == nv.MaNv)] = nv;
            if (DB.NhanViens.ToList().Any(c => c.MaNv == nv.MaNv))
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
            lsstNhanViens.RemoveAt(lsstNhanViens.FindIndex(c => c.MaNv == nv.MaNv));
            if (DB.NhanViens.ToList().Any(c => c.MaNv == nv.MaNv))
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