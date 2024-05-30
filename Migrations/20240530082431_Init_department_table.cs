using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendBatch7.Migrations
{
    /// <inheritdoc />
    public partial class Init_department_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    department_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "department",
                columns: new[] { "id", "created_date", "department_name", "is_deleted", "updated_date" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 30, 15, 24, 28, 857, DateTimeKind.Local).AddTicks(7981), "Phát triển phần mềm", false, null },
                    { 2, new DateTime(2024, 5, 30, 15, 24, 28, 857, DateTimeKind.Local).AddTicks(7994), "Vận hành", false, null },
                    { 3, new DateTime(2024, 5, 30, 15, 24, 28, 857, DateTimeKind.Local).AddTicks(7996), "Hỗ trợ khách hàng", false, null }
                });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(167));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(173));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 3,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(175));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 4,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(177));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 5,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(178));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 6,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(180));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 7,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(181));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 8,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(183));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 9,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(184));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 10,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(186));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 11,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(187));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 12,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(189));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 13,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(190));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 14,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(192));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 15,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(193));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 16,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(194));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 17,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(196));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 18,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(197));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 19,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(198));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 20,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(200));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 21,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(201));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 22,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(203));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 23,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(204));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 24,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(205));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 25,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(207));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 26,
                column: "created_date",
                value: new DateTime(2024, 5, 30, 15, 24, 28, 858, DateTimeKind.Local).AddTicks(208));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9302));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 3,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 4,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9320));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 5,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9321));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 6,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 7,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9324));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 8,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9326));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 9,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9327));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 10,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9329));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 11,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 12,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 13,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9333));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 14,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9335));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 15,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9336));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 16,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9338));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 17,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9339));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 18,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 19,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9342));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 20,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9343));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 21,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 22,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 23,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 24,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9349));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 25,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9422));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 26,
                column: "created_date",
                value: new DateTime(2024, 5, 24, 9, 53, 22, 77, DateTimeKind.Local).AddTicks(9423));
        }
    }
}
