using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class VentaTipoNegocio
    {
        public int idVentaTipoNegocio { get; set; }
        public int idMaeEmpresa { get; set; }
        public string nombre { get; set; }
        public bool modificable { get; set; }
        public bool estado { get; set; }
        public string nombreMaeEmpresa { get; set; }
        public int pageCount { get; set; }

        public VentaTipoNegocio()
        {
            idVentaTipoNegocio = 0;
            idMaeEmpresa = 0;
            nombre = "";
            modificable = false;
            estado = false;
            nombreMaeEmpresa = "";
        }
    }
}