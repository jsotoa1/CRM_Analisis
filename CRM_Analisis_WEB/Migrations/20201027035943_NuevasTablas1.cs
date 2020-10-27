using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Analisis_WEB.Migrations
{
    public partial class NuevasTablas1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "campanias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 70, nullable: false),
                    Porcentaje = table.Column<string>(maxLength: 10, nullable: true),
                    tipo_EstadoId = table.Column<int>(nullable: true),
                    tipo_AccionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campanias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_campanias_Tipo_Acciones_tipo_AccionId",
                        column: x => x.tipo_AccionId,
                        principalTable: "Tipo_Acciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_campanias_Tipo_Estados_tipo_EstadoId",
                        column: x => x.tipo_EstadoId,
                        principalTable: "Tipo_Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_campanias_tipo_AccionId",
                table: "campanias",
                column: "tipo_AccionId");

            migrationBuilder.CreateIndex(
                name: "IX_campanias_tipo_EstadoId",
                table: "campanias",
                column: "tipo_EstadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "campanias");
        }
    }
}
