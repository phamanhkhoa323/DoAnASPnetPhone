using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnASPnetPhone.Migrations
{
    public partial class FulDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hangsanxuat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mahang = table.Column<int>(type: "int", nullable: false),
                    Tenhang = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hangsanxuat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hedieuhanh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mahdh = table.Column<int>(type: "int", nullable: false),
                    Tenhdh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hedieuhanh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phanquyen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDQuyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenquyen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phanquyen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sanpham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Masp = table.Column<int>(type: "int", nullable: false),
                    Tensp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Giatien = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anhbia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HangsanxuatId = table.Column<int>(type: "int", nullable: false),
                    HedieuhanhId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanpham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sanpham_Hangsanxuat_HangsanxuatId",
                        column: x => x.HangsanxuatId,
                        principalTable: "Hangsanxuat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sanpham_Hedieuhanh_HedieuhanhId",
                        column: x => x.HedieuhanhId,
                        principalTable: "Hedieuhanh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nguoidung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNguoiDung = table.Column<int>(type: "int", nullable: false),
                    Hoten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Matkhau = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Dienthoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhanquyenId = table.Column<int>(type: "int", nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nguoidung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nguoidung_Phanquyen_PhanquyenId",
                        column: x => x.PhanquyenId,
                        principalTable: "Phanquyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Donhang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Madon = table.Column<int>(type: "int", nullable: false),
                    Ngaydat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tinhtrang = table.Column<bool>(type: "bit", nullable: false),
                    NguoidungId = table.Column<int>(type: "int", nullable: false),
                    Tongtien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donhang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donhang_Nguoidung_NguoidungId",
                        column: x => x.NguoidungId,
                        principalTable: "Nguoidung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Giohang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoidungId = table.Column<int>(type: "int", nullable: false),
                    SanphamId = table.Column<int>(type: "int", nullable: false),
                    SoLuongMua = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giohang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Giohang_Nguoidung_NguoidungId",
                        column: x => x.NguoidungId,
                        principalTable: "Nguoidung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Giohang_Sanpham_SanphamId",
                        column: x => x.SanphamId,
                        principalTable: "Sanpham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chitietdonhang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonhangId = table.Column<int>(type: "int", nullable: false),
                    SanphamId = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Dongia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chitietdonhang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chitietdonhang_Donhang_DonhangId",
                        column: x => x.DonhangId,
                        principalTable: "Donhang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chitietdonhang_Sanpham_SanphamId",
                        column: x => x.SanphamId,
                        principalTable: "Sanpham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chitietdonhang_DonhangId",
                table: "Chitietdonhang",
                column: "DonhangId");

            migrationBuilder.CreateIndex(
                name: "IX_Chitietdonhang_SanphamId",
                table: "Chitietdonhang",
                column: "SanphamId");

            migrationBuilder.CreateIndex(
                name: "IX_Donhang_NguoidungId",
                table: "Donhang",
                column: "NguoidungId");

            migrationBuilder.CreateIndex(
                name: "IX_Giohang_NguoidungId",
                table: "Giohang",
                column: "NguoidungId");

            migrationBuilder.CreateIndex(
                name: "IX_Giohang_SanphamId",
                table: "Giohang",
                column: "SanphamId");

            migrationBuilder.CreateIndex(
                name: "IX_Nguoidung_PhanquyenId",
                table: "Nguoidung",
                column: "PhanquyenId");

            migrationBuilder.CreateIndex(
                name: "IX_Sanpham_HangsanxuatId",
                table: "Sanpham",
                column: "HangsanxuatId");

            migrationBuilder.CreateIndex(
                name: "IX_Sanpham_HedieuhanhId",
                table: "Sanpham",
                column: "HedieuhanhId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chitietdonhang");

            migrationBuilder.DropTable(
                name: "Giohang");

            migrationBuilder.DropTable(
                name: "Donhang");

            migrationBuilder.DropTable(
                name: "Sanpham");

            migrationBuilder.DropTable(
                name: "Nguoidung");

            migrationBuilder.DropTable(
                name: "Hangsanxuat");

            migrationBuilder.DropTable(
                name: "Hedieuhanh");

            migrationBuilder.DropTable(
                name: "Phanquyen");
        }
    }
}
