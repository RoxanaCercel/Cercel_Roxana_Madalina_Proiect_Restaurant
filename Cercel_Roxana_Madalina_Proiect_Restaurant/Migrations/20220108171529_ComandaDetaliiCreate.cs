using Microsoft.EntityFrameworkCore.Migrations;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Migrations
{
    public partial class ComandaDetaliiCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AngajatID",
                table: "Comanda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Comanda",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientiID",
                table: "Comanda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MeniuID",
                table: "Comanda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_AngajatID",
                table: "Comanda",
                column: "AngajatID");

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_ClientId",
                table: "Comanda",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_MeniuID",
                table: "Comanda",
                column: "MeniuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comanda_Angajat_AngajatID",
                table: "Comanda",
                column: "AngajatID",
                principalTable: "Angajat",
                principalColumn: "AngajatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comanda_Client_ClientId",
                table: "Comanda",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comanda_Meniu_MeniuID",
                table: "Comanda",
                column: "MeniuID",
                principalTable: "Meniu",
                principalColumn: "MeniuID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comanda_Angajat_AngajatID",
                table: "Comanda");

            migrationBuilder.DropForeignKey(
                name: "FK_Comanda_Client_ClientId",
                table: "Comanda");

            migrationBuilder.DropForeignKey(
                name: "FK_Comanda_Meniu_MeniuID",
                table: "Comanda");

            migrationBuilder.DropIndex(
                name: "IX_Comanda_AngajatID",
                table: "Comanda");

            migrationBuilder.DropIndex(
                name: "IX_Comanda_ClientId",
                table: "Comanda");

            migrationBuilder.DropIndex(
                name: "IX_Comanda_MeniuID",
                table: "Comanda");

            migrationBuilder.DropColumn(
                name: "AngajatID",
                table: "Comanda");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Comanda");

            migrationBuilder.DropColumn(
                name: "ClientiID",
                table: "Comanda");

            migrationBuilder.DropColumn(
                name: "MeniuID",
                table: "Comanda");
        }
    }
}
