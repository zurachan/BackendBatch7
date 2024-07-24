using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendBatch7.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init_Db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    department_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "id", "CreatedBy", "CreatedDate", "department_name", "IsDeleted", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2658), "Hành chính", false, null, null },
                    { 2, "System", new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2659), "Nhân sự", false, null, null },
                    { 3, "System", new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2661), "Kỹ thuật", false, null, null },
                    { 4, "System", new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2662), "Phát triển phần mềm", false, null, null },
                    { 5, "System", new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2663), "Vận hành", false, null, null },
                    { 6, "System", new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2664), "Hỗ trợ khách hàng", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "CreatedBy", "CreatedDate", "email", "first_name", "IsDeleted", "last_name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2495), "admin@gmail.com", "Admin first name", false, "Admin last name", null, null },
                    { 2, "System", new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2506), "duonght@gmail.com", "Hoàng Thái", false, "Dương", null, null },
                    { 3, "System", new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2508), "thaotp@gmail.com", "Trần Phương", false, "Thảo", null, null },
                    { 4, "System", new DateTime(2024, 7, 24, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(2509), "sophie@gmail.com", "Hoàng Thị", false, "Sophie", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_email",
                table: "User",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
