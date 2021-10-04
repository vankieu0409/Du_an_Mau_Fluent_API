using System.Collections.Generic;
using DAL_QLBH.Entites;

namespace DAL_QLBH.InterfaceService
{
    public interface ISeviceNhanVien
    {
        public List<NhanVien> getListNhanVien();
        string AddNhanvien(NhanVien nv);
        string EditNhanVien(NhanVien nv);
        string DeleteNhanVien(NhanVien nv);
        string SaveData();
    }
}