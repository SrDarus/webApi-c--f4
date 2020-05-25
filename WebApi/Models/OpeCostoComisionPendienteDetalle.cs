using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class OpeCostoComisionPendienteDetalle
    {
        public int idOpeCostoComisionPendienteDetalle { get; set; }
        public int idOpeCostoComisionPendiente { get; set; }
        public int idVentaNegocioDetalle { get; set; }
        public int idVentaNegocio { get; set; }
        public string razonSocial { get; set; }
        public string fecha { get; set; }
        public decimal total { get; set; }
        public string fechaFacturacion { get; set; }
        public string fechaPago { get; set; }
        public int diasDifPago { get; set; }
        public decimal valorComision { get; set; }
        public decimal ajuste { get; set; }
        public decimal netoAPagarR { get; set; }
        public string nombre { get; set; }
        public bool marca { get; set; }
        public bool estado { get; set; }

        // GRILLA
        public string nombreNegocio { get; set; }
        public string nombreCliente { get; set; }
        public string totalS { get; set; }
        public string valorComisionS { get; set; }
        public string ajusteS { get; set; }
        public string netoAPagarRS { get; set; }

    }
}
