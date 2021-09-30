using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGraduacion_WEB.Data.Entidades
{
    public class Funcionalidad
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Descripcion { get; set; }

        [Required]
        [MaxLength(150)]
        public string NombreMenu { get; set; }

        [MaxLength(250)]
        public string Url { get; set; }

        [MaxLength(50)]
        public string Imagen { get; set; }

        [MaxLength(150)]
        public string Observaciones { get; set; }

        public Funcionalidad IdFuncionalidad { get; set; }

        public int Orden { get; set; }

        public string FuncionalidadHijo { get; set; }
     
        public bool Estado { get; set; }

    }
}
