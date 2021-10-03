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
        public string GioiTinh { get; set; }
        [Required]
        [StringLength(20)]
        public virtual NhanVien MaNv { get; set; }
    }
}