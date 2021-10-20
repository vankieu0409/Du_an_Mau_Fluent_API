namespace BUS_QLBH.BUS_Interface
{
    public interface ICheck
    {
        public bool checkSDT(string sdt);
        public bool checkEmail(string email);
        public bool checkChu(string test);
        public bool checkSo(string test);
        public bool checkNull(string text);
    }
}