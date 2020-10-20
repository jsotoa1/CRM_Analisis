using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Analisis_WEB.Models
{
    public class FuncionalidadViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string NombreMenu { get; set; }
        public string Url { get; set; }
        public string Imagen { get; set; }
        public string Observaciones { get; set; }
        public int IdFuncionalidad { get; set; }
        public int Orden { get; set; }
        public string FuncionalidadHijo { get; set; }
        public bool Estado { get; set; }
    }

}
