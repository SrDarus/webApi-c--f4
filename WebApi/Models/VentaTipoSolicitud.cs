using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class VentaTipoSolicitud
    {
        public int idVentaTipoSolicitud { get; set; }
        public int idMaeEmpresa { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }
    }
}