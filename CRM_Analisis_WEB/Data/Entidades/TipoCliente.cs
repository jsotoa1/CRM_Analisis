using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGraduacion_WEB.Data.Entidades
{
    public class TipoCliente
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string Nombre { get; set; }
    }
}
