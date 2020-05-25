using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class GeoPais
    {
        public int IdGeoPais { get; set; }
        public int IdGeoSubZona { get; set; }
        public string nombre { get; set; }
        public string codigoIso2 { get; set; }
        public string codigoIso3 { get; set; }
        public bool estado { get; set; }
    }
}