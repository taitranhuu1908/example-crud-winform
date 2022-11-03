using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manager.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 20, new DateTime(2022, 11, 3, 20, 30, 28, 482, DateTimeKind.Local).AddTicks(8855), false, "Huu Tai", new DateTime(2022, 11, 3, 20, 30, 28, 482, DateTimeKind.Local).AddTicks(8868) },
                    { 2L, 20, new DateTime(2022, 11, 3, 20, 30, 28, 482, DateTimeKind.Local).AddTicks(8914), false, "Huy Hieu", new DateTime(2022, 11, 3, 20, 30, 28, 482, DateTimeKind.Local).AddTicks(8915) },
                    { 3L, 21, new DateTime(2022, 11, 3, 20, 30, 28, 482, DateTimeKind.Local).AddTicks(8930), false, "Van Hoang", new DateTime(2022, 11, 3, 20, 30, 28, 482, DateTimeKind.Local).AddTicks(8931) },
                    { 4L, 20, new DateTime(2022, 11, 3, 20, 30, 28, 482, DateTimeKind.Local).AddTicks(8943), false, "Anh Kiet", new DateTime(2022, 11, 3, 20, 30, 28, 482, DateTimeKind.Local).AddTicks(8944) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
