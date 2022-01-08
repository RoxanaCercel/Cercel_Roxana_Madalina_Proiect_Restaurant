using Microsoft.EntityFrameworkCore.Migrations;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Migrations
{
    public partial class MeniuProdus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdusNume = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MeniuProdus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeniuID = table.Column<int>(type: "int", nullable: false),
                    ProdusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeniuProdus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MeniuProdus_Meniu_MeniuID",
                        column: x => x.MeniuID,
                        principalTable: "Meniu",
                        principalColumn: "MeniuID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeniuProdus_Produs_ProdusID",
                        column: x => x.ProdusID,
                        principalTable: "Produs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeniuProdus_MeniuID",
                table: "MeniuProdus",
                column: "MeniuID");

            migrationBuilder.CreateIndex(
                name: "IX_MeniuProdus_ProdusID",
                table: "MeniuProdus",
                column: "ProdusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeniuProdus");

            migrationBuilder.DropTable(
                name: "Produs");
        }
    }
}
