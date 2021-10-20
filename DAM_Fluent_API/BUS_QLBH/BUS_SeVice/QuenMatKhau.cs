using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

using BUS_QLBH.BUS_Interface;
using BUS_QLBH.Models;

using DAL_QLBH.Entites;
using DAL_QLBH.InterfaceService;
using DAL_QLBH.Sevice;

namespace BUS_QLBH.BUS_SeVice
{
    public class QuenMatKhau : IQuenMatKhau
    {
        private ISeviceNhanVien nv1;
        private PassCode _sendPassCode;
        private List<NhanVien> _lstNhanViens;

        private string _email;
        private string _pass;
        private string _code;
        public QuenMatKhau()
        {
            nv1 = new SeviceNhanVien();
            _lstNhanViens = new List<NhanVien>();
            _lstNhanViens = nv1.getListNhanVien();
        }
        public string PassRandom(int lengthCode)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";//String char for random password
            var random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, lengthCode)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }
        public string MaHoaPass(string password)
        {
            //Tạo MD5 
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public PassCode SenderMail(string mail)
        {

            _pass = PassRandom(6);
            _code = PassRandom(6);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
            NetworkCredential cred = new NetworkCredential("kieunvph14806@fpt.edu.vn", "kieubeu0409");
            MailMessage mgs = new MailMessage();
            mgs.From = new MailAddress("kieunvph14806@fpt.edu.vn");
            mgs.To.Add(mail);
            mgs.Subject = "Quên mật khẩu";
            mgs.Body = "Mật khẩu mới là: " + _pass + "\nMã xác nhận của bạn là :" + _code + "\n Mã sẽ vô hiệu lực sau 1 phút";
            client.Credentials = cred;
            client.EnableSsl = true;
            client.Send(mgs);
            _sendPassCode = new PassCode(_pass, _code);
            return _sendPassCode;

        }
        public NhanVien nhanViens(string email)
        {

            return _lstNhanViens.Where(c => c.Email == email).FirstOrDefault();


        }

        public string UpdatePass(NhanVien nv)
        {
            nv1.EditNhanVien(nv);
            nv1.SaveData();
            return "Mật khẩu đã được đổi thành công";

        }
    }
}