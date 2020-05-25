using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class VentaSolicitudesController : ApiController
    {
        [HttpGet]
        public IEnumerable<VentaSolicitud> obtenerVentaSolicitud(int PageSize, int CurrentPage, string SortColumn, string SortOrder, string tabla, string filtro, string IdUsuario)
        {
            IList<VentaSolicitud> listavs = new List<VentaSolicitud>();
            DataSet ds = Conexion.ejecutar_select("sp_Paginacion_Grilla2 " + PageSize + "," + CurrentPage + ",'" + SortColumn + "','" + SortOrder + "','" + tabla + "','" + filtro + "','" + IdUsuario + "'");
            VentaSolicitud ventaSolicitud = null;
            if (ds.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
                {
                    ventaSolicitud = new VentaSolicitud();
                    ventaSolicitud.idVentaSolicitud = Convert.ToInt32(ds.Tables[1].Rows[i][0].ToString());
                    ventaSolicitud.nombreClieCliente = ds.Tables[1].Rows[i][1].ToString();
                    ventaSolicitud.nombreVentaTipoSolicitud = ds.Tables[1].Rows[i][2].ToString();
                    ventaSolicitud.nombreVenVendedora = ds.Tables[1].Rows[i][3].ToString();
                    ventaSolicitud.nombre = ds.Tables[1].Rows[i][4].ToString();
                    ventaSolicitud.fechaDesde = ds.Tables[1].Rows[i][5].ToString();
                    ventaSolicitud.fechaHasta = ds.Tables[1].Rows[i][6].ToString();
                    ventaSolicitud.pageCount = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
                    listavs.Add(ventaSolicitud);
                }
            }
            else
            {


            }
            return listavs;

        }

        // GET api/ZysTablas/llenarUpdate
        [HttpGet]
        public IEnumerable<VentaSolicitud> llenarUpdate(int id)
        {
            IList<VentaSolicitud> listaTabla = new List<VentaSolicitud>();
            string tabla = "VentaSolicitud";
            DataSet ds = Conexion.ejecutar_select("sp_generico_sel '" + tabla + "','" + id + "'");

            VentaSolicitud ventaSolicitud = new VentaSolicitud();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    ventaSolicitud.idVentaSolicitud = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                    ventaSolicitud.idVentaTipoSolicitud = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                    ventaSolicitud.idMaeLineaNegocio = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
                    ventaSolicitud.idVendVendedora = Convert.ToInt32(ds.Tables[0].Rows[i][3].ToString());
                    ventaSolicitud.idClieCliente = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
                    ventaSolicitud.nombre = ds.Tables[0].Rows[i][5].ToString();
                    ventaSolicitud.telefono = ds.Tables[0].Rows[i][6].ToString();
                    ventaSolicitud.movil = ds.Tables[0].Rows[i][7].ToString();
                    ventaSolicitud.email = ds.Tables[0].Rows[i][8].ToString();
                    ventaSolicitud.periodos = ds.Tables[0].Rows[i][9].ToString();
                    ventaSolicitud.destinos = ds.Tables[0].Rows[i][10].ToString();
                    ventaSolicitud.detalles = ds.Tables[0].Rows[i][11].ToString();
                    ventaSolicitud.esTicket = Convert.ToBoolean(ds.Tables[0].Rows[i][12].ToString());
                    ventaSolicitud.esHotel = Convert.ToBoolean(ds.Tables[0].Rows[i][13].ToString());
                    ventaSolicitud.esTransfer = Convert.ToBoolean(ds.Tables[0].Rows[i][14].ToString());
                    ventaSolicitud.esOtros = Convert.ToBoolean(ds.Tables[0].Rows[i][15].ToString());
                    ventaSolicitud.paxAdultos = Convert.ToInt32(ds.Tables[0].Rows[i][16].ToString());
                    ventaSolicitud.paxChild = Convert.ToInt32(ds.Tables[0].Rows[i][17].ToString());
                    ventaSolicitud.paxInfant = Convert.ToInt32(ds.Tables[0].Rows[i][18].ToString());
                    ventaSolicitud.idGeoCiudadOrigen = Convert.ToInt32(ds.Tables[0].Rows[i][19].ToString());
                    ventaSolicitud.idGeoCiudadDestino = Convert.ToInt32(ds.Tables[0].Rows[i][20].ToString());
                    ventaSolicitud.fechaDesde = ds.Tables[0].Rows[i][21].ToString();
                    ventaSolicitud.fechaHasta = ds.Tables[0].Rows[i][22].ToString();
                    ventaSolicitud.notas = ds.Tables[0].Rows[i][23].ToString();
                    ventaSolicitud.estado = Convert.ToBoolean(ds.Tables[0].Rows[i][24].ToString());
     

                    listaTabla.Add(ventaSolicitud);

                }
            }
            else
            {
                //else
            }
            return listaTabla;
        }

        [HttpPost]
        public void registrarVS(int idventasolicitud,
                   int idventatiposolicitud,
                   int idmaelineanegocio,
                   int idvenvendedora,
                   int idcliecliente,
                   string nombre,
                   string telefono,
                   string movil,
                   string email,
                   string periodos,
                   string destinos,
                   string detalles,
                   bool esticket,
                   bool eshotel,
                   bool estransfer,
                   bool esotros,
                   int paxadultos,
                   int paxchild,
                   int paxinfant,
                   int idgeociudadorigen,
                   int idgeociudaddestino,
                   string fechadesde,
                   string fechahasta,
                   string notas,
                   bool estado)
        {
            VentaSolicitud vs = new VentaSolicitud();
            vs.idVentaSolicitud = idventasolicitud;
            vs.idVentaTipoSolicitud = idventatiposolicitud;
            vs.idMaeLineaNegocio = idmaelineanegocio;
            vs.idVendVendedora = idvenvendedora;
            vs.idClieCliente = idcliecliente;
            vs.nombre = nombre;
            vs.telefono = telefono;
            vs.movil = movil;
            vs.email = email;
            vs.periodos = periodos;
            vs.destinos = destinos;
            vs.detalles = detalles;
            vs.esTicket = esticket;
            vs.esHotel = eshotel;
            vs.esTransfer = estransfer;
            vs.esOtros = esotros;
            vs.paxAdultos = paxadultos;
            vs.paxChild = paxchild;
            vs.paxInfant = paxinfant;
            vs.idGeoCiudadOrigen = idgeociudadorigen;
            vs.idGeoCiudadDestino = idgeociudaddestino;
            vs.fechaDesde = fechadesde.ToString();
            vs.fechaHasta = fechahasta.ToString();
            vs.notas = notas;
            vs.estado = estado;

            bool respuesta = Conexion.ejecutar_comando("DECLARE @SQLString2 nvarchar(max);" +
                "DECLARE @variables2 nvarchar(max);" +
               " execute sp_generico_upd_ins_t 'VentaSolicitud','','' ,@SQLString=@SQLString2 output,@variables=@variables2 output" +
               " EXECUTE sp_executesql @SQLString2,@variables2, '" + vs.idVentaSolicitud + "','"
               + vs.nombre + "','"
               + vs.idMaeLineaNegocio + "','"
               + vs.idVentaTipoSolicitud + "','"
               + vs.idClieCliente + "','"
               + vs.idVendVendedora + "','"
               + vs.idGeoCiudadOrigen + "','"
               + vs.idGeoCiudadDestino + "','"
               + vs.fechaDesde + "','"
               + vs.fechaHasta + "','"
               + vs.email + "','"
               + vs.telefono + "','"
               + vs.movil + "','"
               + vs.periodos + "','"
               + vs.destinos + "',"
               + vs.esTicket + ","
               + vs.esHotel + ","
               + vs.esTransfer + ","
               + vs.esOtros + ",'"
               + vs.detalles + "','"
               + vs.notas + "',"
               + vs.paxAdultos + ","
               + vs.paxChild + ","
               + vs.paxInfant + ","
               + vs.estado);
            if (respuesta)
            {
                Console.WriteLine("Insertado Correctamente");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

    }
}
