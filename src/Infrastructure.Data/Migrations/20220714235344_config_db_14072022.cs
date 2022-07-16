using Microsoft.EntityFrameworkCore.Migrations;

namespace MargunStore.Infrastructure.Data.Migrations
{
    public partial class config_db_14072022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleId1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "User",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId1",
                table: "User",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId1",
                table: "User",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId1",
                table: "User",
                column: "RoleId1",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
