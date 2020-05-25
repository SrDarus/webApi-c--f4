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
    public class VendedorasController : ApiController
    {
        // GET api/ZysTablas/obtenerVendedora
        [HttpGet]
        public IEnumerable<VendVendedora> llenarUpdate(int id)
        {
            IList<VendVendedora> listaTabla = new List<VendVendedora>();
            string tabla = "VendVendedora";
            DataSet ds = Conexion.ejecutar_select("sp_generico_sel '" + tabla + "','" + id + "'");

            VendVendedora vendedora = new VendVendedora();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    vendedora.idVendVendedora = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    vendedora.idMaeEmpresa = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
                    vendedora.idMaeDepartamento = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());
                    vendedora.idVendTipoVendedora = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());
                    vendedora.idMaeSucursal = Convert.ToInt32(ds.Tables[0].Rows[0][4].ToString());
                    vendedora.idMaeDireccion = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());

                    vendedora.idMaeDireccionDespacho = Convert.ToInt32(ds.Tables[0].Rows[0][6].ToString());
                    vendedora.idMaeLineaNegocio = Convert.ToInt32(ds.Tables[0].Rows[0][7].ToString());
                    vendedora.idGeoCiudad = Convert.ToInt32(ds.Tables[0].Rows[0][8].ToString());
                    vendedora.nombre = ds.Tables[0].Rows[0][9].ToString();
                    vendedora.apellido = ds.Tables[0].Rows[0][10].ToString();
                    vendedora.telefono = ds.Tables[0].Rows[0][11].ToString();

                    vendedora.email = ds.Tables[0].Rows[0][12].ToString();
                    vendedora.comisionVendedorInicial = Convert.ToDecimal(ds.Tables[0].Rows[0][13].ToString());
                    vendedora.comisionAgenciaInicial = Convert.ToDecimal(ds.Tables[0].Rows[0][14].ToString());
                    vendedora.estado = Convert.ToBoolean(ds.Tables[0].Rows[0][15].ToString());
                    vendedora.esActivoVenta = Convert.ToBoolean(ds.Tables[0].Rows[0][16].ToString());


                    listaTabla.Add(vendedora);
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
