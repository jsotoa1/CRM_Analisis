using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGraduacion_WEB.Data.Entidades
{
    public class Agenda_Quejas
    {

        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        [Required]
        public DateTime Fecha_Agenda { get; set; }

        [MaxLength(25, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string Hora { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string Medio_Contacto { get; set; }

        [Required]
        public Prioridad_Agenda Prioridad { get; set; }

        public Quejas quejas { get; set; }
    }
}
