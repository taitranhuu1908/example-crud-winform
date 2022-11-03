using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Manager.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ClassRoomId",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ClassRooms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRooms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ClassRooms",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[] { 1L, new DateTime(2022, 11, 3, 20, 38, 37, 223, DateTimeKind.Local).AddTicks(842), false, "CNTT K18 A", new DateTime(2022, 11, 3, 20, 38, 37, 223, DateTimeKind.Local).AddTicks(857) });

            migrationBuilder.InsertData(
                table: "ClassRooms",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[] { 2L, new DateTime(2022, 11, 3, 20, 38, 37, 223, DateTimeKind.Local).AddTicks(901), false, "Quản trị kinh doanh", new DateTime(2022, 11, 3, 20, 38, 37, 223, DateTimeKind.Local).AddTicks(902) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ClassRoomId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1L, new DateTime(2022, 11, 3, 20, 38, 37, 223, DateTimeKind.Local).AddTicks(922), new DateTime(2022, 11, 3, 20, 38, 37, 223, DateTimeKind.Local).AddTicks(923) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ClassRoomId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 2L, new DateTime(2022, 11, 3, 20, 38, 37, 223, DateTimeKind.Local).AddTicks(949), new DateTime(2022, 11, 3, 20, 38, 37, 223, DateTimeKind.Local).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ClassRoomId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1L, new DateTime(2022, 11, 3, 20, 38, 37, 223, DateTimeKind.Local).AddTicks(966), new DateTime(2022, 11, 3, 20, 38, 37, 223, DateTimeKind.Local).AddTicks(967) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "ClassRoomId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 2L, new DateTime(2022, 11, 3, 20, 38, 37, 223, DateTimeKind.Local).AddTicks(981), new DateTime(2022, 11, 3, 20, 38, 37, 223, DateTimeKind.Local).AddTicks(982) });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassRoomId",
                table: "Students",
                column: "ClassRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ClassRooms_ClassRoomId",
                table: "Students",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ClassRooms_ClassRoomId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "ClassRooms");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassRoomId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassRoomId",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 3, 20, 30, 28, 482, DateTimeKind.Local).AddTicks(8855), new DateTime(2022, 11, 3, 20, 30, 28, 482, DateTimeKind.Local).AddTicks(8868) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 3, 20, 30, 28, 482, DateTimeKind.Local).AddTicks(8914), new DateTime(2022, 11, 3, 20, 30, 28, 482, DateTimeKind.Local).AddTicks(8915) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 3, 20, 30, 28, 482, DateTimeKind.Local).AddTicks(8930), new DateTime(2022, 11, 3, 20, 30, 28, 482, DateTimeKind.Local).AddTicks(8931) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 3, 20, 30, 28, 482, DateTimeKind.Local).AddTicks(8943), new DateTime(2022, 11, 3, 20, 30, 28, 482, DateTimeKind.Local).AddTicks(8944) });
        }
    }
}
