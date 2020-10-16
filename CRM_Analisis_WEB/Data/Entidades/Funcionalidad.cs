using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Analisis_WEB.Data.Entidades
{
    public class Funcionalidad
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Descripcion { get; set; }
        [MaxLength(250)]
        public string Url { get; set; }
        [MaxLength(50)]
        public string Imagen { get; set; }
        [MaxLength(150)]
        public string Observaciones { get; set; }
        public int IdFuncionalidad { get; set; }
        public int Orden { get; set; }
        public string FuncionalidadHijo { get; set; }
        [MaxLength(150)]
        public string NombreMenu { get; set; }
        public bool Estado { get; set; }
    }
}
