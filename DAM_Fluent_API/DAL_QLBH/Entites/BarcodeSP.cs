using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_QLBH.Entites
{
   [Table("BarCodeSP")]
    public class BarcodeSP
    {
        [Key]
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