using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ClieCliente
    {
        public int idClieCliente { get; set; }
        public int idClieEstado { get; set; }
        public int idClieTipoCliente { get; set; }
        public int idClieHolding { get; set; }
        public int idMaeEmpresa { get; set; }
        public int idMaeSucursal { get; set; }
        public int idMaeDireccion { get; set; }
        public int idMaeDireccionDespacho { get; set; }
        public bool esNacional { get; set; }
        public string rut { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string razonSocial { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string nombreContacto { get; set; }
        public string cargoContacto { get; set; }
        public string web { get; set; }
        public bool esEmpresa { get; set; }
        public string giroActividad { get; set; }
        public string usuarioExtranet { get; set; }
        public string passwordExtranet { get; set; }
        public int codigoProvedor { get; set; }
        public string codigoOld { get; set; }
        public string emailFacturacion { get; set; }
        public Int16 plazoPagoDias { get; set; }
        public bool esFacturacionAutomatica { get; set; }
        public bool esComprobarDeuda { get; set; }
        public string montoDeudaLimite { get; set; }
        public bool esExentoFee { get; set; }
        public bool esFacturaDolares { get; set; }
        public bool esPagoAnticipado { get; set; }
        public string codigoSernatur { get; set; }
        public bool esCorporativo { get; set; }
        public string codigoClienteCorporativo { get; set; }
        public bool validaCentroCosto { get; set; }
        public bool validaSubCentroCosto { get; set; }
        public bool validaReasonCode { get; set; }
        public bool validaOrdenCompra { get; set; }
        public bool estado { get; set; }
        public int idClieDiasPlazo { get; set; }
        public int idMaeDepartamento { get; set; }
        public bool esPersona { get; set; }
        public bool esActivoVenta { get; set; }
        public int idVendVendedora { get; set; }
    }
}