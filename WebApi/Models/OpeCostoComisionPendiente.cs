using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class OpeCostoComisionPendiente
    {
        public int idOpeCostoComisionPendiente { get; set; }
        public int idVendVendedora { get; set; }
        public string nombre { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public string netoAPagarR { get; set; }
        public string fechaCreacion { get; set; }
        public int idSegUsuarioCreacion { get; set; }
        public string fechaCierre { get; set; }
        public int idSegUsuarioCierre { get; set; }
        public bool estado { get; set; }

        //LLENAR GRILLA
        public string nombreSegUsuarioCreacion { get; set; }
        public string nombreVendVendedora { get; set; }
        public int pageCount { get; set; }


    }
}