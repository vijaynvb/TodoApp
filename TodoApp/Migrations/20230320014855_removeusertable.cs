using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Migrations
{
    public partial class removeusertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 3, 21, 7, 18, 55, 355, DateTimeKind.Local).AddTicks(1611));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 3, 22, 7, 18, 55, 355, DateTimeKind.Local).AddTicks(1628));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2023, 3, 22, 7, 18, 55, 355, DateTimeKind.Local).AddTicks(1630));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    First_Name = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "DOB", "Email", "First_Name" },
                values: new object[] { 1, new DateTime(2003, 3, 16, 13, 56, 44, 896, DateTimeKind.Local).AddTicks(7512), null, "Administrator" });

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
    }
}
