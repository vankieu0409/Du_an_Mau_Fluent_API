using System.ComponentModel.DataAnnotations;

namespace DAL_QLBH.Entites
{
    public class BarcodeSP
    {
        [StringLength(50)]
        public string TenHang { get; set; }
        public int SoLuong { get; set; }
        public double DonGiaBan { get; set; }
        public double DonGiaNhap { get; set; }
        [Required]
        [StringLength(400)]
        public string barCode { get; set; }
        [Required]
        [StringLength(20)]
        public string? GhiChu { get; set; }
        
    }
}