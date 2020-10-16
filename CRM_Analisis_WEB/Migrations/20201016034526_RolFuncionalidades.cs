using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Analisis_WEB.Migrations
{
    public partial class RolFuncionalidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RolFuncionalidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    rolId = table.Column<string>(nullable: true),
                    funcionalidadId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolFuncionalidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolFuncionalidades_Funcionalidades_funcionalidadId",
                        column: x => x.funcionalidadId,
                        principalTable: "Funcionalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolFuncionalidades_AspNetRoles_rolId",
                        column: x => x.rolId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolFuncionalidades_funcionalidadId",
                table: "RolFuncionalidades",
                column: "funcionalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_RolFuncionalidades_rolId",
                table: "RolFuncionalidades",
                column: "rolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolFuncionalidades");
        }
    }
}
