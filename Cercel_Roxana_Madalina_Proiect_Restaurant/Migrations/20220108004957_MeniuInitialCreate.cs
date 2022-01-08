using Microsoft.EntityFrameworkCore.Migrations;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Migrations
{
    public partial class MeniuInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meniu",
                columns: table => new
                {
                    MeniuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categorie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gramaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pret = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meniu", x => x.MeniuID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meniu");
        }
    }
}
