using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL_QLBH.Migrations
{
    public partial class kieu3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "TinhTrang",
                table: "NHANVIEN1",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "trangthai",
                table: "KHACHHANG",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "trangthai",
                table: "Hangs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "trangthai",
                table: "KHACHHANG");

            migrationBuilder.DropColumn(
                name: "trangthai",
                table: "Hangs");

            migrationBuilder.AlterColumn<int>(
                name: "TinhTrang",
                table: "NHANVIEN1",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
