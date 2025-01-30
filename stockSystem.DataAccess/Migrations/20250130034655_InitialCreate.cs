using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace stockSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rols",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rols", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Rols_RolId",
                        column: x => x.RolId,
                        principalTable: "Rols",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryId = table.Column<int>(type: "int", nullable: false),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_Category_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salesBy = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sales_Users_salesBy",
                        column: x => x.salesBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesDetails",
                columns: table => new
                {
                    salesId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetails", x => new { x.salesId, x.productId });
                    table.ForeignKey(
                        name: "FK_SalesDetails_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_SalesDetails_Sales_salesId",
                        column: x => x.salesId,
                        principalTable: "Sales",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Alimento" },
                    { 2, "Ropa" },
                    { 3, "Juguetes" }
                });

            migrationBuilder.InsertData(
                table: "Rols",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "ADMIN" },
                    { 2, "SALESMAN" },
                    { 3, "STOCKER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "LastName", "Name", "PasswordHash", "PasswordSalt", "RolId", "Username" },
                values: new object[] { 1, "Admin", "Super", new byte[] { 241, 148, 80, 39, 25, 52, 78, 65, 86, 153, 60, 223, 192, 190, 50, 41, 240, 2, 154, 29, 10, 202, 232, 70, 158, 72, 201, 175, 127, 168, 253, 86, 237, 68, 63, 138, 59, 167, 6, 229, 61, 193, 225, 173, 56, 17, 186, 130, 76, 45, 243, 29, 25, 164, 220, 9, 135, 58, 21, 155, 204, 49, 229, 18 }, new byte[] { 223, 118, 20, 41, 18, 253, 50, 184, 19, 132, 214, 141, 239, 198, 4, 195, 15, 187, 29, 228, 164, 36, 4, 20, 6, 177, 26, 34, 95, 141, 131, 218, 35, 205, 252, 37, 196, 198, 207, 42, 60, 198, 73, 142, 88, 26, 119, 205, 123, 227, 100, 43, 77, 152, 111, 163, 49, 106, 146, 158, 47, 144, 144, 100, 41, 160, 102, 187, 69, 242, 131, 18, 25, 201, 110, 0, 163, 94, 22, 169, 149, 21, 101, 121, 251, 194, 243, 11, 189, 189, 244, 205, 182, 210, 36, 201, 11, 54, 175, 215, 80, 181, 7, 8, 209, 111, 62, 39, 220, 210, 15, 159, 140, 109, 113, 200, 153, 226, 59, 96, 210, 187, 50, 181, 128, 28, 129, 156 }, 1, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryId",
                table: "Products",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_userId",
                table: "Products",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_salesBy",
                table: "Sales",
                column: "salesBy");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_productId",
                table: "SalesDetails",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolId",
                table: "Users",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rols");
        }
    }
}
