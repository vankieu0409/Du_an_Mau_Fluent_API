using System.Collections.Generic;
using DAL_QLBH.Entites;

namespace BUS_QLBH.BUS_Interface
{
    public interface IServiceSanPham_BUS
    {
        public List<Hang> getlisHangs();
        public string Add_SanPham(Hang sp);
        public string Edit_SanPham(Hang sp);
        public string delete_SanPham(Hang sp);
        public string save_SanPham();
    }
}