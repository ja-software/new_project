using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Persistance.Migrations
{
    public partial class AddRuleToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Folowed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rules", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("89f5e7cd-2cdf-4fbd-dd51-08d7f4f81e85"),
                columns: new[] { "BirthDate", "CreatedOn" },
                values: new object[] { new DateTime(2020, 9, 7, 0, 53, 53, 966, DateTimeKind.Local).AddTicks(8606), new DateTime(2020, 9, 7, 0, 53, 53, 966, DateTimeKind.Local).AddTicks(6977) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rules");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("89f5e7cd-2cdf-4fbd-dd51-08d7f4f81e85"),
                columns: new[] { "BirthDate", "CreatedOn" },
                values: new object[] { new DateTime(2020, 6, 2, 12, 32, 40, 336, DateTimeKind.Local).AddTicks(9216), new DateTime(2020, 6, 2, 12, 32, 40, 336, DateTimeKind.Local).AddTicks(6271) });
        }
    }
}
