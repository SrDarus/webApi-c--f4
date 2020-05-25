using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class VentaSolicitud
    {
        public int idVentaSolicitud { get; set; }
        public int idVentaTipoSolicitud { get; set; }
        public int idMaeLineaNegocio { get; set; }
        public int idVendVendedora { get; set; }
        public int idClieCliente { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string movil { get; set; }
        public string email { get; set; }
        public string periodos { get; set; }
        public string destinos { get; set; }
        public string detalles { get; set; }
        public bool esTicket { get; set; }
        public bool esHotel { get; set; }
        public bool esTransfer { get; set; }
        public bool esOtros { get; set; }
        public int paxAdultos { get; set; }
        public int paxChild { get; set; }
        public int paxInfant { get; set; }
        public int idGeoCiudadOrigen { get; set; }
        public int idGeoCiudadDestino { get; set; }
        public string fechaDesde { get; set; }
        public string fechaHasta { get; set; }
        public string notas { get; set; }
        public bool estado { get; set; }

        //ATRIBUTOS PARA LLENAR GRILLA
        public string nombreVentaTipoSolicitud { get; set; }
        public string nombreVenVendedora { get; set; }
        public string nombreClieCliente { get; set; }
        public int pageCount { get; set; }

        public VentaSolicitud()
        {

            idVentaSolicitud = 0;
            idVentaTipoSolicitud = 0;
            idMaeLineaNegocio = 0;
            idVendVendedora = 0;
            idClieCliente = 0;
            nombre = "";
            telefono = "";
            movil = "";
            email = "";
            periodos = "";
            destinos = "";
            detalles = "";
            esTicket = false;
            esHotel = false;
            esTransfer = false;
            esOtros = false;
            paxAdultos = 0;
            paxChild = 0;
            paxInfant = 0;
            idGeoCiudadOrigen = 0;
            idGeoCiudadDestino = 0;
            fechaDesde = "";
            fechaHasta = "";
            notas = "";
            estado = false;


        }
    }
}