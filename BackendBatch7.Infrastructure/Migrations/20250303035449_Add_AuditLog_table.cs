using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendBatch7.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_AuditLog_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "audit_log",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user = table.Column<string>(type: "varchar(200)", nullable: false),
                    entity = table.Column<string>(type: "varchar(100)", nullable: false),
                    action = table.Column<string>(type: "varchar(20)", nullable: false),
                    timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    changes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_audit_log", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audit_log");
        }
    }
}
