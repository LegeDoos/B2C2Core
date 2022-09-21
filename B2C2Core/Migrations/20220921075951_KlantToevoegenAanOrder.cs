using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2C2Core.Migrations
{
    public partial class KlantToevoegenAanOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KlantId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Klant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klant", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_KlantId",
                table: "Orders",
                column: "KlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Klant_KlantId",
                table: "Orders",
                column: "KlantId",
                principalTable: "Klant",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Klant_KlantId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Klant");

            migrationBuilder.DropIndex(
                name: "IX_Orders_KlantId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "KlantId",
                table: "Orders");
        }
    }
}
