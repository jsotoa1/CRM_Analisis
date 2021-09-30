using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoGraduacion_WEB.Data;
using ProyectoGraduacion_WEB.Data.Entidades;
using ProyectoGraduacion_WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProyectoGraduacion_WEB.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ProductosController : Controller
    {
        private readonly DataContext _dataContext;

        public ProductosController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Productos()
        {
            var listCategorias = new List<Categoria_Producto>();

            try
            {
                listCategorias = _dataContext.Categorias.ToList();
            }catch(Exception)
            {

            }

            ViewBag.categorias = listCategorias;
            return View();
        }

        [HttpPost]
        public JsonResult ObtenerProductos()
        {
            List<Producto> valoresProducto = new List<Producto>();
            var valoresBotones = new List<objetoBtn>();
            var valoresFuncionalidad = new List<objetos>();

            try
            {
                valoresProducto = _dataContext.Productos
                                  .Include(c => c.Categoria)
                                  . ToList();

                if (valoresProducto != null && valoresProducto.Count != 0)
                {

                    foreach (var item in valoresProducto)
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
                            valorColumna = item.Descripcion == null ? "" : item.Descripcion
                        });
                       
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Precio.ToString()
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Cantidad.ToString()   
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Categoria.Name
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Estado == false ? "Inactivo" : "Activo"
                        });

                        valoresBotones = new List<objetoBtn>();

                        valoresBotones.Add(new objetoBtn()
                        {
                            tituloBtn = "Modificar",
                            funcionJs = "detalleModificarProducto",
                            id = Convert.ToString(item.Id),
                            icono = "fa fa-pencil",
                        });

                        valoresBotones.Add(new objetoBtn()
                        {
                            tituloBtn = "Eliminar",
                            funcionJs = "EliminarProducto",
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
            return Json(new { Message = "No existen atributos ingresados."}, new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult GuardarProducto(Producto model)
        {
            RespuestaViewModel response = new RespuestaViewModel();
            try
            {
                model.Categoria = _dataContext.Categorias.Find(model.Categoria.Id);
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
        public JsonResult DetalleProducto(string id)
        {
            Producto response = new Producto();
            try
            {
                response = _dataContext.Productos
                           .Include(c => c.Categoria)
                           .FirstOrDefault(p => p.Id == Int32.Parse(id));

                return Json(new { success = true, Nombre = response.Nombre, Descripcion = response.Descripcion, Precio = response.Precio, Cantidad = response.Cantidad, Categoria = response.Categoria.Id, Estado = response.Estado }, new Newtonsoft.Json.JsonSerializerSettings());
            }
            catch (Exception)
            {

            }
            return Json(new { success = false, responseText = "Error al obtener los datos." }, new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult ModificarProducto(Producto model)
        {
            RespuestaViewModel response = new RespuestaViewModel();
            try
            {
                model.Categoria = _dataContext.Categorias.Find(model.Categoria.Id);
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
        public JsonResult EliminarProducto(string id)
        {
            RespuestaViewModel response = new RespuestaViewModel();
            try
            {
                Producto Producto = _dataContext.Productos
                    .Include(c => c.Categoria)
                    .FirstOrDefault(p => p.Id == Int32.Parse(id));


                _dataContext.Remove(Producto);
                _dataContext.SaveChanges();

                response.Response = true;

                return Json( new {response.Response, Message = "Eliminado exitosamente." }, new Newtonsoft.Json.JsonSerializerSettings());
            }
            catch (Exception)
            {
                response.Response = false;
            }
            return Json(new { response.Response, Message = "Error al eliminar los datos." }, new Newtonsoft.Json.JsonSerializerSettings());
        }


    }
}
