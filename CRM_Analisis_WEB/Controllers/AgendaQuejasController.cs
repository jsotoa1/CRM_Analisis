using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Analisis_WEB.Data;
using CRM_Analisis_WEB.Data.Entidades;
using CRM_Analisis_WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Analisis_WEB.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AgendaQuejasController : Controller
    {
        private readonly DataContext _dataContext;

        public AgendaQuejasController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult AgendaQuejas()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ObtenerAgendaQueja()
        {
            List<Agenda_Quejas> valoresAgendaQueja = new List<Agenda_Quejas>();
            var valoresBotones = new List<objetoBtn>();
            var valoresFuncionalidad = new List<objetos>();

            try
            {
                //valoresAgendaQueja = _dataContext.Quejas
                //                  .Include(c => c.Fecha_Queja.ToString)
                //                  .ToList();

                if (valoresAgendaQueja != null && valoresAgendaQueja.Count != 0)
                {

                    foreach (var item in valoresAgendaQueja)
                    {
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Id.ToString()
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Fecha_Agenda.ToString()
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Hora
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Medio_Contacto
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Prioridad.ToString()
                        });
 

                        valoresBotones = new List<objetoBtn>();

                        valoresBotones.Add(new objetoBtn()
                        {
                            tituloBtn = "Modificar",
                            funcionJs = "detalleModificarAgendaQueja",
                            id = Convert.ToString(item.Id),
                            icono = "fa fa-pencil",
                        });

                        valoresBotones.Add(new objetoBtn()
                        {
                            tituloBtn = "Eliminar",
                            funcionJs = "EliminarAgendaQueja",
                            id = Convert.ToString(item.Id),
                            icono = "fa fa-trash",
                            Class = "btn-danger"
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = true,
                            objetoBtn_ = valoresBotones
                        });

                    }
                    return Json(valoresFuncionalidad, new Newtonsoft.Json.JsonSerializerSettings());


                }


            }
            catch (Exception)
            {

            }
            return Json(new { Message = "No existen atributos ingresados." }, new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}
