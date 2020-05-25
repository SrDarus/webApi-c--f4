using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class GeoCiudad
    {
        public int idGeoCiudad { get; set; }
        public int idGeoPais { get; set; }
        public string nombre { get; set; }
        public string codigoIso { get; set; }
        public bool estado { get; set; }
    }
}