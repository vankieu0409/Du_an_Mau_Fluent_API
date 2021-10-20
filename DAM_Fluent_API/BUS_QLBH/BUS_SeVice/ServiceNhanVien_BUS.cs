using System.Collections.Generic;
using System.Linq;
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
            lstNhanVienBUS= dalNhanVien.getListNhanVien();
        }

        public List<NhanVien> getListNhanVien_BUS()
        {
            return lstNhanVienBUS; 
        }

        public string AddNhanvien_BUS(NhanVien nv)
        {
            nv.Id = lstNhanVienBUS.Max(c => c.Id) + 1;
            nv.MaNV = "NV" + nv.Id;
            lstNhanVienBUS.Add(nv);// Add thêm vào list
            return dalNhanVien.AddNhanvien(nv);
        }

        public string EditNhanVien_BUS(NhanVien nv)
        {
            lstNhanVienBUS[lstNhanVienBUS.FindIndex(c => c.MaNV == nv.MaNV)] = nv;
            return dalNhanVien.EditNhanVien(nv);
        }

        public string DeleteNhanVien_BUS(NhanVien nv)
        {
            lstNhanVienBUS.RemoveAt(lstNhanVienBUS.FindIndex(c => c.MaNV == nv.MaNV));
            return dalNhanVien.DeleteNhanVien(nv);
        }

        public string SaveData_BUS()
        {
            return dalNhanVien.SaveData();
        }
    }
}