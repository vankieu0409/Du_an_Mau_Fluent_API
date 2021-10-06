using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_QLBH.Entites
{
    public class Hang
    {
       
        public int MaHang { get; set; }
        [StringLength(50)]
        public string TenHang { get; set; }
        public int SoLuong { get; set; }
        public double DonGiaBan { get; set; }
        public double DonGiaNhap { get; set; }
        [Required]
        [StringLength(400)]
        public string HinhAnh { get; set; }
        [Required]
        [StringLength(20)]
        public string GhiChu { get; set; }
        [Required]
        public bool trangthai { get; set; }
        [Required]
        [StringLength(20)]
        public virtual NhanVien MaNv { get; set; }
    }
}