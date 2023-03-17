using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Migrations
{
    public partial class useremailadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "DOB",
                value: new DateTime(2003, 3, 16, 13, 56, 44, 896, DateTimeKind.Local).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 3, 17, 13, 56, 44, 896, DateTimeKind.Local).AddTicks(7787));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 3, 18, 13, 56, 44, 896, DateTimeKind.Local).AddTicks(7802));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2023, 3, 18, 13, 56, 44, 896, DateTimeKind.Local).AddTicks(7804));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "People");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "DOB",
                value: new DateTime(2003, 3, 16, 10, 1, 4, 912, DateTimeKind.Local).AddTicks(3905));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 3, 17, 10, 1, 4, 912, DateTimeKind.Local).AddTicks(4108));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 3, 18, 10, 1, 4, 912, DateTimeKind.Local).AddTicks(4148));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2023, 3, 18, 10, 1, 4, 912, DateTimeKind.Local).AddTicks(4150));
        }
    }
}
