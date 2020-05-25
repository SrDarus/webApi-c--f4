using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class MaeDireccion
    {
        public int idMaeDireccion{ get; set; }
        public int idGeoPais { get; set; }
        public int idGeoCiudad { get; set; }
        public int idGeoComuna { get; set; }
        public string calle{ get; set; }
        public string numero { get; set; }
        public string villa { get; set; }
        public bool estado { get; set; }
    }
}