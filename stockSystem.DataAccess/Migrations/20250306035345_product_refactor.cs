using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace stockSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class product_refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_userId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Products",
                newName: "supplierId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Products",
                newName: "cost");

            migrationBuilder.RenameIndex(
                name: "IX_Products_userId",
                table: "Products",
                newName: "IX_Products_supplierId");

            migrationBuilder.AddColumn<int>(
                name: "createdBy",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "margin",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Products",
                type: "decimal(5,2)",
                nullable: false,
                computedColumnSql: "[Cost]  * (1 + [Margin])",
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(10,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 21, 77, 51, 159, 222, 103, 204, 167, 25, 194, 66, 131, 119, 42, 43, 14, 107, 120, 156, 80, 208, 46, 221, 201, 5, 16, 69, 175, 250, 38, 194, 200, 78, 1, 103, 231, 240, 73, 181, 155, 15, 125, 227, 134, 11, 7, 63, 104, 55, 53, 129, 156, 246, 186, 18, 164, 43, 166, 158, 186, 38, 121, 84, 221 }, new byte[] { 85, 12, 190, 202, 136, 213, 146, 79, 98, 119, 222, 9, 52, 70, 38, 101, 214, 184, 174, 141, 255, 97, 68, 245, 135, 154, 226, 59, 174, 102, 73, 32, 83, 217, 177, 142, 233, 223, 131, 131, 38, 237, 109, 125, 229, 127, 33, 19, 13, 39, 131, 136, 250, 229, 101, 130, 137, 238, 57, 144, 102, 232, 14, 239, 213, 134, 204, 14, 159, 246, 67, 184, 167, 15, 237, 142, 254, 161, 127, 220, 36, 2, 188, 251, 27, 22, 140, 251, 239, 245, 49, 219, 55, 252, 182, 160, 240, 202, 8, 144, 2, 142, 107, 119, 251, 238, 126, 202, 76, 151, 128, 37, 93, 94, 248, 14, 166, 148, 222, 14, 58, 144, 154, 89, 96, 47, 145, 186 } });

            migrationBuilder.CreateIndex(
                name: "IX_Products_createdBy",
                table: "Products",
                column: "createdBy");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_WarehouseId_ProductId",
                table: "Stocks",
                columns: new[] { "WarehouseId", "ProductId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_supplierId",
                table: "Products",
                column: "supplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_createdBy",
                table: "Products",
                column: "createdBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_supplierId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_createdBy",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Products_createdBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "margin",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "supplierId",
                table: "Products",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "cost",
                table: "Products",
                newName: "quantity");

            migrationBuilder.RenameIndex(
                name: "IX_Products_supplierId",
                table: "Products",
                newName: "IX_Products_userId");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Products",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldComputedColumnSql: "[Cost]  * (1 + [Margin])");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 241, 148, 80, 39, 25, 52, 78, 65, 86, 153, 60, 223, 192, 190, 50, 41, 240, 2, 154, 29, 10, 202, 232, 70, 158, 72, 201, 175, 127, 168, 253, 86, 237, 68, 63, 138, 59, 167, 6, 229, 61, 193, 225, 173, 56, 17, 186, 130, 76, 45, 243, 29, 25, 164, 220, 9, 135, 58, 21, 155, 204, 49, 229, 18 }, new byte[] { 223, 118, 20, 41, 18, 253, 50, 184, 19, 132, 214, 141, 239, 198, 4, 195, 15, 187, 29, 228, 164, 36, 4, 20, 6, 177, 26, 34, 95, 141, 131, 218, 35, 205, 252, 37, 196, 198, 207, 42, 60, 198, 73, 142, 88, 26, 119, 205, 123, 227, 100, 43, 77, 152, 111, 163, 49, 106, 146, 158, 47, 144, 144, 100, 41, 160, 102, 187, 69, 242, 131, 18, 25, 201, 110, 0, 163, 94, 22, 169, 149, 21, 101, 121, 251, 194, 243, 11, 189, 189, 244, 205, 182, 210, 36, 201, 11, 54, 175, 215, 80, 181, 7, 8, 209, 111, 62, 39, 220, 210, 15, 159, 140, 109, 113, 200, 153, 226, 59, 96, 210, 187, 50, 181, 128, 28, 129, 156 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_userId",
                table: "Products",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
