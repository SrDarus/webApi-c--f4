using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class VendVendedora
    {
        public int idVendVendedora { get; set; }
        public int idMaeEmpresa { get; set; }
        public int idMaeDepartamento { get; set; }
        public int idVendTipoVendedora { get; set; }
        public int idMaeSucursal { get; set; }
        public int idMaeDireccion { get; set; }
        public int idMaeDireccionDespacho { get; set; }
        public int idMaeLineaNegocio { get; set; }
        public int idGeoCiudad { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public decimal comisionVendedorInicial { get; set; }
        public decimal comisionAgenciaInicial { get; set; }
        public bool estado { get; set; }
        public bool esActivoVenta { get; set; }


        //GRILLA
        public string nombreMaeEmpresa { get; set; }
        public string nombreMaeDepartamento { get; set; }
        public string nombreVendTipoVendedora { get; set; }
        public string nombreMaeSucursal { get; set; }
        public string nombreMaeDireccion { get; set; }
        public string nombreMaeDireccionDespacho { get; set; }
        public string nombreMaeLineaNegocio { get; set; }
        public string nombreGeoCiudad { get; set; }
    }
}