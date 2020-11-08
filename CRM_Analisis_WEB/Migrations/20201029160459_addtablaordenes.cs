using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Analisis_WEB.Migrations
{
    public partial class addtablaordenes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre_Departamento = table.Column<string>(maxLength: 60, nullable: true),
                    Pais = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPagos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPagos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdenEstados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenEstados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre_Municipio = table.Column<string>(maxLength: 60, nullable: true),
                    Departamento_MunicipioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipios_Departamentos_Departamento_MunicipioId",
                        column: x => x.Departamento_MunicipioId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "direccion_Entregas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dirección = table.Column<string>(maxLength: 100, nullable: true),
                    Municipio_EntregaId = table.Column<int>(nullable: true),
                    Comentario_Direccion_Entrega = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_direccion_Entregas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_direccion_Entregas_Municipios_Municipio_EntregaId",
                        column: x => x.Municipio_EntregaId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenVentas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaSolicitud = table.Column<DateTime>(nullable: false),
                    userId = table.Column<string>(nullable: true),
                    clienteId = table.Column<int>(nullable: true),
                    Comentario_Solicitud = table.Column<string>(nullable: true),
                    Estado_OrdenId = table.Column<int>(nullable: true),
                    metodoPagoId = table.Column<int>(nullable: true),
                    FechaOrden = table.Column<DateTime>(nullable: true),
                    FechaCancelacion = table.Column<DateTime>(nullable: true),
                    FechaEntrega = table.Column<DateTime>(nullable: true),
                    Direccion_Entrega_OrdenId = table.Column<int>(nullable: true),
                    Documento_Entrega = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenVentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenVentas_direccion_Entregas_Direccion_Entrega_OrdenId",
                        column: x => x.Direccion_Entrega_OrdenId,
                        principalTable: "direccion_Entregas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenVentas_OrdenEstados_Estado_OrdenId",
                        column: x => x.Estado_OrdenId,
                        principalTable: "OrdenEstados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenVentas_Clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenVentas_MetodoPagos_metodoPagoId",
                        column: x => x.metodoPagoId,
                        principalTable: "MetodoPagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenVentas_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrdenVentas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    productoId = table.Column<int>(nullable: true),
                    Cantidad = table.Column<float>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    Comentario = table.Column<string>(nullable: true),
                    OrdenVentaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrdenVentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenVentas_OrdenVentas_OrdenVentaId",
                        column: x => x.OrdenVentaId,
                        principalTable: "OrdenVentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenVentas_Productos_productoId",
                        column: x => x.productoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenVentas_OrdenVentaId",
                table: "DetalleOrdenVentas",
                column: "OrdenVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenVentas_productoId",
                table: "DetalleOrdenVentas",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_direccion_Entregas_Municipio_EntregaId",
                table: "direccion_Entregas",
                column: "Municipio_EntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_Departamento_MunicipioId",
                table: "Municipios",
                column: "Departamento_MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenVentas_Direccion_Entrega_OrdenId",
                table: "OrdenVentas",
                column: "Direccion_Entrega_OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenVentas_Estado_OrdenId",
                table: "OrdenVentas",
                column: "Estado_OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenVentas_clienteId",
                table: "OrdenVentas",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenVentas_metodoPagoId",
                table: "OrdenVentas",
                column: "metodoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenVentas_userId",
                table: "OrdenVentas",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleOrdenVentas");

            migrationBuilder.DropTable(
                name: "OrdenVentas");

            migrationBuilder.DropTable(
                name: "direccion_Entregas");

            migrationBuilder.DropTable(
                name: "OrdenEstados");

            migrationBuilder.DropTable(
                name: "MetodoPagos");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
