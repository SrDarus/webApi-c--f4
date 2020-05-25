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
    public class GeoCiudadesController : ApiController
    {
        // GET api/GeoCiudades/llenarUpdate
        [HttpGet]
        public IEnumerable<GeoCiudad> llenarUpdate(int id)
        {
            IList<GeoCiudad> listaTabla = new List<GeoCiudad>();
            string tabla = "GeoCiudad";
            DataSet ds = Conexion.ejecutar_select("sp_generico_sel '" + tabla + "','" + id + "'");

            GeoCiudad geoCiudad = new GeoCiudad();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    geoCiudad.idGeoCiudad = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                    geoCiudad.idGeoPais = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                    geoCiudad.nombre = ds.Tables[0].Rows[i][2].ToString();
                    geoCiudad.codigoIso = ds.Tables[0].Rows[i][3].ToString();
                    geoCiudad.estado = Convert.ToBoolean(ds.Tables[0].Rows[i][4].ToString());
                   

                    listaTabla.Add(geoCiudad);

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
