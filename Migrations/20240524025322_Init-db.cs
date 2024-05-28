using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendBatch7.Migrations
{
    /// <inheritdoc />
    public partial class Initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "created_date", "email", "first_name", "is_deleted", "last_name", "updated_date" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9302), "nguyenvanA@gmail.com", "A", false, "Nguyen Van", null },
                    { 2, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9316), "nguyenvanB@gmail.com", "B", false, "Nguyen Van", null },
                    { 3, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9318), "nguyenvanC@gmail.com", "C", false, "Nguyen Van", null },
                    { 4, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9320), "nguyenvanD@gmail.com", "D", false, "Nguyen Van", null },
                    { 5, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9321), "nguyenvanE@gmail.com", "E", false, "Nguyen Van", null },
                    { 6, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9323), "nguyenvanF@gmail.com", "F", false, "Nguyen Van", null },
                    { 7, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9324), "nguyenvanG@gmail.com", "G", false, "Nguyen Van", null },
                    { 8, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9326), "nguyenvanH@gmail.com", "H", false, "Nguyen Van", null },
                    { 9, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9327), "nguyenvanI@gmail.com", "I", false, "Nguyen Van", null },
                    { 10, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9329), "nguyenvanJ@gmail.com", "J", false, "Nguyen Van", null },
                    { 11, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9330), "nguyenvanK@gmail.com", "K", false, "Nguyen Van", null },
                    { 12, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9332), "nguyenvanL@gmail.com", "L", false, "Nguyen Van", null },
                    { 13, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9333), "nguyenvanM@gmail.com", "M", false, "Nguyen Van", null },
                    { 14, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9335), "nguyenvanN@gmail.com", "N", false, "Nguyen Van", null },
                    { 15, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9336), "nguyenvanO@gmail.com", "O", false, "Nguyen Van", null },
                    { 16, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9338), "nguyenvanP@gmail.com", "P", false, "Nguyen Van", null },
                    { 17, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9339), "nguyenvanQ@gmail.com", "Q", false, "Nguyen Van", null },
                    { 18, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9340), "nguyenvanR@gmail.com", "R", false, "Nguyen Van", null },
                    { 19, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9342), "nguyenvanS@gmail.com", "S", false, "Nguyen Van", null },
                    { 20, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9343), "nguyenvanT@gmail.com", "T", false, "Nguyen Van", null },
                    { 21, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9345), "nguyenvanU@gmail.com", "U", false, "Nguyen Van", null },
                    { 22, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9346), "nguyenvanV@gmail.com", "V", false, "Nguyen Van", null },
                    { 23, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9348), "nguyenvanW@gmail.com", "W", false, "Nguyen Van", null },
                    { 24, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9349), "nguyenvanX@gmail.com", "X", false, "Nguyen Van", null },
                    { 25, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9422), "nguyenvanY@gmail.com", "Y", false, "Nguyen Van", null },
                    { 26, new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9423), "nguyenvanZ@gmail.com", "Z", false, "Nguyen Van", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_email",
                table: "user",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
