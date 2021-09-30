using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGraduacion_WEB.Data.Entidades
{
    public class DetalleOrdenVenta
    {
        public int Id { get; set; }

        public Producto producto { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Cantidad { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Precio { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comentario { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Valor => (decimal)Cantidad * Precio;
    }
}
