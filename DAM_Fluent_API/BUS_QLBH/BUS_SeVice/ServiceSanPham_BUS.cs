using System.Collections.Generic;
using BUS_QLBH.BUS_Interface;
using DAL_QLBH.Entites;
using DAL_QLBH.InterfaceService;
using DAL_QLBH.Sevice;

namespace BUS_QLBH.BUS_SeVice
{
    public class ServiceSanPham_BUS:IServiceSanPham_BUS
    {
        private List<Hang> LstSanPhams;
        private IServiceSanPham SP;

        public ServiceSanPham_BUS()
        {
            LstSanPhams = new List<Hang>();
            SP = new Service_SanPham();
            LstSanPhams = SP.getlisHangs();
        }
        public List<Hang> getlisHangs()
        {
            return LstSanPhams;
        }

        public string Add_SanPham(Hang sp)
        {
            LstSanPhams.Add(sp);
            return SP.Add_SanPham(sp);
        }

        public string Edit_SanPham(Hang sp)
        {
            LstSanPhams[LstSanPhams.FindIndex(c => c.MaHang == sp.MaHang)] = sp;
            return SP.Edit_SanPham(sp);
        }

        public string delete_SanPham(Hang sp)
        {
            LstSanPhams.RemoveAt(LstSanPhams.FindIndex(c => c.MaHang == sp.MaHang));
            return SP.delete_SanPham(sp);
        }

        public string save_SanPham()
        {
            return SP.save_SanPham();
        }
    }
}