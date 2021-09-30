using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGraduacion_WEB.Data.Entidades
{
    public class Campania
    {
        public int Id { get; set; }

        [MaxLength(70, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        [Required]
        public string Nombre { get; set; }

        [MaxLength(10, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string Porcentaje { get; set; }

        public Tipo_Estado tipo_Estado { get; set; }

        public Tipo_Accion tipo_Accion { get; set; }
    }
}
