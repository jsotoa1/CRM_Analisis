using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGraduacion_WEB.Data.Entidades
{
    public class Plan_Accion
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        [Required]
        public string producto_servicio { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Recursos_Necesarios { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string Descuentos_Ofertas { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string Plan_Entrega { get; set; }

        [MaxLength(150, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string Nombre_Responsable { get; set; }

        public Producto producto { get; set; }
        public Nivel_Control nivel_Control { get; set; }

    }
}
