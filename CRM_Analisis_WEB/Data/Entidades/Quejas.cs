using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Analisis_WEB.Data.Entidades
{
    public class Quejas
    {
        public int Id { get; set; }

        [MaxLength(150, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        [Required]
        public string Nombre_Persona { get; set; }

        [MaxLength(10, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        [Required]
        public string Telefono { get; set; }

        [MaxLength(100, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        [Required]
        public string Email { get; set; }

        [MaxLength(150, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string Nombre_Vendedor { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string Descripcio_Queja { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        [Required]
        public DateTime Fecha_Queja { get; set; }

        public DateTime Fecha_Queja_Local => Fecha_Queja.ToLocalTime();

    }
}
