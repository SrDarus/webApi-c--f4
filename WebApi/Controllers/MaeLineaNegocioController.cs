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
    public class MaeLineaNegocioController : ApiController
    {
        // GET api/MaeLineaNegocio/llenarUpdate
        [HttpGet]
        public IEnumerable<MaeLineaNegocio> llenarUpdate(int id)
        {
            IList<MaeLineaNegocio> listaTabla = new List<MaeLineaNegocio>();
            string tabla = "MaeLineaNegocio";
            DataSet ds = Conexion.ejecutar_select("sp_generico_sel '" + tabla + "','" + id + "'");

            MaeLineaNegocio maelineanegocio = new MaeLineaNegocio();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    maelineanegocio.idMaeLineaNegocio = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    maelineanegocio.idMaeEmpresa = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
                    maelineanegocio.idMaeDepartamento = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());
                    maelineanegocio.nombre = ds.Tables[0].Rows[0][3].ToString();
                    maelineanegocio.cuentaContable = ds.Tables[0].Rows[0][4].ToString();
                    maelineanegocio.comisionGrupo = Convert.ToBoolean(ds.Tables[0].Rows[0][5].ToString());
                    maelineanegocio.estado = Convert.ToBoolean(ds.Tables[0].Rows[0][6].ToString());

                    listaTabla.Add(maelineanegocio);
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
