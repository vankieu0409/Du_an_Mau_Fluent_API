using System.Collections.Generic;
using DAL_QLBH.Entites;

namespace DAL_QLBH.InterfaceService
{
    public interface IServiceSanPham
    {
        public List<Hang> getlisHangs();
        public string Add_SanPham(Hang sp);
        public string Edit_SanPham(Hang sp);
        public string delete_SanPham(Hang sp);
        public string save_SanPham();
        List<BarcodeSP> GetlisBarcodeSps();


    }
}