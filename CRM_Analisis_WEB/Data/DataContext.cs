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

    }
}
