using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class OpeCostoComisionPendienteAjusteController : ApiController
    {
        // GET api/OpeCostoComisionPendienteAjuste/obtenerListaHijo
        [HttpGet]
        public IEnumerable<OpeCostoComisionPendienteAjuste> obtenerListaHijo(int idUsuario, string campoFK, string valorFK, string campoRetorno)
        {
            string tabla = "opeCostoComisionPendienteAjuste";
            IList<OpeCostoComisionPendienteAjuste> listaTabla = new List<OpeCostoComisionPendienteAjuste>();
            DataSet ds = Conexion.ejecutar_select("sp_generico_lst_fk2 " + idUsuario + ",'" + tabla + "','" + campoFK + "','" + valorFK + "','" + campoRetorno + "'");

            OpeCostoComisionPendienteAjuste occpa = null;

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    occpa = new OpeCostoComisionPendienteAjuste();
                    occpa.idOpeCostoComisionPendienteAjuste = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                    occpa.nombreOpeCostoComisionPendiente = ds.Tables[0].Rows[i][2].ToString();
                    occpa.noAjuste = ds.Tables[0].Rows[i][3].ToString();
                    occpa.descripcion = ds.Tables[0].Rows[i][4].ToString();
                    occpa.netoAPagarR = ds.Tables[0].Rows[i][5].ToString();
                    listaTabla.Add(occpa);
                }
            }
            else
            {
                //
            }
            return listaTabla;
        }

        //GET api/OpeCostoComisionPendienteAjuste/llenarUpdate
        [HttpGet]
        public IEnumerable<OpeCostoComisionPendienteAjuste> llenarUpdate(int id)
        {
            IList<OpeCostoComisionPendienteAjuste> listaTabla = new List<OpeCostoComisionPendienteAjuste>();
            string tabla = "OpeCostoComisionPendienteAjuste";
            DataSet ds = Conexion.ejecutar_select("sp_generico_sel '" + tabla + "','" + id + "'");

            OpeCostoComisionPendienteAjuste occpa = new OpeCostoComisionPendienteAjuste();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    occpa.idOpeCostoComisionPendienteAjuste = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                    occpa.idOpeCostoComisionPendiente = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                    occpa.idOpeSubTipoAjusteCosto = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
                    occpa.idVentaNegocio = Convert.ToInt32(ds.Tables[0].Rows[i][3].ToString());
                    occpa.idVentaNegocioDetalle = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
                    occpa.noAjuste = ds.Tables[0].Rows[i][5].ToString();
                    occpa.fechaEmision = ds.Tables[0].Rows[i][6].ToString();
                    occpa.descripcion = ds.Tables[0].Rows[i][7].ToString();
                    occpa.rutPasajero = ds.Tables[0].Rows[i][8].ToString();
                    occpa.nombrePasajero = ds.Tables[0].Rows[i][9].ToString();
                    occpa.netoAPagarR = ds.Tables[0].Rows[i][10].ToString();
                    occpa.nombre = ds.Tables[0].Rows[i][11].ToString();
                    occpa.estado = Convert.ToBoolean(ds.Tables[0].Rows[i][12].ToString());




                    listaTabla.Add(occpa);

                }
            }
            else
            {
                //else
            }
            return listaTabla;
        }


        //POST api/OpeCostoComisionPendienteAjuste
        [HttpPost]
        public void registrarTabla(int idOpeCostoComisionPendienteAjuste,
            int idOpeCostoComisionPendiente,
            int idVentaNegocio,
            int idVentaNegocioDetalle,
            string fechaEmision,
            string rutPasajero,
            string nombre,
            
            int idOpeSubTipoAjusteCosto,
            string noAjuste,
            string descripcion,
            string nombrePasajero,
            string netoAPagarR,
            bool estado)
        {

            OpeCostoComisionPendienteAjuste tabla = new OpeCostoComisionPendienteAjuste();

            tabla.idOpeCostoComisionPendienteAjuste = idOpeCostoComisionPendienteAjuste;
            tabla.idOpeCostoComisionPendiente = idOpeCostoComisionPendiente;
            tabla.idOpeSubTipoAjusteCosto = idOpeSubTipoAjusteCosto;
            tabla.idVentaNegocio = idVentaNegocio;
            tabla.idVentaNegocioDetalle = idVentaNegocioDetalle;
            tabla.noAjuste = noAjuste;
            tabla.fechaEmision = fechaEmision;
            tabla.descripcion = descripcion;
            tabla.rutPasajero = rutPasajero;
            tabla.nombrePasajero = nombrePasajero;
            tabla.netoAPagarR = netoAPagarR;
            tabla.nombre = nombre;
            tabla.estado = estado;



            bool respuesta = Conexion.ejecutar_comando("DECLARE @SQLString2 nvarchar(max);" +
                "DECLARE @variables2 nvarchar(max);" +
               " execute sp_generico_upd_ins_t 'OpeCostoComisionPendienteAjuste','','' ,@SQLString=@SQLString2 output,@variables=@variables2 output" +
               " EXECUTE sp_executesql @SQLString2,@variables2,'" + tabla.idOpeCostoComisionPendienteAjuste + " ', '"
               + tabla.idOpeCostoComisionPendiente + "' ,'"
               + tabla.idVentaNegocio + "','"
               + tabla.idVentaNegocioDetalle + "','"
               + tabla.fechaEmision + "','"
               + tabla.rutPasajero + "','"
               + tabla.nombrePasajero + "','"

               + tabla.nombre + "',"
               + tabla.estado + ",'"
               + tabla.idOpeSubTipoAjusteCosto + "','"
               + tabla.noAjuste + "','"
               + tabla.descripcion + "','"
               + tabla.netoAPagarR + "'");
            if (respuesta)
            {
                Console.WriteLine("Insertado Correctamente");
            }
            else
            {
                Console.WriteLine("Error al insertar" + respuesta);
            }
        }
    }
}
