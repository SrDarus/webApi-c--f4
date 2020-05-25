using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class OpeCostoComisionPendienteAjuste
    {
        public int idOpeCostoComisionPendienteAjuste { get; set; }
        public int idOpeCostoComisionPendiente { get; set; }
        public int idOpeSubTipoAjusteCosto { get; set; }
        public int idVentaNegocio { get; set; }
        public int idVentaNegocioDetalle { get; set; }
        public string noAjuste { get; set; }
        public string fechaEmision { get; set; }
        public string descripcion { get; set; }
        public string rutPasajero { get; set; }
        public string nombrePasajero { get; set; }
        public string netoAPagarR { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }


        //GRILLA
        public string nombreOpeCostoComisionPendiente { get; set; }
        public string nombreOpeSubTipoAjusteCosto { get; set; }


    }
}