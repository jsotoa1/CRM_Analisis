using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Analisis_WEB.Data;
using CRM_Analisis_WEB.Data.Entidades;
using CRM_Analisis_WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Analisis_WEB.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class GestionQuejasController : Controller
    {
        private readonly DataContext _dataContext;

        public GestionQuejasController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult GestionQuejas()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ObtenerQuejas()
        {
            List<Quejas> valoresQuejas = new List<Quejas>();
            var valoresBotones = new List<objetoBtn>();
            var valoresFuncionalidad = new List<objetos>();

            try
                {
                valoresQuejas = _dataContext.Quejas
                    .ToList();
                if (valoresQuejas != null && valoresQuejas.Count != 0)
                {

                    foreach (var item in valoresQuejas)
                    {
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Id.ToString()
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Nombre_Persona
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Telefono
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Email
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Nombre_Vendedor
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Descripcio_Queja
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Fecha_Queja.ToString()
                        });


                        valoresBotones = new List<objetoBtn>();

                        valoresBotones.Add(new objetoBtn()
                        {
                            tituloBtn = "Modificar",
                            funcionJs = "detalleModificarQuejas",
                            id = Convert.ToString(item.Id),
                            icono = "fa fa-pencil",
                        });

                        valoresBotones.Add(new objetoBtn()
                        {
                            tituloBtn = "Eliminar",
                            funcionJs = "EliminarQueja",
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
        public JsonResult GuardarQuejas(Quejas model)
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
        public JsonResult DetalleQuejas(string id)
        {
            Quejas response = new Quejas();
            try
            {
                response = _dataContext.Quejas
                           .FirstOrDefault(p => p.Id == Int32.Parse(id));

                return Json(new { success = true, NombrePersona = response.Nombre_Persona, Telefono = response.Telefono, Email= response.Email, NombreVendedor = response.Nombre_Vendedor,DescripcionQueja = response.Descripcio_Queja, FechaQueja = response.Fecha_Queja }, new Newtonsoft.Json.JsonSerializerSettings());
            }
            catch (Exception)
            {

            }
            return Json(new { success = false, responseText = "Error al obtener los datos." }, new Newtonsoft.Json.JsonSerializerSettings());
        }
        [HttpPost]
        public JsonResult ModificarQuejas(Quejas model)
        {
            RespuestaViewModel response = new RespuestaViewModel();
            try
            {
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
        public JsonResult EliminarQuejas(string id)
        {
            RespuestaViewModel response = new RespuestaViewModel();
            try
            {
                Quejas quejas = _dataContext.Quejas
                    .FirstOrDefault(p => p.Id == Int32.Parse(id));


                _dataContext.Remove(quejas);
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
