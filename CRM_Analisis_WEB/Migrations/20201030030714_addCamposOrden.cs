using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Analisis_WEB.Migrations
{
    public partial class addCamposOrden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comentario_Solicitud",
                table: "OrdenVentas",
                newName: "Terminos_de_Orden");

            migrationBuilder.AddColumn<string>(
                name: "Comentario_al_Comprador",
                table: "OrdenVentas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre_de_Orden",
                table: "OrdenVentas",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentario_al_Comprador",
                table: "OrdenVentas");

            migrationBuilder.DropColumn(
                name: "Nombre_de_Orden",
                table: "OrdenVentas");

            migrationBuilder.RenameColumn(
                name: "Terminos_de_Orden",
                table: "OrdenVentas",
                newName: "Comentario_Solicitud");
        }
    }
}
