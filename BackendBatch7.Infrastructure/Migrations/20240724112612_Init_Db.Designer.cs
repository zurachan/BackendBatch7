﻿// <auto-generated />
using System;
using BackendBatch7.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendBatch7.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240724112612_Init_Db")]
    partial class Init_Db
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackendBatch7.Domain.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("department_name");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2658),
                            Department_name = "Hành chính",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2659),
                            Department_name = "Nhân sự",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2661),
                            Department_name = "Kỹ thuật",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2662),
                            Department_name = "Phát triển phần mềm",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2663),
                            Department_name = "Vận hành",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 6,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2664),
                            Department_name = "Hỗ trợ khách hàng",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("BackendBatch7.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("First_name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Last_name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("last_name");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2495),
                            Email = "admin@gmail.com",
                            First_name = "Admin first name",
                            IsDeleted = false,
                            Last_name = "Admin last name"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2506),
                            Email = "duonght@gmail.com",
                            First_name = "Hoàng Thái",
                            IsDeleted = false,
                            Last_name = "Dương"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2508),
                            Email = "thaotp@gmail.com",
                            First_name = "Trần Phương",
                            IsDeleted = false,
                            Last_name = "Thảo"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2509),
                            Email = "sophie@gmail.com",
                            First_name = "Hoàng Thị",
                            IsDeleted = false,
                            Last_name = "Sophie"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
