﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoApp.Data;

#nullable disable

namespace TodoApp.Migrations
{
    [DbContext(typeof(TodoDbContext))]
    [Migration("20230320014855_removeusertable")]
    partial class removeusertable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TodoApp.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Todos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "For Birthday",
                            DueDate = new DateTime(2023, 3, 21, 7, 18, 55, 355, DateTimeKind.Local).AddTicks(1611),
                            Status = false,
                            Title = "Shopping"
                        },
                        new
                        {
                            Id = 2,
                            Description = "In Jump Trainin",
                            DueDate = new DateTime(2023, 3, 22, 7, 18, 55, 355, DateTimeKind.Local).AddTicks(1628),
                            Status = false,
                            Title = "Learn C#"
                        },
                        new
                        {
                            Id = 3,
                            Description = "In Jump Trainin",
                            DueDate = new DateTime(2023, 3, 22, 7, 18, 55, 355, DateTimeKind.Local).AddTicks(1630),
                            Status = false,
                            Title = "Learn MSSQL"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
