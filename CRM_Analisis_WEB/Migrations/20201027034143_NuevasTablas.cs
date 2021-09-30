using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoGraduacion_WEB.Migrations
{
    public partial class NuevasTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nivel_Controles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nivel_Controles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prioridad_Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioridad_Agendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quejas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre_Persona = table.Column<string>(maxLength: 150, nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Nombre_Vendedor = table.Column<string>(maxLength: 150, nullable: true),
                    Descripcio_Queja = table.Column<string>(nullable: false),
                    Fecha_Queja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quejas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Acciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Acciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Categoria_Anuncios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Categoria_Anuncios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Edad_Anuncios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Edad_Anuncios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Estados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Promocion_Anuncios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Promocion_Anuncios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoClientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoClientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agenda_Quejas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha_Agenda = table.Column<DateTime>(nullable: false),
                    Hora = table.Column<string>(maxLength: 25, nullable: true),
                    Medio_Contacto = table.Column<string>(maxLength: 50, nullable: true),
                    PrioridadId = table.Column<int>(nullable: false),
                    quejasId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda_Quejas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agenda_Quejas_Prioridad_Agendas_PrioridadId",
                        column: x => x.PrioridadId,
                        principalTable: "Prioridad_Agendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agenda_Quejas_Quejas_quejasId",
                        column: x => x.quejasId,
                        principalTable: "Quejas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 150, nullable: false),
                    Razon_Zocial = table.Column<string>(maxLength: 150, nullable: true),
                    NIT = table.Column<string>(maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(maxLength: 150, nullable: false),
                    PBX = table.Column<string>(maxLength: 50, nullable: true),
                    FAX = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Pagina_Web = table.Column<string>(maxLength: 70, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 150, nullable: true),
                    tipoClienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_TipoClientes_tipoClienteId",
                        column: x => x.tipoClienteId,
                        principalTable: "TipoClientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Anuncios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Encabezado = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Punto_venta = table.Column<string>(maxLength: 50, nullable: true),
                    Categoria = table.Column<string>(maxLength: 50, nullable: true),
                    Precio = table.Column<decimal>(nullable: false),
                    productoId = table.Column<int>(nullable: true),
                    tipo_EdadId = table.Column<int>(nullable: true),
                    tipo_PromocionId = table.Column<int>(nullable: true),
                    tipo_CategoriaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anuncios_Productos_productoId",
                        column: x => x.productoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Anuncios_Tipo_Categoria_Anuncios_tipo_CategoriaId",
                        column: x => x.tipo_CategoriaId,
                        principalTable: "Tipo_Categoria_Anuncios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Anuncios_Tipo_Edad_Anuncios_tipo_EdadId",
                        column: x => x.tipo_EdadId,
                        principalTable: "Tipo_Edad_Anuncios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Anuncios_Tipo_Promocion_Anuncios_tipo_PromocionId",
                        column: x => x.tipo_PromocionId,
                        principalTable: "Tipo_Promocion_Anuncios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Plan_Acciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    producto_servicio = table.Column<string>(maxLength: 50, nullable: false),
                    Recursos_Necesarios = table.Column<decimal>(nullable: false),
                    Descuentos_Ofertas = table.Column<string>(maxLength: 50, nullable: true),
                    Plan_Entrega = table.Column<string>(maxLength: 50, nullable: true),
                    Nombre_Responsable = table.Column<string>(maxLength: 150, nullable: true),
                    productoId = table.Column<int>(nullable: true),
                    nivel_ControlId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan_Acciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_Acciones_Nivel_Controles_nivel_ControlId",
                        column: x => x.nivel_ControlId,
                        principalTable: "Nivel_Controles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plan_Acciones_Productos_productoId",
                        column: x => x.productoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_Quejas_PrioridadId",
                table: "Agenda_Quejas",
                column: "PrioridadId");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_Quejas_quejasId",
                table: "Agenda_Quejas",
                column: "quejasId");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_productoId",
                table: "Anuncios",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_tipo_CategoriaId",
                table: "Anuncios",
                column: "tipo_CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_tipo_EdadId",
                table: "Anuncios",
                column: "tipo_EdadId");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_tipo_PromocionId",
                table: "Anuncios",
                column: "tipo_PromocionId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_tipoClienteId",
                table: "Clientes",
                column: "tipoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_Acciones_nivel_ControlId",
                table: "Plan_Acciones",
                column: "nivel_ControlId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_Acciones_productoId",
                table: "Plan_Acciones",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda_Quejas");

            migrationBuilder.DropTable(
                name: "Anuncios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Plan_Acciones");

            migrationBuilder.DropTable(
                name: "Tipo_Acciones");

            migrationBuilder.DropTable(
                name: "Tipo_Estados");

            migrationBuilder.DropTable(
                name: "Prioridad_Agendas");

            migrationBuilder.DropTable(
                name: "Quejas");

            migrationBuilder.DropTable(
                name: "Tipo_Categoria_Anuncios");

            migrationBuilder.DropTable(
                name: "Tipo_Edad_Anuncios");

            migrationBuilder.DropTable(
                name: "Tipo_Promocion_Anuncios");

            migrationBuilder.DropTable(
                name: "TipoClientes");

            migrationBuilder.DropTable(
                name: "Nivel_Controles");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
