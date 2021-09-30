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
    public class NuevaOrdenController : Controller
    {
        private readonly DataContext _dataContext;

        public NuevaOrdenController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult GestionNuevaOrden()
        {
            
            return View();
        }

        [HttpPost]
        public JsonResult ObtenerClientes()
        {
            List<Cliente> valoresCliente = new List<Cliente>();
            var valoresBotones = new List<objetoBtn>();
            var valoresFuncionalidad = new List<objetos>();

            try
            {
                valoresCliente = _dataContext.Clientes
                                  .Include(c => c.tipoCliente)
                                  .ToList();

                if (valoresCliente != null && valoresCliente.Count != 0)
                {

                    foreach (var item in valoresCliente)
                    {
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Id.ToString()
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.NIT
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Nombre
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Email
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.tipoCliente.Nombre
                        });
                       
                        valoresBotones = new List<objetoBtn>();

                        valoresBotones.Add(new objetoBtn()
                        {
                            tituloBtn = "Seleccionar",
                            funcionJs = "cargarCP",
                            id = Convert.ToString(item.Id) + "\',\'" + item.NIT + "\',\'" + item.Nombre+ "\',\'" + item.Email + "\',\'" + item.PBX + "\',\'" + item.Direccion,
                            icono = "fa fa-hand-o-up",
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
        public JsonResult ObtenerProductos()
        {
            List<Producto> valoresProducto = new List<Producto>();
            var valoresBotones = new List<objetoBtn>();
            var valoresFuncionalidad = new List<objetos>();

            try
            {
                valoresProducto = _dataContext.Productos
                                  .Include(c => c.Categoria)
                                  .ToList();

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
                            valorColumna = item.Categoria.Name
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = "Q " + item.Precio.ToString()
                        }) ;
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Cantidad.ToString()
                        });

                        valoresBotones = new List<objetoBtn>();

                        valoresBotones.Add(new objetoBtn()
                        {
                            tituloBtn = "Seleccionar",
                            funcionJs = "cargarProducto",
                            id = Convert.ToString(item.Id) + "\',\'" + item.Nombre + "\',\'" + item.Precio,
                            icono = "fa fa-hand-o-up",
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

        public JsonResult AgregarOrden(OrdenVenta model, List<ListProductos> productos) {

            List<DetalleOrdenVenta> detalleOrden = new List<DetalleOrdenVenta>();

            foreach(var item in productos)
            {
                detalleOrden.Add(new DetalleOrdenVenta { 
                 producto = _dataContext.Productos.Find(item.Id),
                 Cantidad = item.Cantidad,
                 Precio = item.Subtotal
                });;
            }


            return null;
        }
    }
}
