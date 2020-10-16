using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Analisis_WEB.Data.Entidades
{
    public class RolFuncionalidad
    {
        public int Id { get; set; }

        public Rol rol { get; set; }

        public Funcionalidad funcionalidad { get; set; }
    }
}
