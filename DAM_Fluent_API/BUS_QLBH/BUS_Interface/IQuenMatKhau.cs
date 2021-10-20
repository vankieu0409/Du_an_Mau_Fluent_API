using BUS_QLBH.Models;
using DAL_QLBH.Entites;

namespace BUS_QLBH.BUS_Interface
{
    public interface IQuenMatKhau
    {
        public PassCode SenderMail(string mail);
        public NhanVien nhanViens(string email);
        public string UpdatePass(NhanVien nv);
       
    }
}