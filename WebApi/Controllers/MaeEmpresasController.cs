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
    public class MaeEmpresasController : ApiController
    {
        // GET api/ZysTablas/llenarUpdate
        [HttpGet]
        public IEnumerable<MaeEmpresa> llenarUpdate(int id)
        {
            IList<MaeEmpresa> listaTabla = new List<MaeEmpresa>();
            string tabla = "MaeEmpresa";
            DataSet ds = Conexion.ejecutar_select("sp_generico_sel '" + tabla + "','" + id + "'");

            MaeEmpresa maeEmpresa = new MaeEmpresa();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    maeEmpresa.idMaeEmpresa = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                    maeEmpresa.idMaeRubro = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                    maeEmpresa.idClieCliente = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
                    maeEmpresa.nombre = ds.Tables[0].Rows[i][3].ToString();
                    maeEmpresa.estado = Convert.ToBoolean(ds.Tables[0].Rows[i][4].ToString());
    

                    listaTabla.Add(maeEmpresa);

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




