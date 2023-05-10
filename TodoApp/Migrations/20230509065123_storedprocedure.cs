using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Migrations
{
    public partial class storedprocedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE OR ALTER PROCEDURE getalltodos
            AS
            BEGIN
                select * from Todos;
            END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE getalltodos";

            migrationBuilder.Sql(sp);
        }
    }
}
