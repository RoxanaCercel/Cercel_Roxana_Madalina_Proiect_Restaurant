using Microsoft.EntityFrameworkCore.Migrations;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Migrations
{
    public partial class AngajatiCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Angajat",
                columns: table => new
                {
                    AngajatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NrTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salariu = table.Column<int>(type: "int", nullable: false),
                    OreSupl = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajat", x => x.AngajatId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Angajat");
        }
    }
}
