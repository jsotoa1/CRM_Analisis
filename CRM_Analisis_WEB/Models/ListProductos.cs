using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGraduacion_WEB.Models
{
    public class ListProductos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
