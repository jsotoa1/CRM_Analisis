using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Analisis_WEB.Data;
using CRM_Analisis_WEB.Data.Entidades;
using CRM_Analisis_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Analisis_WEB.Controllers
{
    public class ProductosController : Controller
    {
        private readonly DataContext _dataContext;

        public ProductosController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Productos()
        {
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
                            valorColumna = item.Descripcion
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
                            valorColumna = item.Estado == false ? "Inactivo" : "Activo"
                        });

                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna = item.Categoria.Name
                        });

                        valoresBotones = new List<objetoBtn>();

                        valoresBotones.Add(new objetoBtn()
                        {
                            tituloBtn = "Modificar",
                            funcionJs = "modificarZona",
                            id = Convert.ToString(item.Id),
                            icono = "fa fa-pencil",
                        });

                        valoresBotones.Add(new objetoBtn()
                        {
                            tituloBtn = "Eliminar",
                            funcionJs = "EliminarZona",
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


    }
}
