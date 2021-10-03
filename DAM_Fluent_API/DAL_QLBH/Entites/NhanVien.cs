using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_QLBH.Entites
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Required]
        public int Id { get; set; }
        [Key]
        [StringLength(20)]
        public string MaNv { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string TenNv { get; set; }
        [Required]
        [StringLength(100)]
        public string DiaChi { get; set; }
        public int VaiTro { get; set; }
        public int TinhTrang { get; set; }
        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }
    }
}