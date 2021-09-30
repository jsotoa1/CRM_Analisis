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
    public class ClientesController : Controller
    {
        private readonly DataContext _dataContext;

        public ClientesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult GestionClientes()
        {
            var listClientes = new List<TipoCliente>();

            try
            {
                listClientes = _dataContext.TipoClientes.ToList();
            }catch(Exception)
            {

            }

            ViewBag.tipoClientes = listClientes;
            return View();
        }

        [HttpPost]
        public JsonResult ObtenerClientes()
        {
            List<Cliente> valoresClientes = new List<Cliente>();
            var valoresBotones = new List<objetoBtn>();
            var valoresFuncionalidad = new List<objetos>();

            try
            {
                valoresClientes = _dataContext.Clientes
                                  .Include(c => c.tipoCliente)
                                  .ToList();

                if (valoresClientes != null && valoresClientes.Count != 0)
                {

                    foreach (var item in valoresClientes)
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
                            valorColumna = item.Razon_Zocial
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.NIT.ToString()
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Direccion
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.PBX
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.PBX
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Email
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Pagina_Web
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Direccion
                        });
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.tipoCliente.Nombre
                        });

                        valoresBotones = new List<objetoBtn>();

                        valoresBotones.Add(new objetoBtn()
                        {
                            tituloBtn = "Modificar",
                            funcionJs = "detalleModificarCliente",
                            id = Convert.ToString(item.Id),
                            icono = "fa fa-pencil",
                        });

                        valoresBotones.Add(new objetoBtn()
                        {
                            tituloBtn = "Eliminar",
                            funcionJs = "EliminarCliente",
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
        public JsonResult GuardarCliente(Cliente model)
        {
            RespuestaViewModel response = new RespuestaViewModel();
            try
            {
                model.tipoCliente = _dataContext.TipoClientes.Find(model.tipoCliente.Id);
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
        public JsonResult DetalleCliente(string id)
        {
            Cliente response = new Cliente();
            try
            {
                response = _dataContext.Clientes
                           .Include(c => c.tipoCliente)
                           .FirstOrDefault(p => p.Id == Int32.Parse(id));

                return Json(new { success = true, Nombre = response.Nombre, RazonZocial = response.Razon_Zocial, NIT = response.NIT, Direccion = response.Direccion, PBX = response.PBX, FAX = response.FAX, Email = response.Email, PaginaWeb = response.Pagina_Web, Descripcion = response.Descripcion, TipoCliente = response.tipoCliente }, new Newtonsoft.Json.JsonSerializerSettings());
            }
            catch (Exception)
            {

            }
            return Json(new { success = false, responseText = "Error al obtener los datos." }, new Newtonsoft.Json.JsonSerializerSettings());
        }
        [HttpGet]
        public JsonResult EliminarCliente(string id)
        {
            RespuestaViewModel response = new RespuestaViewModel();
            try
            {
                Cliente cliente = _dataContext.Clientes
                    .Include(c => c.tipoCliente)
                    .FirstOrDefault(p => p.Id == Int32.Parse(id));


                _dataContext.Remove(cliente);
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
