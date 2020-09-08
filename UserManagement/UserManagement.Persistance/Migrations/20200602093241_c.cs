using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Persistance.Migrations
{
    public partial class c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("89f5e7cd-2cdf-4fbd-dd51-08d7f4f81e85"),
                columns: new[] { "BirthDate", "CreatedOn" },
                values: new object[] { new DateTime(2020, 6, 2, 12, 32, 40, 336, DateTimeKind.Local).AddTicks(9216), new DateTime(2020, 6, 2, 12, 32, 40, 336, DateTimeKind.Local).AddTicks(6271) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("89f5e7cd-2cdf-4fbd-dd51-08d7f4f81e85"),
                columns: new[] { "BirthDate", "CreatedOn" },
                values: new object[] { new DateTime(2020, 5, 16, 1, 11, 10, 293, DateTimeKind.Local).AddTicks(1701), new DateTime(2020, 5, 16, 1, 11, 10, 292, DateTimeKind.Local).AddTicks(9187) });
        }
    }
}
