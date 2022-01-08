using Microsoft.EntityFrameworkCore.Migrations;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Migrations
{
    public partial class ClientRezervare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Rezervare",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_ClientID",
                table: "Rezervare",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervare_Client_ClientID",
                table: "Rezervare",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervare_Client_ClientID",
                table: "Rezervare");

            migrationBuilder.DropIndex(
                name: "IX_Rezervare_ClientID",
                table: "Rezervare");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Rezervare");
        }
    }
}
