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
    public class VentaTipoSolicitudController : ApiController
    {
        // GET api/VentaTipoSolicitud/llenarUpdate
        [HttpGet]
        public IEnumerable<VentaTipoSolicitud> llenarUpdate(int id)
        {
            IList<VentaTipoSolicitud> listaTabla = new List<VentaTipoSolicitud>();
            string tabla = "VentaTipoSolicitud";
            DataSet ds = Conexion.ejecutar_select("sp_generico_sel '" + tabla + "','" + id + "'");

            VentaTipoSolicitud ventatiposolicitud = new VentaTipoSolicitud();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    ventatiposolicitud.idVentaTipoSolicitud = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    ventatiposolicitud.idMaeEmpresa = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
                    ventatiposolicitud.nombre = ds.Tables[0].Rows[0][2].ToString();
                    ventatiposolicitud.estado = Convert.ToBoolean(ds.Tables[0].Rows[0][3].ToString());


                    listaTabla.Add(ventatiposolicitud);
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
