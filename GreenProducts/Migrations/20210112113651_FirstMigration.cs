using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenProducts.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImpactCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SeverityLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpactCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supermarkets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supermarkets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentCategoryId = table.Column<int>(type: "int", nullable: true),
                    CurrentImpactId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CurrentCategoryId",
                        column: x => x.CurrentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ImpactCategories_CurrentImpactId",
                        column: x => x.CurrentImpactId,
                        principalTable: "ImpactCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supermarket_Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<float>(type: "real", nullable: false),
                    CurrentSupermarketId = table.Column<int>(type: "int", nullable: true),
                    CurrentProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supermarket_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supermarket_Products_Products_CurrentProductId",
                        column: x => x.CurrentProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supermarket_Products_Supermarkets_CurrentSupermarketId",
                        column: x => x.CurrentSupermarketId,
                        principalTable: "Supermarkets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CurrentCategoryId",
                table: "Products",
                column: "CurrentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CurrentImpactId",
                table: "Products",
                column: "CurrentImpactId");

            migrationBuilder.CreateIndex(
                name: "IX_Supermarket_Products_CurrentProductId",
                table: "Supermarket_Products",
                column: "CurrentProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Supermarket_Products_CurrentSupermarketId",
                table: "Supermarket_Products",
                column: "CurrentSupermarketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supermarket_Products");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Supermarkets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ImpactCategories");
        }
    }
}
