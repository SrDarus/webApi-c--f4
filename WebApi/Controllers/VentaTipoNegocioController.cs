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
    public class VentaTipoNegocioController : ApiController
    {
        // GET api/ZysTablas
        [HttpGet]
        public IEnumerable<VentaTipoNegocio> obtenerVtn(int PageSize, int CurrentPage, string SortColumn, string SortOrder, string tabla, string filtro, string IdUsuario)
        {
            IList<VentaTipoNegocio> listaVTN = new List<VentaTipoNegocio>();
            DataSet ds = Conexion.ejecutar_select("sp_Paginacion_Grilla2 " + PageSize + "," + CurrentPage + ",'" + SortColumn + "','" + SortOrder + "','" + tabla + "','" + filtro + "','" + IdUsuario + "'");

            VentaTipoNegocio vtn = null;

            if (ds.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
                {

                    vtn = new VentaTipoNegocio();
                    vtn.idVentaTipoNegocio = Convert.ToInt32(ds.Tables[1].Rows[i][0].ToString());
                    vtn.nombreMaeEmpresa = ds.Tables[1].Rows[i][1].ToString();
                    vtn.nombre = ds.Tables[1].Rows[i][2].ToString();
                    vtn.modificable = Convert.ToBoolean(ds.Tables[1].Rows[i][3].ToString());
                    vtn.pageCount = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
                    listaVTN.Add(vtn);
                }
            }
            else
            {
                Console.WriteLine("No se encontraron datos");
            }
            return listaVTN;
        }










        //POST api/Vtn/registrarVtn
        [HttpPost]
        public void registrarVtn(int IdVentaTipoNegocio, int IdMaeEmpresa, string Nombre, bool Modificable, bool Estado)
        {

            VentaTipoNegocio vtn = new VentaTipoNegocio();
            vtn.idVentaTipoNegocio = IdVentaTipoNegocio;
            vtn.idMaeEmpresa = IdMaeEmpresa;
            vtn.nombre = Nombre;
            vtn.modificable = Modificable;
            vtn.estado = Estado;

            bool respuesta = Conexion.ejecutar_comando("DECLARE @SQLString2 nvarchar(max);" +
                "DECLARE @variables2 nvarchar(max);" +
               " execute sp_generico_upd_ins_t 'VentaTipoNegocio','','' ,@SQLString=@SQLString2 output,@variables=@variables2 output" +
               " EXECUTE sp_executesql @SQLString2,@variables2," + vtn.idVentaTipoNegocio + " , '"
               + vtn.idMaeEmpresa+ "' ,'"
               + vtn.nombre+ "',"
               + vtn.modificable+ ","
               + vtn.estado);
            if (respuesta)
            {
                Console.WriteLine("Insertado Correctamente");
            }
            else
            {
                Console.WriteLine("Error al insertar" + respuesta);
            }
        }

        [HttpGet]
        public IEnumerable<VentaTipoNegocio> llenarUpdate(int id)
        {
            IList<VentaTipoNegocio> listaTabla = new List<VentaTipoNegocio>();
            string tabla = "VentaTipoNegocio";
            DataSet ds = Conexion.ejecutar_select("sp_generico_sel '" + tabla + "','" + id + "'");

            VentaTipoNegocio ventaTipoNegocio = new VentaTipoNegocio();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    ventaTipoNegocio.idVentaTipoNegocio = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                    ventaTipoNegocio.idMaeEmpresa = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                    ventaTipoNegocio.nombre = ds.Tables[0].Rows[i][2].ToString();
                    ventaTipoNegocio.modificable = Convert.ToBoolean(ds.Tables[0].Rows[i][3].ToString());
                    ventaTipoNegocio.estado = Convert.ToBoolean(ds.Tables[0].Rows[i][4].ToString());


                    listaTabla.Add(ventaTipoNegocio);

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
