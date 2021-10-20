using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DAL_QLBH.Entites
{
    [Table("KHACHHANG")]
    public class KhachHang
    {
        [Key]
        [StringLength(15)]
        public string DienThoai { get; set; }
        [Required]
        [StringLength(50)]
        public string TenKhach { get; set; }
        [Required]
        [StringLength(100)]
        public string DiaChi { get; set; }
        [Required]
        [StringLength(5)]
        public int GioiTinh { get; set; }
        [Required]
        public bool flag { get; set; }
    
        public string MaNV { get; set; } 
       [ForeignKey("MaNV")] public NhanVien KhachHangs { get; set; }
    }
}