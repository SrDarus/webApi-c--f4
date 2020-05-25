using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class MaeSucursal
    {
        public int idMaeSucursal { get; set; }
        public string nombre { get; set; }
        public int idMaeEmpresa { get; set; }
        public int idMaeDireccion { get; set; }
        public int idMaeDireccionDespacho { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string nombreContacto { get; set; }
        public string cargoContacto { get; set; }
        public bool estado { get; set; }
    }
}