using System.Collections.Generic;
using BUS_QLBH.BUS_Interface;
using DAL_QLBH.Entites;
using DAL_QLBH.InterfaceService;
using DAL_QLBH.Sevice;

namespace BUS_QLBH.BUS_SeVice
{
    public class ServiceNhanVien_BUS:IServiceNhanVien_BUS
    {
        private ISeviceNhanVien dalNhanVien;
        private List<NhanVien> lstNhanVienBUS;
        private NhanVien nhanVien;

        public ServiceNhanVien_BUS()
        {
            dalNhanVien = new SeviceNhanVien();
            lstNhanVienBUS = new List<NhanVien>();
            getListNhanVien_BUS();
        }

        public List<NhanVien> getListNhanVien_BUS()
        {
            return lstNhanVienBUS = dalNhanVien.getListNhanVien();
        }

        public string AddNhanvien_BUS(NhanVien nv)
        {
            return dalNhanVien.AddNhanvien(nv);
        }

        public string EditNhanVien_BUS(NhanVien nv)
        {
            return dalNhanVien.EditNhanVien(nv);
        }

        public string DeleteNhanVien_BUS(NhanVien nv)
        {
            return dalNhanVien.DeleteNhanVien(nv);
        }

        public string SaveData_BUS()
        {
            return dalNhanVien.SaveData();
        }
    }
}