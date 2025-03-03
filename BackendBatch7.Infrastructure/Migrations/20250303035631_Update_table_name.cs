using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendBatch7.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_table_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_Department_DepartmentId",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_Role_RoleId",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_User_UserId",
                table: "Permission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission",
                table: "Permission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "Permission",
                newName: "permissions");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "departments");

            migrationBuilder.RenameIndex(
                name: "IX_Permission_UserId",
                table: "permissions",
                newName: "IX_permissions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Permission_RoleId",
                table: "permissions",
                newName: "IX_permissions_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Permission_DepartmentId",
                table: "permissions",
                newName: "IX_permissions_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_permissions",
                table: "permissions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_departments",
                table: "departments",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_permissions_departments_DepartmentId",
                table: "permissions",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_permissions_roles_RoleId",
                table: "permissions",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_permissions_users_UserId",
                table: "permissions",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permissions_departments_DepartmentId",
                table: "permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_permissions_roles_RoleId",
                table: "permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_permissions_users_UserId",
                table: "permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_permissions",
                table: "permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departments",
                table: "departments");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "permissions",
                newName: "Permission");

            migrationBuilder.RenameTable(
                name: "departments",
                newName: "Department");

            migrationBuilder.RenameIndex(
                name: "IX_permissions_UserId",
                table: "Permission",
                newName: "IX_Permission_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_permissions_RoleId",
                table: "Permission",
                newName: "IX_Permission_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_permissions_DepartmentId",
                table: "Permission",
                newName: "IX_Permission_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission",
                table: "Permission",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_Department_DepartmentId",
                table: "Permission",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_Role_RoleId",
                table: "Permission",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_User_UserId",
                table: "Permission",
                column: "UserId",
                principalTable: "User",
                principalColumn: "id");
        }
    }
}
