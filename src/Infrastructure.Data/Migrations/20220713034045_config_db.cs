using Microsoft.EntityFrameworkCore.Migrations;

namespace MargunStore.Infrastructure.Data.Migrations
{
    public partial class config_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Bag_BagId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BagId",
                table: "Product",
                newName: "IX_Product_BagId");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "User",
                type: "BIT",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Role",
                type: "BIT",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "ProductImages",
                type: "BIT",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Client",
                type: "BIT",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "BIT");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Bag",
                type: "BIT",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Address",
                type: "BIT",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Product",
                type: "BIT",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Bag_BagId",
                table: "Product",
                column: "BagId",
                principalTable: "Bag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Product_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Bag_BagId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Product_ProductId",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Bag");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_BagId",
                table: "Products",
                newName: "IX_Products_BagId");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Client",
                type: "BIT",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Products",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValue: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Bag_BagId",
                table: "Products",
                column: "BagId",
                principalTable: "Bag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
