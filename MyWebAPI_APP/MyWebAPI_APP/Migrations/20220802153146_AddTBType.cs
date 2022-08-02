using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebAPI_APP.Migrations
{
    public partial class AddTBType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdType",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeProduct",
                columns: table => new
                {
                    IdType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProduct", x => x.IdType);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdType",
                table: "Products",
                column: "IdType");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TypeProduct_IdType",
                table: "Products",
                column: "IdType",
                principalTable: "TypeProduct",
                principalColumn: "IdType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TypeProduct_IdType",
                table: "Products");

            migrationBuilder.DropTable(
                name: "TypeProduct");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdType",
                table: "Products");
        }
    }
}
