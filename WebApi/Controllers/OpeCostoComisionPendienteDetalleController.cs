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
    public class OpeCostoComisionPendienteDetalleController : ApiController
    {

        // GET api/OpeCostoComisionPendienteDetalle/obtenerListaHijo
        [HttpGet]
        public IEnumerable<OpeCostoComisionPendienteDetalle> obtenerListaHijo(int idUsuario, string campoFK, string valorFK, string campoRetorno)
        {
            string tabla = "OpeCostoComisionPendienteDetalle";
            IList<OpeCostoComisionPendienteDetalle> listaTabla = new List<OpeCostoComisionPendienteDetalle>();
            DataSet ds = Conexion.ejecutar_select("sp_generico_lst_fk2 " + idUsuario + ",'" + tabla + "','" + campoFK + "','" + valorFK + "','" + campoRetorno + "'");

            OpeCostoComisionPendienteDetalle occpd = null;

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    occpd = new OpeCostoComisionPendienteDetalle();

                    occpd.idOpeCostoComisionPendienteDetalle = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                    occpd.nombreNegocio = ds.Tables[0].Rows[i][2].ToString();
                    occpd.razonSocial = ds.Tables[0].Rows[i][3].ToString();
                    occpd.fecha = ds.Tables[0].Rows[i][4].ToString();
                    occpd.total = Convert.ToDecimal(ds.Tables[0].Rows[i][5].ToString());


                    occpd.diasDifPago = Convert.ToInt32(ds.Tables[0].Rows[i][6].ToString());
                    occpd.valorComision = Convert.ToDecimal(ds.Tables[0].Rows[i][7].ToString());
                    occpd.ajuste = Convert.ToDecimal(ds.Tables[0].Rows[i][8].ToString());
                    occpd.netoAPagarR = Convert.ToDecimal(ds.Tables[0].Rows[i][9].ToString());

                    listaTabla.Add(occpd);
                }
            }
            else
            {
                //
            }
            return listaTabla;
        }

        [HttpGet]
        public IEnumerable<OpeCostoComisionPendienteDetalle> llenarUpdate(int id)
        {
            IList<OpeCostoComisionPendienteDetalle> listaTabla = new List<OpeCostoComisionPendienteDetalle>();
            string tabla = "OpeCostoComisionPendienteDetalle";
            DataSet ds = Conexion.ejecutar_select("sp_generico_sel '" + tabla + "','" + id + "'");

            OpeCostoComisionPendienteDetalle occpd = new OpeCostoComisionPendienteDetalle();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                   occpd.idOpeCostoComisionPendienteDetalle = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                   occpd.idOpeCostoComisionPendiente = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                   occpd.idVentaNegocioDetalle = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
                   occpd.idVentaNegocio = Convert.ToInt32(ds.Tables[0].Rows[i][3].ToString());
                   occpd.razonSocial = ds.Tables[0].Rows[i][4].ToString();
                   occpd.fecha = ds.Tables[0].Rows[i][5].ToString();
                   occpd.totalS = ds.Tables[0].Rows[i][6].ToString();
                   occpd.fechaFacturacion = ds.Tables[0].Rows[i][7].ToString();
                   occpd.fechaPago = ds.Tables[0].Rows[i][8].ToString();
                   occpd.diasDifPago = Convert.ToInt32(ds.Tables[0].Rows[i][9].ToString());
                   occpd.valorComisionS = ds.Tables[0].Rows[i][10].ToString();
                   occpd.ajusteS = ds.Tables[0].Rows[i][11].ToString();
                   occpd.netoAPagarRS = ds.Tables[0].Rows[i][12].ToString();
                   occpd.nombre = ds.Tables[0].Rows[i][13].ToString();
                   occpd.marca = Convert.ToBoolean(ds.Tables[0].Rows[i][14].ToString());
                   occpd.estado = Convert.ToBoolean(ds.Tables[0].Rows[i][15].ToString());

                   listaTabla.Add(occpd);

                }
            }
            else
            {
                //else
            }
            return listaTabla;
        }


    }
}
