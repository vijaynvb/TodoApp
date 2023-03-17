using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Migrations
{
    public partial class seedatatodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "DOB",
                value: new DateTime(2003, 3, 16, 10, 1, 4, 912, DateTimeKind.Local).AddTicks(3905));

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Description", "DueDate", "Status", "Title" },
                values: new object[,]
                {
                    { 1, "For Birthday", new DateTime(2023, 3, 17, 10, 1, 4, 912, DateTimeKind.Local).AddTicks(4108), false, "Shopping" },
                    { 2, "In Jump Trainin", new DateTime(2023, 3, 18, 10, 1, 4, 912, DateTimeKind.Local).AddTicks(4148), false, "Learn C#" },
                    { 3, "In Jump Trainin", new DateTime(2023, 3, 18, 10, 1, 4, 912, DateTimeKind.Local).AddTicks(4150), false, "Learn MSSQL" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "DOB",
                value: new DateTime(2003, 3, 16, 9, 41, 50, 520, DateTimeKind.Local).AddTicks(6596));
        }
    }
}
