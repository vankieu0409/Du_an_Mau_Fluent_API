
using System.Threading;

using DAL_QLBH.Entites;

using Microsoft.EntityFrameworkCore;

namespace DAL_QLBH.DBContext
{
    public class DBContext_kieu : DbContext
    {
        //1. Kế thừa 1 cái phương thức OnConfiguring của lớp cha
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Khi cấu hình đổi tên DATABASE mà các bạn muốn nó tạo ra
                optionsBuilder.UseSqlServer(
                    "Data Source=desktop-nvb7s6l;Initial Catalog=DuAnMau_FluentAPI;Persist Security Info=True;User ID=kieu96;Password=123");
            }
        }

        //khai báo bảng
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<Hang> Hangs { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Gọi các API từ đối tượng entity để xây dựng bảng Product
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Hang>(entity =>
        //    {

        //        entity.HasKey(p => new { p.MaHang }); // thiết lập 2  khóa chính
        //        //entity.HasOne(e => e.MaNV)//thiết lập khóa ngoại
        //        //    .WithMany()
        //        //    .HasForeignKey("MaNV");// đặt tên cột khóa ngoại
        //    });
        //    modelBuilder.Entity<KhachHang>(entity =>
        //    {
        //        entity.HasKey(p => p.DienThoai);
        //        entity.HasOne<NhanVien>(p => p.MaNV)
        //            .WithMany(p=>p.MaNV)
        //            .HasForeignKey(c=>c.MaNV);
        //    });
        //    modelBuilder.Entity<NhanVien>(entity =>
        //    {
        //        entity.ToTable("NHANVIEN1");
        //    });

        //}
    }
}