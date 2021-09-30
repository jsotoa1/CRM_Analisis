using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProyectoGraduacion_WEB.Data.Entidades
{
    public class OrdenVenta
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nombre_de_Orden { get; set; }

        public DateTime FechaSolicitud { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        public DateTime Fecha_Solicitud_Local => FechaSolicitud.ToLocalTime();

        public User user { get; set; }

        public Cliente cliente { get; set; }

        public string Comentario_al_Comprador { get; set; }

        public string Terminos_de_Orden{ get; set; }

        public OrdenEstado Estado_Orden { get; set; }

        public MetodoPago metodoPago { get; set; }

        public ICollection<DetalleOrdenVenta> detalleOrden { get; set; }

        #region Lectura
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float CantidadTotal => detalleOrden == null ? 0 : detalleOrden.Sum(od => od.Cantidad);

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorTotal => detalleOrden == null ? 0 : detalleOrden.Sum(od => od.Valor);

        #endregion

        public DateTime? FechaOrden { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        public DateTime? Fecha_Orden_Local => FechaOrden?.ToLocalTime();

        public DateTime? FechaCancelacion { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        public DateTime? Fecha_Cancelacion_Local => FechaCancelacion?.ToLocalTime();

        public DateTime? FechaEntrega { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        public DateTime? Fecha_Entrega_Local => FechaEntrega?.ToLocalTime();

        public Direccion_Entrega Direccion_Entrega_Orden { get; set; }

        public Guid Documento_Entrega { get; set; }

        public string DocumentoFullPath => Documento_Entrega == Guid.Empty
            ? $"https://localhost:44322/Plantilla/ContratoLleno.pdf"
            : $"https://onsale.blob.core.windows.net/users/{Documento_Entrega}";

    }
}

