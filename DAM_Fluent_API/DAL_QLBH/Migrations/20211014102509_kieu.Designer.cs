﻿// <auto-generated />
using System;
using DAL_QLBH.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL_QLBH.Migrations
{
    [DbContext(typeof(DBContext_kieu))]
    [Migration("20211014102509_kieu")]
    partial class kieu
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL_QLBH.Entites.Hang", b =>
                {
                    b.Property<int>("MaHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DonGiaBan")
                        .HasColumnType("float");

                    b.Property<double>("DonGiaNhap")
                        .HasColumnType("float");

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<byte?>("HinhAnh")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("tinyint");

                    b.Property<string>("MaNV")
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenHang")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("trangthai")
                        .HasColumnType("bit");

                    b.HasKey("MaHang");

                    b.HasIndex("MaNV");

                    b.ToTable("HANG");
                });

            modelBuilder.Entity("DAL_QLBH.Entites.KhachHang", b =>
                {
                    b.Property<string>("DienThoai")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("GioiTinh")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<string>("MaNV")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TenKhach")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("trangthai")
                        .HasColumnType("bit");

                    b.HasKey("DienThoai");

                    b.HasIndex("MaNV");

                    b.ToTable("KHACHHANG");
                });

            modelBuilder.Entity("DAL_QLBH.Entites.NhanVien", b =>
                {
                    b.Property<string>("MaNV")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenNv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("TinhTrang")
                        .HasColumnType("bit");

                    b.Property<int>("VaiTro")
                        .HasColumnType("int");

                    b.HasKey("MaNV");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("DAL_QLBH.Entites.Hang", b =>
                {
                    b.HasOne("DAL_QLBH.Entites.NhanVien", "KhachHangs")
                        .WithMany("Hangs")
                        .HasForeignKey("MaNV");

                    b.Navigation("KhachHangs");
                });

            modelBuilder.Entity("DAL_QLBH.Entites.KhachHang", b =>
                {
                    b.HasOne("DAL_QLBH.Entites.NhanVien", "KhachHangs")
                        .WithMany("KhachHangs")
                        .HasForeignKey("MaNV");

                    b.Navigation("KhachHangs");
                });

            modelBuilder.Entity("DAL_QLBH.Entites.NhanVien", b =>
                {
                    b.Navigation("Hangs");

                    b.Navigation("KhachHangs");
                });
#pragma warning restore 612, 618
        }
    }
}