using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoGraduacion_WEB.Data;
using ProyectoGraduacion_WEB.Data.Entidades;
using ProyectoGraduacion_WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProyectoGraduacion_WEB.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class PlanAccionController : Controller
    {
        private readonly DataContext _dataContext;

        public PlanAccionController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult PlanAccion()
        {
            var listProducto = new List<Producto>();
            var listNivelControl = new List<Nivel_Control>();

            try
            {
                listProducto = _dataContext.Productos.ToList();
                listNivelControl = _dataContext.Nivel_Controles.ToList();
            }
            catch (Exception)
            {

            }

            ViewBag.Producto = listProducto;
            ViewBag.NivelControles = listNivelControl;
            return View();
        }
        [HttpPost]
        public JsonResult ObtenerPlanAccion()
        {
            List<Plan_Accion> valoresPlanAccion = new List<Plan_Accion>();
            var valoresBotones = new List<objetoBtn>();
            var valoresFuncionalidad = new List<objetos>();

            try
            {
                valoresPlanAccion = _dataContext.Plan_Acciones
                                  .Include(c => c.producto)
                                  .Include(c => c.nivel_Control)
                                  .ToList();

                if (valoresPlanAccion != null && valoresPlanAccion.Count != 0)
                {

                    foreach (var item in valoresPlanAccion)
                    {
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Id.ToString()
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.producto_servicio
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Recursos_Necesarios.ToString()
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Descuentos_Ofertas
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Plan_Entrega
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Nombre_Responsable
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.producto.Nombre
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.nivel_Control.Name
                        });

                        valoresBotones = new List<objetoBtn>();

                        valoresBotones.Add(new objetoBtn()
                        {
                            tituloBtn = "Modificar",
                            funcionJs = "detalleModificarPlanAccion",
                            id = Convert.ToString(item.Id),
                            icono = "fa fa-pencil",
                        });

                        valoresBotones.Add(new objetoBtn()
                        {
                            tituloBtn = "Eliminar",
                            funcionJs = "EliminarPlanAccion",
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
        public JsonResult GuardarPlanAccion(Plan_Accion model)
        {
            RespuestaViewModel response = new RespuestaViewModel();
            try
            {
                model.producto = _dataContext.Productos.Find(model.producto.Id);
                model.nivel_Control = _dataContext.Nivel_Controles.Find(model.nivel_Control.Id);
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
        public JsonResult DetallePlanAccion(string id)
        {
            Plan_Accion response = new Plan_Accion();
            try
            {
                response = _dataContext.Plan_Acciones
                                  .Include(c => c.producto)
                                  .Include(c => c.nivel_Control)
                           .FirstOrDefault(p => p.Id == Int32.Parse(id));

                return Json(new { success = true, Producto_Servicio = response.producto_servicio, Recursos_Necesarios = response.Recursos_Necesarios, Descuentos_Ofertas = response.Descuentos_Ofertas, Plan_Entrega = response.Plan_Entrega, Producto = response.producto, Nivel_Control = response.nivel_Control}, new Newtonsoft.Json.JsonSerializerSettings());
            }
            catch (Exception)
            {

            }
            return Json(new { success = false, responseText = "Error al obtener los datos." }, new Newtonsoft.Json.JsonSerializerSettings());
        }
        [HttpPost]
        public JsonResult ModificarPlanAccion(Plan_Accion model)
        {
            RespuestaViewModel response = new RespuestaViewModel();
            try
            {
                model.producto = _dataContext.Productos.Find(model.producto.Id);
                model.nivel_Control = _dataContext.Nivel_Controles.Find(model.nivel_Control.Id);
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
        public JsonResult EliminarPlanAccion(string id)
        {
            RespuestaViewModel response = new RespuestaViewModel();
            try
            {
                Plan_Accion plan_Accion = _dataContext.Plan_Acciones
                                  .Include(c => c.producto)
                                  .Include(c => c.nivel_Control)
                    .FirstOrDefault(p => p.Id == Int32.Parse(id));


                _dataContext.Remove(plan_Accion);
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

