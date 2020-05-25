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
    public class MaeSucursalesController : ApiController
    {
        
        // GET api/ZysTablas/llenarUpdate
        [HttpGet]
        public IEnumerable<MaeSucursal> llenarUpdate(int id)
        {
            IList<MaeSucursal> listaTabla = new List<MaeSucursal>();
            string tabla = "MaeSucursal";
            DataSet ds = Conexion.ejecutar_select("sp_generico_sel '" + tabla + "','" + id + "'");

            MaeSucursal maeSucursal = new MaeSucursal();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    maeSucursal.idMaeSucursal = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                    maeSucursal.nombre = ds.Tables[0].Rows[i][1].ToString();
                    maeSucursal.idMaeEmpresa = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
                    maeSucursal.idMaeDireccion = Convert.ToInt32(ds.Tables[0].Rows[i][3].ToString());
                    maeSucursal.idMaeDireccionDespacho = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
                    maeSucursal.telefono = ds.Tables[0].Rows[i][5].ToString();
                    maeSucursal.email = ds.Tables[0].Rows[i][6].ToString();
                    maeSucursal.nombreContacto = ds.Tables[0].Rows[i][7].ToString();
                    maeSucursal.cargoContacto = ds.Tables[0].Rows[i][8].ToString();
                    maeSucursal.estado = Convert.ToBoolean(ds.Tables[0].Rows[i][9].ToString());


                    listaTabla.Add(maeSucursal);

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
