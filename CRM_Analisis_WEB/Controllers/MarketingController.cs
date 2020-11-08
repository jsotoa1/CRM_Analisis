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
    public class MarketingController : Controller
    {
        private readonly DataContext _dataContext;

        public MarketingController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Marketing()
        {
            var list_prodcuto = new List<Producto>();
            var listtipo_Edad = new List<Tipo_Edad_Anuncios>();
            var listtipo_Promocion = new List<Tipo_Promocion_Anuncios>();
            var listtipo_Categoria = new List<Tipo_Categoria_Anuncios>();

            try
            {
                list_prodcuto = _dataContext.Productos.ToList();
                listtipo_Edad = _dataContext.Tipo_Edad_Anuncios.ToList();
                listtipo_Promocion = _dataContext.Tipo_Promocion_Anuncios.ToList();
                listtipo_Categoria = _dataContext.Tipo_Categoria_Anuncios.ToList();
            }
            catch (Exception)
            {

            }

            ViewBag.tipo_Edad = listtipo_Edad;
            ViewBag.tipo_Promocion = listtipo_Promocion;
            ViewBag.tipo_Categoria = listtipo_Categoria;
            ViewBag.list_Producto = list_prodcuto;
            return View();
        }
        [HttpPost]
        public JsonResult ObtenerAnuncios()
        {
            List<Anuncio> valoresAnuncio = new List<Anuncio>();
            var valoresBotones = new List<objetoBtn>();
            var valoresFuncionalidad = new List<objetos>();

            try
            {
                valoresAnuncio = _dataContext.Anuncios
                                  .Include(c => c.tipo_Categoria)
                                  .Include(c => c.producto)
                                  .Include(c => c.tipo_Edad)
                                  .Include(c => c.tipo_Promocion)
                                  .ToList();

                if (valoresAnuncio != null && valoresAnuncio.Count != 0)
                {

                    foreach (var item in valoresAnuncio)
                    {
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Id.ToString()
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Encabezado
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Descripcion == null ? "" : item.Descripcion
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Punto_venta
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Precio.ToString()
                        }); 
                        
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.producto.Nombre
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.tipo_Edad.Name
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.tipo_Promocion.Name
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.tipo_Categoria.Name
                        });

                        valoresBotones = new List<objetoBtn>();

                        valoresBotones.Add(new objetoBtn()
                        {
                            tituloBtn = "Modificar",
                            funcionJs = "detalleModificarAnuncio",
                            id = Convert.ToString(item.Id),
                            icono = "fa fa-pencil",
                        });

                        valoresBotones.Add(new objetoBtn()
                        {
                            tituloBtn = "Eliminar",
                            funcionJs = "EliminarAnuncio",
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
        public JsonResult GuardarAnuncio(Anuncio model)
        {
            RespuestaViewModel response = new RespuestaViewModel();
            try
            {
                model.producto = _dataContext.Productos.Find(model.producto.Id);
                model.tipo_Categoria = _dataContext.Tipo_Categoria_Anuncios.Find(model.tipo_Categoria.Id);
                model.tipo_Edad = _dataContext.Tipo_Edad_Anuncios.Find(model.tipo_Edad.Id);
                model.tipo_Promocion = _dataContext.Tipo_Promocion_Anuncios.Find(model.tipo_Promocion.Id);
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
        public JsonResult DetalleAnuncio(string id)
        {
            Anuncio response = new Anuncio();
            try
            {
                response = _dataContext.Anuncios
                                  .Include(c => c.tipo_Categoria)
                                  .Include(c => c.producto)
                                  .Include(c => c.tipo_Edad)
                                  .Include(c => c.tipo_Promocion)
                           .FirstOrDefault(p => p.Id == Int32.Parse(id));

                return Json(new { success = true, Encabezado = response.Encabezado, Descripcion = response.Descripcion, Punto_venta = response.Punto_venta, Precio = response.Precio, Producto = response.producto, Tipo_Edad = response.tipo_Edad, Tipo_Promocion = response.tipo_Promocion, Tipo_Categoria = response.tipo_Categoria }, new Newtonsoft.Json.JsonSerializerSettings());
            }
            catch (Exception)
            {

            }
            return Json(new { success = false, responseText = "Error al obtener los datos." }, new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult ModificarAnuncio(Anuncio model)
        {
            RespuestaViewModel response = new RespuestaViewModel();
            try
            {
                model.producto = _dataContext.Productos.Find(model.producto.Id);
                model.tipo_Categoria = _dataContext.Tipo_Categoria_Anuncios.Find(model.tipo_Categoria.Id);
                model.tipo_Edad = _dataContext.Tipo_Edad_Anuncios.Find(model.tipo_Edad.Id);
                model.tipo_Promocion = _dataContext.Tipo_Promocion_Anuncios.Find(model.tipo_Promocion.Id);
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
        public JsonResult EliminarAnuncio(string id)
        {
            RespuestaViewModel response = new RespuestaViewModel();
            try
            {
                Anuncio anuncio = _dataContext.Anuncios
                                  .Include(c => c.tipo_Categoria)
                                  .Include(c => c.producto)
                                  .Include(c => c.tipo_Edad)
                                  .Include(c => c.tipo_Promocion)
                    .FirstOrDefault(p => p.Id == Int32.Parse(id));


                _dataContext.Remove(anuncio);
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
