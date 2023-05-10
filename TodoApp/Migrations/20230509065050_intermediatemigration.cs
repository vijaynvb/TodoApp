using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Migrations
{
    public partial class intermediatemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 5, 10, 12, 20, 50, 187, DateTimeKind.Local).AddTicks(7310));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 5, 11, 12, 20, 50, 187, DateTimeKind.Local).AddTicks(7329));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2023, 5, 11, 12, 20, 50, 187, DateTimeKind.Local).AddTicks(7331));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 3, 21, 7, 57, 3, 14, DateTimeKind.Local).AddTicks(6002));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 3, 22, 7, 57, 3, 14, DateTimeKind.Local).AddTicks(6025));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2023, 3, 22, 7, 57, 3, 14, DateTimeKind.Local).AddTicks(6026));
        }
    }
}
