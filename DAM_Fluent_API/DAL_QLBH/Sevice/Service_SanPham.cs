using System.Collections.Generic;
using System.Linq;

using DAL_QLBH.DBContext;
using DAL_QLBH.Entites;
using DAL_QLBH.InterfaceService;

namespace DAL_QLBH.Sevice
{
    public class Service_SanPham : IServiceSanPham
    {
        private DBContext_kieu Db;
        private List<Hang> LstSanPhams;
        private List<BarcodeSP> _lstBarcodeSps;
        public Service_SanPham()
        {
            Db = new DBContext_kieu();
            LstSanPhams = new List<Hang>();
            LstSanPhams = Db.Hangs.ToList();
            _lstBarcodeSps = new List<BarcodeSP>();
            _lstBarcodeSps = Db.BarcodeSps.ToList();
        }
        public List<Hang> getlisHangs()
        {
            return LstSanPhams;
        }

        public string Add_SanPham(Hang sp)
        {
            Db.Hangs.Add(sp);
            return " thêm thành Công";
        }

        public string Edit_SanPham(Hang sp)
        {
            if (Db.Hangs.ToList().Any(c => c.MaHang == sp.MaHang))
            {
                Db.Hangs.Update(sp);
                return " Sửa thành Công";
            }
            else
            {
                return " Sửa thành Công";
            }

        }

        public string delete_SanPham(Hang sp)
        {
            sp.trangthai = false;
            if (Db.Hangs.ToList().Any(c => c.MaHang == sp.MaHang))
            {
                Db.Hangs.Update(sp);
                return " Xóa thành Công";
            }
            else
            {
                return " Xóa thành Công";
            }
        }

        public string save_SanPham()
        {
            Db.SaveChanges();
            return " Lưu Thành Công";
        }

        public List<BarcodeSP> GetlisBarcodeSps()
        {
            return _lstBarcodeSps;
        }
    }
}