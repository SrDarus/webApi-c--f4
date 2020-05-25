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
    public class MaeDireccionesController : ApiController
    {
        // GET api/ZysTablas/llenarUpdate
        [HttpGet]
        public IEnumerable<MaeDireccion> llenarUpdate(int id)
        {
            IList<MaeDireccion> listaTabla = new List<MaeDireccion>();
            string tabla = "MaeDirecciones ";
            DataSet ds = Conexion.ejecutar_select("sp_generico_sel '" + tabla + "','" + id + "'");

            MaeDireccion maeDireccion = new MaeDireccion();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    maeDireccion.idMaeDireccion= Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                    maeDireccion.idGeoPais = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                    maeDireccion.idGeoCiudad = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
                    maeDireccion.idGeoComuna = Convert.ToInt32(ds.Tables[0].Rows[i][3].ToString());
                    maeDireccion.calle = ds.Tables[0].Rows[i][4].ToString();
                    maeDireccion.numero = ds.Tables[0].Rows[i][5].ToString();
                    maeDireccion.villa = ds.Tables[0].Rows[i][6].ToString();
                    maeDireccion.estado = Convert.ToBoolean(ds.Tables[0].Rows[i][7].ToString());


                    listaTabla.Add(maeDireccion);

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
