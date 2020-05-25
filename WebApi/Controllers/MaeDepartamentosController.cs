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
    public class MaeDepartamentosController : ApiController
    {
        // GET api/ZysTablas/llenarUpdate
        [HttpGet]
        public IEnumerable<MaeDepartamento> llenarUpdate(int id)
        {
            IList<MaeDepartamento> listaTabla = new List<MaeDepartamento>();
            string tabla = "MaeDepartamento ";
            DataSet ds = Conexion.ejecutar_select("sp_generico_sel '" + tabla + "','" + id + "'");

            MaeDepartamento maeDepartamento = new MaeDepartamento();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    maeDepartamento.idMaeEmpresa = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                    maeDepartamento.idMaeDepartamento = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                    maeDepartamento.nombre = ds.Tables[0].Rows[i][2].ToString();
                    maeDepartamento.cuentaContable = ds.Tables[0].Rows[i][3].ToString();
                    maeDepartamento.estado = Convert.ToBoolean(ds.Tables[0].Rows[i][4].ToString());


                    listaTabla.Add(maeDepartamento);

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
