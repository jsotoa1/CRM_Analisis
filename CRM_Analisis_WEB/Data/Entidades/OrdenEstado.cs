using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Analisis_WEB.Data.Entidades
{
    public class OrdenEstado
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }
    }
}
