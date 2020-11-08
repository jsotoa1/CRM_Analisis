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
    public class CampaniaController : Controller
    {
        private readonly DataContext _dataContext;

        public CampaniaController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Campania()
        {
            var listCampania = new List<Tipo_Accion>();
            var listCampanias = new List<Tipo_Estado>();

            try
            {
                listCampania = _dataContext.Tipo_Acciones.ToList();
                listCampanias = _dataContext.Tipo_Estados.ToList();
            }
            catch (Exception)
            {

            }

            ViewBag.tipoEstados = listCampania;
            ViewBag.tipoAcciones = listCampanias;
            return View();
        }
        [HttpPost]
        public JsonResult ObtenerCampania()
        {
            List<Campania> valoresCampania = new List<Campania>();
            var valoresBotones = new List<objetoBtn>();
            var valoresFuncionalidad = new List<objetos>();

            try
            {
                valoresCampania = _dataContext.campanias
                                  .Include(c => c.tipo_Estado)
                                  .Include(c => c.tipo_Accion)
                                  .ToList();

                if (valoresCampania != null && valoresCampania.Count != 0)
                {

                    foreach (var item in valoresCampania)
                    {
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Id.ToString()
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Nombre
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Porcentaje
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.tipo_Estado.Name
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.tipo_Accion.Name
                        });
                        valoresBotones = new List<objetoBtn>();

                        valoresBotones.Add(new objetoBtn()
                        {
                            tituloBtn = "Modificar",
                            funcionJs = "detalleModificarCampania",
                            id = Convert.ToString(item.Id),
                            icono = "fa fa-pencil",
                        });

                        valoresBotones.Add(new objetoBtn()
                        {
                            tituloBtn = "Eliminar",
                            funcionJs = "EliminarCampania",
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
        [HttpPost]
        public JsonResult GuardarCampania(Campania model)
        {
            RespuestaViewModel response = new RespuestaViewModel();
            try
            {
                model.tipo_Estado = _dataContext.Tipo_Estados.Find(model.tipo_Estado.Id);
                model.tipo_Accion = _dataContext.Tipo_Acciones.Find(model.tipo_Accion.Id);
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
        public JsonResult DetalleCampania(string id)
        {
            Campania response = new Campania();
            try
            {
                response = _dataContext.campanias
                                  .Include(c => c.tipo_Estado)
                                  .Include(c => c.tipo_Accion)
                           .FirstOrDefault(p => p.Id == Int32.Parse(id));

                return Json(new { success = true, Nombre = response.Nombre, Porcentaje = response.Porcentaje, Tipo_Estado = response.tipo_Estado, Tipo_Accion = response.tipo_Accion}, new Newtonsoft.Json.JsonSerializerSettings());
            }
            catch (Exception)
            {

            }
            return Json(new { success = false, responseText = "Error al obtener los datos." }, new Newtonsoft.Json.JsonSerializerSettings());
        }
        [HttpPost]
        public JsonResult ModificarCampania(Campania model)
        {
            RespuestaViewModel response = new RespuestaViewModel();
            try
            {
                model.tipo_Estado = _dataContext.Tipo_Estados.Find(model.tipo_Estado.Id);
                model.tipo_Accion = _dataContext.Tipo_Acciones.Find(model.tipo_Accion.Id);
                _dataContext.Update(model);
                _dataContext.SaveChanges();

                response.Response = true;

                return Json(new { success = true, responseText = "Modificado exitosamente." }, new Newtonsoft.Json.JsonSerializerSettings());
            }
            catch (Exception)
            {

            }
            return Json(new { success = false, responseText = "Error al guardar los datos." }, new Newtonsoft.Json.JsonSerializerSettings());
        }
        [HttpGet]
        public JsonResult EliminarCampania(string id)
        {
            RespuestaViewModel response = new RespuestaViewModel();
            try
            {
                Campania campania = _dataContext.campanias
                                  .Include(c => c.tipo_Estado)
                                  .Include(c => c.tipo_Accion)
                    .FirstOrDefault(p => p.Id == Int32.Parse(id));


                _dataContext.Remove(campania);
                _dataContext.SaveChanges();

                response.Response = true;

                return Json(new { response.Response, Message = "Eliminado exitosamente." }, new Newtonsoft.Json.JsonSerializerSettings());
            }
            catch (Exception)
            {
                response.Response = false;
            }
            return Json(new { response.Response, Message = "Error al eliminar los datos." }, new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}
