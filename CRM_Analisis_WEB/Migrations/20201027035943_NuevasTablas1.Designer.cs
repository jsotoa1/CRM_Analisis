﻿// <auto-generated />
using System;
using ProyectoGraduacion_WEB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ProyectoGraduacion_WEB.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201027035943_NuevasTablas1")]
    partial class NuevasTablas1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Agenda_Quejas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha_Agenda");

                    b.Property<string>("Hora")
                        .HasMaxLength(25);

                    b.Property<string>("Medio_Contacto")
                        .HasMaxLength(50);

                    b.Property<int>("PrioridadId");

                    b.Property<int?>("quejasId");

                    b.HasKey("Id");

                    b.HasIndex("PrioridadId");

                    b.HasIndex("quejasId");

                    b.ToTable("Agenda_Quejas");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Anuncio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .HasMaxLength(50);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Encabezado")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Precio");

                    b.Property<string>("Punto_venta")
                        .HasMaxLength(50);

                    b.Property<int?>("productoId");

                    b.Property<int?>("tipo_CategoriaId");

                    b.Property<int?>("tipo_EdadId");

                    b.Property<int?>("tipo_PromocionId");

                    b.HasKey("Id");

                    b.HasIndex("productoId");

                    b.HasIndex("tipo_CategoriaId");

                    b.HasIndex("tipo_EdadId");

                    b.HasIndex("tipo_PromocionId");

                    b.ToTable("Anuncios");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Campania", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("Porcentaje")
                        .HasMaxLength(10);

                    b.Property<int?>("tipo_AccionId");

                    b.Property<int?>("tipo_EstadoId");

                    b.HasKey("Id");

                    b.HasIndex("tipo_AccionId");

                    b.HasIndex("tipo_EstadoId");

                    b.ToTable("campanias");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Categoria_Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(150);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<string>("FAX")
                        .HasMaxLength(50);

                    b.Property<string>("NIT")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("PBX")
                        .HasMaxLength(50);

                    b.Property<string>("Pagina_Web")
                        .HasMaxLength(70);

                    b.Property<string>("Razon_Zocial")
                        .HasMaxLength(150);

                    b.Property<int?>("tipoClienteId");

                    b.HasKey("Id");

                    b.HasIndex("tipoClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Funcionalidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<bool>("Estado");

                    b.Property<string>("FuncionalidadHijo");

                    b.Property<int?>("IdFuncionalidadId");

                    b.Property<string>("Imagen")
                        .HasMaxLength(50);

                    b.Property<string>("NombreMenu")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Observaciones")
                        .HasMaxLength(150);

                    b.Property<int>("Orden");

                    b.Property<string>("Url")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("IdFuncionalidadId");

                    b.ToTable("Funcionalidades");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Nivel_Control", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Nivel_Controles");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Plan_Accion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descuentos_Ofertas")
                        .HasMaxLength(50);

                    b.Property<string>("Nombre_Responsable")
                        .HasMaxLength(150);

                    b.Property<string>("Plan_Entrega")
                        .HasMaxLength(50);

                    b.Property<decimal>("Recursos_Necesarios");

                    b.Property<int?>("nivel_ControlId");

                    b.Property<int?>("productoId");

                    b.Property<string>("producto_servicio")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("nivel_ControlId");

                    b.HasIndex("productoId");

                    b.ToTable("Plan_Acciones");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Prioridad_Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Prioridad_Agendas");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<int?>("CategoriaId");

                    b.Property<string>("Descripcion");

                    b.Property<bool>("Estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Precio");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Quejas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcio_Queja")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("Fecha_Queja");

                    b.Property<string>("Nombre_Persona")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Nombre_Vendedor")
                        .HasMaxLength(150);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Quejas");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.RolFuncionalidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("funcionalidadId");

                    b.Property<string>("rolId");

                    b.HasKey("Id");

                    b.HasIndex("funcionalidadId");

                    b.HasIndex("rolId");

                    b.ToTable("RolFuncionalidades");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Tipo_Accion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Tipo_Acciones");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Tipo_Categoria_Anuncios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Tipo_Categoria_Anuncios");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Tipo_Edad_Anuncios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Tipo_Edad_Anuncios");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Tipo_Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Tipo_Estados");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Tipo_Promocion_Anuncios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Tipo_Promocion_Anuncios");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.TipoCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("TipoClientes");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<Guid>("ImageId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("SegundoApellido")
                        .HasMaxLength(50);

                    b.Property<string>("SegundoNombre")
                        .HasMaxLength(50);

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<bool>("estado");

                    b.Property<string>("rolId");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("rolId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Rol", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(150);

                    b.Property<bool>("Estado");

                    b.ToTable("Rol");

                    b.HasDiscriminator().HasValue("Rol");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Agenda_Quejas", b =>
                {
                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.Prioridad_Agenda", "Prioridad")
                        .WithMany()
                        .HasForeignKey("PrioridadId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.Quejas", "quejas")
                        .WithMany()
                        .HasForeignKey("quejasId");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Anuncio", b =>
                {
                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.Producto", "producto")
                        .WithMany()
                        .HasForeignKey("productoId");

                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.Tipo_Categoria_Anuncios", "tipo_Categoria")
                        .WithMany()
                        .HasForeignKey("tipo_CategoriaId");

                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.Tipo_Edad_Anuncios", "tipo_Edad")
                        .WithMany()
                        .HasForeignKey("tipo_EdadId");

                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.Tipo_Promocion_Anuncios", "tipo_Promocion")
                        .WithMany()
                        .HasForeignKey("tipo_PromocionId");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Campania", b =>
                {
                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.Tipo_Accion", "tipo_Accion")
                        .WithMany()
                        .HasForeignKey("tipo_AccionId");

                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.Tipo_Estado", "tipo_Estado")
                        .WithMany()
                        .HasForeignKey("tipo_EstadoId");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Cliente", b =>
                {
                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.TipoCliente", "tipoCliente")
                        .WithMany()
                        .HasForeignKey("tipoClienteId");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Funcionalidad", b =>
                {
                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.Funcionalidad", "IdFuncionalidad")
                        .WithMany()
                        .HasForeignKey("IdFuncionalidadId");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Plan_Accion", b =>
                {
                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.Nivel_Control", "nivel_Control")
                        .WithMany()
                        .HasForeignKey("nivel_ControlId");

                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.Producto", "producto")
                        .WithMany()
                        .HasForeignKey("productoId");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.Producto", b =>
                {
                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.Categoria_Producto", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.RolFuncionalidad", b =>
                {
                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.Funcionalidad", "funcionalidad")
                        .WithMany()
                        .HasForeignKey("funcionalidadId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", "rol")
                        .WithMany()
                        .HasForeignKey("rolId");
                });

            modelBuilder.Entity("ProyectoGraduacion_WEB.Data.Entidades.User", b =>
                {
                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.Rol", "rol")
                        .WithMany()
                        .HasForeignKey("rolId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProyectoGraduacion_WEB.Data.Entidades.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
