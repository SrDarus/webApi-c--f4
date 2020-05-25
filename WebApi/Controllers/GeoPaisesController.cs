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
    public class GeoPaisesController : ApiController
    {
        // GET api/GeoCiudades/llenarUpdate
        [HttpGet]
        public IEnumerable<GeoPais> llenarUpdate(int id)
        {
            IList<GeoPais> listaTabla = new List<GeoPais>();
            string tabla = "GeoPais";
            DataSet ds = Conexion.ejecutar_select("sp_generico_sel '" + tabla + "','" + id + "'");

            GeoPais geoPais = new GeoPais();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    geoPais.IdGeoPais = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                    geoPais.IdGeoSubZona = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                    geoPais.nombre = ds.Tables[0].Rows[i][2].ToString();
                    geoPais.codigoIso2 = ds.Tables[0].Rows[i][3].ToString();
                    geoPais.codigoIso3 = ds.Tables[0].Rows[i][3].ToString();
                    geoPais.estado = Convert.ToBoolean(ds.Tables[0].Rows[i][5].ToString());


                    listaTabla.Add(geoPais);

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
