using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGraduacion_WEB.Models
{
        public class treeView
        {
            public int id { get; set; }

            public string text { get; set; }

            public long? population { get; set; }

            public string flagUrl { get; set; }

            public bool @checked { get; set; }

            public bool hasChildren { get; set; }

            public virtual List<treeView> children { get; set; }
        }

        public class permisosFuncionalidad
        {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int IdFuncionalidad { get; set; }
        public int Permiso { get; set; }
        public string Message { get; set; }
        public int Hijos { get; set; }
        public string NomreMenu { get; set; }
    }

        public class valoresRolFuncionalidad
        {
            public List<int> ids { get; set; }
            public string idRol { get; set; }
            public string usuario { get; set; }
        }
}
