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
    public class VendTipoVendedorasController : ApiController
    {
        // GET api/ZysTablas/llenarUpdate
        [HttpGet]
        public IEnumerable<VendTipoVendedora> llenarUpdate(int id)
        {
            IList<VendTipoVendedora> listaTabla = new List<VendTipoVendedora>();
            string tabla = "VendTipoVendedora";
            DataSet ds = Conexion.ejecutar_select("sp_generico_sel '" + tabla + "','" + id + "'");

            VendTipoVendedora vendTipoVendedora = new VendTipoVendedora();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    vendTipoVendedora.idVendTipoVendedora = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                    vendTipoVendedora.nombre = ds.Tables[0].Rows[i][1].ToString();
                    vendTipoVendedora.estado = Convert.ToBoolean(ds.Tables[0].Rows[i][2].ToString());
                   

                    listaTabla.Add(vendTipoVendedora);

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
