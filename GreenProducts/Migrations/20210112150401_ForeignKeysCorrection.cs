using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenProducts.Migrations
{
    public partial class ForeignKeysCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CurrentCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ImpactCategories_CurrentImpactId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Supermarket_Products_Products_CurrentProductId",
                table: "Supermarket_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Supermarket_Products_Supermarkets_CurrentSupermarketId",
                table: "Supermarket_Products");

            migrationBuilder.RenameColumn(
                name: "CurrentSupermarketId",
                table: "Supermarket_Products",
                newName: "SupermarketId");

            migrationBuilder.RenameColumn(
                name: "CurrentProductId",
                table: "Supermarket_Products",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Supermarket_Products_CurrentSupermarketId",
                table: "Supermarket_Products",
                newName: "IX_Supermarket_Products_SupermarketId");

            migrationBuilder.RenameIndex(
                name: "IX_Supermarket_Products_CurrentProductId",
                table: "Supermarket_Products",
                newName: "IX_Supermarket_Products_ProductId");

            migrationBuilder.RenameColumn(
                name: "CurrentImpactId",
                table: "Products",
                newName: "ImpactId");

            migrationBuilder.RenameColumn(
                name: "CurrentCategoryId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CurrentImpactId",
                table: "Products",
                newName: "IX_Products_ImpactId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CurrentCategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ImpactCategories_ImpactId",
                table: "Products",
                column: "ImpactId",
                principalTable: "ImpactCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supermarket_Products_Products_ProductId",
                table: "Supermarket_Products",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supermarket_Products_Supermarkets_SupermarketId",
                table: "Supermarket_Products",
                column: "SupermarketId",
                principalTable: "Supermarkets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ImpactCategories_ImpactId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Supermarket_Products_Products_ProductId",
                table: "Supermarket_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Supermarket_Products_Supermarkets_SupermarketId",
                table: "Supermarket_Products");

            migrationBuilder.RenameColumn(
                name: "SupermarketId",
                table: "Supermarket_Products",
                newName: "CurrentSupermarketId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Supermarket_Products",
                newName: "CurrentProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Supermarket_Products_SupermarketId",
                table: "Supermarket_Products",
                newName: "IX_Supermarket_Products_CurrentSupermarketId");

            migrationBuilder.RenameIndex(
                name: "IX_Supermarket_Products_ProductId",
                table: "Supermarket_Products",
                newName: "IX_Supermarket_Products_CurrentProductId");

            migrationBuilder.RenameColumn(
                name: "ImpactId",
                table: "Products",
                newName: "CurrentImpactId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "CurrentCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ImpactId",
                table: "Products",
                newName: "IX_Products_CurrentImpactId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_CurrentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CurrentCategoryId",
                table: "Products",
                column: "CurrentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ImpactCategories_CurrentImpactId",
                table: "Products",
                column: "CurrentImpactId",
                principalTable: "ImpactCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supermarket_Products_Products_CurrentProductId",
                table: "Supermarket_Products",
                column: "CurrentProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supermarket_Products_Supermarkets_CurrentSupermarketId",
                table: "Supermarket_Products",
                column: "CurrentSupermarketId",
                principalTable: "Supermarkets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
