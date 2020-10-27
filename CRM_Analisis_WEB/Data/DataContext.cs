using CRM_Analisis_WEB.Data.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CRM_Analisis_WEB.Data
{
    public class DataContext : IdentityDbContext<User>

    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Funcionalidad> Funcionalidades { get; set; }
        public DbSet<RolFuncionalidad> RolFuncionalidades { get; set; }
        public DbSet<TipoCliente> TipoClientes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Categoria_Producto> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }

        //Merida
        public DbSet<Tipo_Categoria_Anuncios> Tipo_Categoria_Anuncios { get; set; }
        public DbSet<Tipo_Promocion_Anuncios> Tipo_Promocion_Anuncios { get; set; }
        public DbSet<Tipo_Edad_Anuncios> Tipo_Edad_Anuncios { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }

        public DbSet<Nivel_Control> Nivel_Controles { get; set; }
        public DbSet<Plan_Accion> Plan_Acciones { get; set; }

        public DbSet<Tipo_Accion> Tipo_Acciones { get; set; }
        public DbSet<Tipo_Estado> Tipo_Estados { get; set; }
        public DbSet<Campania> campanias { get; set; }

        //Walter
        public DbSet<Prioridad_Agenda> Prioridad_Agendas { get; set; }
        public DbSet<Quejas> Quejas { get; set; }
        public DbSet<Agenda_Quejas> Agenda_Quejas { get; set; }


    }
}
