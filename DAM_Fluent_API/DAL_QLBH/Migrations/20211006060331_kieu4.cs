using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL_QLBH.Migrations
{
    public partial class kieu4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaNv",
                table: "NHANVIEN1",
                newName: "MaNV");

            migrationBuilder.AlterColumn<string>(
                name: "MaNV",
                table: "KHACHHANG",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaNV",
                table: "Hangs",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaNV",
                table: "NHANVIEN1",
                newName: "MaNv");

            migrationBuilder.AlterColumn<string>(
                name: "MaNV",
                table: "KHACHHANG",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "MaNV",
                table: "Hangs",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");
        }
    }
}
