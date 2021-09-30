using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGraduacion_WEB.Data.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }

        [MaxLength(150, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        [Required]
        public string Nombre { get; set; }

        [MaxLength(150, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string Razon_Zocial { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        [Required]
        public string NIT { get; set; }

        [MaxLength(150, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        [Required]
        public string Direccion { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string PBX { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string FAX { get; set; }

        [MaxLength(100, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string Email { get; set; }

        [MaxLength(70, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string Pagina_Web { get; set; }

        [MaxLength(150, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string Descripcion { get; set; }

        public TipoCliente tipoCliente { get; set; }

    }
}
