using ProyectoGraduacion_WEB.Data;
using ProyectoGraduacion_WEB.Data.Entidades;
using ProyectoGraduacion_WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGraduacion_WEB.Controllers
{

    [Authorize(Roles = "Administrador")]
    public class MantMaquinariaController : Controller
    {
        private readonly DataContext _dataContext;

        public MantMaquinariaController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult MantMaquinaria()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GuardarMantMaquinaria(Flujo model)
        {
            RespuestaViewModel response = new RespuestaViewModel();
            try
            {
                _dataContext.Add(model);
                _dataContext.SaveChanges();

                response.Response = true;

                return Json(new { success = true, responseText = "Guardado exitosamente." }, new Newtonsoft.Json.JsonSerializerSettings());
            }
            catch (Exception)
            {

            }
            return Json(new { success = false, responseText = "Error al guardar los datos." }, new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult ObtenerFlujoMantMaquina(string flujo, string ID_Paso_Flujo)
        {
            List<Flujo> valores = new List<Flujo>();
            var valoresBotones = new List<objetoBtn>();
            var valoresFuncionalidad = new List<objetos>();

            try
            {
                valores = _dataContext.Flujos
                                  .Where(f => f.Nombre_Flujo == flujo
                                         && f.Id_Paso_Flujo == ID_Paso_Flujo)
                                  .ToList();

                if (valores != null && valores.Count != 0)
                {

                    foreach (var item in valores)
                    {
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Id.ToString()
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Nombre_Flujo
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Nombre_Paso_Fujo
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Persona_Realiza
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Tiempo_Tomado 
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Email
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Fecha.ToString("dd/MM/yyyy")
                        });
                        valoresBotones = new List<objetoBtn>();

                        

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
