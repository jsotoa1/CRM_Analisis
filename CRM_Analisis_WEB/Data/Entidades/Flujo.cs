using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGraduacion_WEB.Data.Entidades
{
    public class Flujo
    {
        public int Id { get; set; }

        [MaxLength(150, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        [Required]
        public string Nombre_Flujo { get; set; }

        [MaxLength(150, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string Id_Paso_Flujo { get; set; }

        [MaxLength(150, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        [Required]
        public string Nombre_Paso_Fujo { get; set; }

        [MaxLength(150, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        [Required]
        public string Persona_Realiza { get; set; }

        public string Tiempo_Tomado { get; set; }

        [MaxLength(200, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string Comentario { get; set; }

        [MaxLength(100, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string Email { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

    }
}
