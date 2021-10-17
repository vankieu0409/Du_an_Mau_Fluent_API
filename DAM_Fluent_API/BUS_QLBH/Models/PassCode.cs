namespace BUS_QLBH.Models
{
    public class PassCode
    {

        public string pass { get; set; }
        public string code { get; set; }

        public PassCode(string pass, string code)
        {
            this.pass = pass;
            this.code = code;
        }
    }
}