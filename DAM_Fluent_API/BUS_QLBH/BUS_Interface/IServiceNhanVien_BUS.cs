using System.Collections.Generic;
using DAL_QLBH.Entites;


namespace BUS_QLBH.BUS_Interface
{
    public interface IServiceNhanVien_BUS
    {
        public List<NhanVien> getListNhanVien_BUS();
        string AddNhanvien_BUS(NhanVien nv);
        string EditNhanVien_BUS(NhanVien nv);
        string DeleteNhanVien_BUS(NhanVien nv);
        string SaveData_BUS();
    }
}