using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Migrations
{
    public partial class spgettodobyid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE OR ALTER PROCEDURE gettodobyid(@todoId AS INT)
            AS
            BEGIN
                select * from Todos where Id = @todoId;
            END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE gettodobyid";

            migrationBuilder.Sql(sp);
        }
    }
}
