using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Analisis_WEB.Models
{
    public class objetos
    {
        public bool esBtn { get; set; }
        public bool esInput { get; set; }
        public bool esSelect { get; set; }
        public string valorColumna { get; set; }
        public List<objetoBtn> objetoBtn_ { get; set; }
        public objetoSelect objetoSelect_ { get; set; }
        public objetoInput objetoInput_ { get; set; }
        public bool IsOrdenable { get; set; } = true;
        public string atributo { get; set; } = "";
    }

    public class objetoBtn
    {
        public string Class { get; set; }
        public string tituloBtn { get; set; }
        public string funcionJs { get; set; }
        public string id { get; set; }
        public string icono { get; set; }
        public string atributo { get; set; }
    }

    public class objetoInput
    {
        public string idInput { get; set; }
        public string nombre { get; set; }
        public string atributo { get; set; }
        public bool inputGroup { get; set; }
        public string monedaISO { get; set; }

        public objetoInput()
        {
            atributo = "class=\"form-control\"";
        }
    }

    public class objetoSelect
    {
        public string idSelect { get; set; }
        public string nombre { get; set; }

        public List<valoresSelect> valoresSelect_ { get; set; }

        public string atributo { get; set; }
    }

    public class valoresSelect //clase diseñada para obtener el arreglo de los datos para el select
    {
        public string valSelect { get; set; }

        public string textSelect { get; set; }
    }
    public class objetoTabla
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string departamento { get; set; }
    }
}
