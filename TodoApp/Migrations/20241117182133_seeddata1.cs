using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Migrations
{
    public partial class seeddata1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "381e1407-e63c-47c7-919f-38cc3a7773dc", "da8d41dc-7a6c-4622-9480-98406f5aa364", "Admin", "ADMIN" },
                    { "9d49b6f6-dbb6-41ca-b227-5f131f351a61", "e17e1c27-9f60-4fa9-b28d-7c13e15f4159", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "54037ed5-5caf-4301-a224-4baa48d9413a", 0, "4d972c0f-9730-4801-823a-c45020352a59", null, "user@g.com", false, "User", "U", false, null, null, "USER", "AQAAAAEAACcQAAAAECFqouYJggLCGCCAL50vmJe+JfEKgOxa0srYhJz2iNKfmntkBhOCcj1P4uWOhHN0yA==", null, false, "a5422003-d7d1-4b0f-bc0e-9b0d8adddec8", false, "user@g.com" },
                    { "a3e368c3-2f29-4b41-a325-7e0cb1c8af5c", 0, "e55a46a5-5361-427a-b34f-4538ee0e98f4", null, "admin@g.com", false, "Admin", "A", false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEDk/X6EJxXpT7Sn54QNdH9UVvg5rtmYivc9Cmvi242yFVlPcxGD2kh2V3Upk0Z+5JA==", null, false, "eb47aae8-22d9-4555-b5d7-33cc0d76f214", false, "admin@g.com" }
                });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2024, 11, 18, 23, 51, 33, 446, DateTimeKind.Local).AddTicks(4544));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "DueDate" },
                values: new object[] { "In Jump Training", new DateTime(2024, 11, 19, 23, 51, 33, 446, DateTimeKind.Local).AddTicks(4580) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "DueDate" },
                values: new object[] { "In Jump Training", new DateTime(2024, 11, 19, 23, 51, 33, 446, DateTimeKind.Local).AddTicks(4583) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "381e1407-e63c-47c7-919f-38cc3a7773dc", "54037ed5-5caf-4301-a224-4baa48d9413a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9d49b6f6-dbb6-41ca-b227-5f131f351a61", "a3e368c3-2f29-4b41-a325-7e0cb1c8af5c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "381e1407-e63c-47c7-919f-38cc3a7773dc", "54037ed5-5caf-4301-a224-4baa48d9413a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9d49b6f6-dbb6-41ca-b227-5f131f351a61", "a3e368c3-2f29-4b41-a325-7e0cb1c8af5c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "381e1407-e63c-47c7-919f-38cc3a7773dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d49b6f6-dbb6-41ca-b227-5f131f351a61");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54037ed5-5caf-4301-a224-4baa48d9413a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3e368c3-2f29-4b41-a325-7e0cb1c8af5c");

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 5, 10, 12, 58, 11, 850, DateTimeKind.Local).AddTicks(5592));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "DueDate" },
                values: new object[] { "In Jump Trainin", new DateTime(2023, 5, 11, 12, 58, 11, 850, DateTimeKind.Local).AddTicks(5617) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "DueDate" },
                values: new object[] { "In Jump Trainin", new DateTime(2023, 5, 11, 12, 58, 11, 850, DateTimeKind.Local).AddTicks(5619) });
        }
    }
}
