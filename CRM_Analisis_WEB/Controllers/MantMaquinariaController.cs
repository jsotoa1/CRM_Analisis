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
using System.Net.Mail;
using System.Net;

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
            List<Tipo> listTipo = new List<Tipo>()
            {
                new Tipo() { Id = 1, Nombre = "PNC" },
                new Tipo() { Id = 1, Nombre = "RO" },
            };

            ViewBag.tipo = listTipo;
            return View();
        }

        [HttpPost]
        public JsonResult GuardarMantMaquinaria(Flujo model)
        {
            RespuestaViewModel response = new RespuestaViewModel();
            try
            {
                model.Estado = 1;
                _dataContext.Add(model);
                _dataContext.SaveChanges();

                response.Response = true; 

                string body =
                "<body>" +
                "<h3>Se ha ingresado una nueva solicitud de: " + model.Tipo + "<h3>" +
                "<p>Se registra incidente en el paso: " + model.Nombre_Paso_Fujo + "</p>" +
                "<p>Usuario que crea el incidente " + model.Email + "</p>" +
                "<p>Fecha de creación del incidente " + model.Fecha + "</p>" +
                "<p>Tiempo necesario para la solucion del incidente " + model.Tiempo_Tomado + "</p>" +
                "<p>Usuario asignado para la solución " + model.Persona_Realiza + "</p>" +
                "<p>Descripcion de la solicitud: " + model.Comentario + "</p>" +
                "<p>Saludos</p>" +
                "</body>";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("danielsalazarhp@gmail.com", "heverdanielsalazar");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                //smtp.UseDefaultCredentials = false;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("danielsalazarhp@gmail.com", "SISTEMA DE GESTION DE CALIDAD");
                mail.To.Add(new MailAddress("hsalazarp@miumg.edu.gt"));
                mail.To.Add(new MailAddress("jesaeduardo1999@gmail.com"));
                mail.To.Add(new MailAddress("jmeridag1@miumg.edu.gt"));
                mail.Subject = "Notificación de solicitud";
                mail.IsBodyHtml = true;
                mail.Body = body;

                smtp.Send(mail);

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
                            valorColumna = item.Tipo
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
                        valoresFuncionalidad.Add(new objetos()
                        {
                            esBtn = false,
                            valorColumna =
                            item.Estado == 1 ? "<span class='badge badge-pill badge-secondary'>Creado</span>" :
                            item.Estado == 2 ? "<span class='badge badge-pill badge-secondary'>Revisado</span>" :"<span class='badge badge-pill badge-ligh'>Finalizado</span>"
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