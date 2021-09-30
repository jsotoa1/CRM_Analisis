using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGraduacion_WEB.Models
{
        public class RespuestaViewModel
        {
            public string Message { get; set; }
            public bool Response { get; set; }
            public string Type { get; set; }
            public int Id { get; set; }
            public string Title { get; set; }


            public RespuestaViewModel()
            {
                this.Message = string.Empty;
                this.Response = false;
                this.Type = string.Empty;
                this.Id = 0;
                this.Title = string.Empty;
            }
        }
}
