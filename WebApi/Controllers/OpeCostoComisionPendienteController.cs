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
    public class OpeCostoComisionPendienteController : ApiController
    {
        // GET api/OpeCostoComisionPendiente/obtenerOpeCostoComisionPendiente
        [HttpGet]
        public IEnumerable<OpeCostoComisionPendiente> obtenerTablas(int PageSize, int CurrentPage, string SortColumn, string SortOrder, string tabla, string filtro, string IdUsuario)
        {
            IList<OpeCostoComisionPendiente> listaTabla = new List<OpeCostoComisionPendiente>();
            DataSet ds = Conexion.ejecutar_select("sp_Paginacion_Grilla2 " + PageSize + "," + CurrentPage + ",'" + SortColumn + "','" + SortOrder + "','" + tabla + "','" + filtro + "','" + IdUsuario + "'");

            OpeCostoComisionPendiente occp = new OpeCostoComisionPendiente();

            if (ds.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
                {

                    occp = new OpeCostoComisionPendiente();



                    occp.fechaCreacion = ds.Tables[1].Rows[i][0].ToString();
                    occp.netoAPagarR = ds.Tables[1].Rows[i][1].ToString();
                    occp.nombre = ds.Tables[1].Rows[i][2].ToString();
                    occp.nombreSegUsuarioCreacion = ds.Tables[1].Rows[i][3].ToString();
                    occp.nombreVendVendedora = ds.Tables[1].Rows[i][4].ToString();
                    occp.idOpeCostoComisionPendiente = Convert.ToInt32(ds.Tables[1].Rows[i][5].ToString());


                    occp.pageCount = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());


                    listaTabla.Add(occp);

                }
            }
            else
            {

            }
            return listaTabla;
        }

        // GET api/OpeCostoComisionPendiente/llenarUpdate
        [HttpGet]
        public IEnumerable<OpeCostoComisionPendiente> llenarUpdate(int id)
        {
            IList<OpeCostoComisionPendiente> listaTabla = new List<OpeCostoComisionPendiente>();
            string tabla = "OpeCostoComisionPendiente";
            DataSet ds = Conexion.ejecutar_select("sp_generico_sel '" + tabla + "','" + id + "'");

            OpeCostoComisionPendiente occp = new OpeCostoComisionPendiente();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    occp.idOpeCostoComisionPendiente = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                    occp.idVendVendedora = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                    occp.nombre = ds.Tables[0].Rows[i][2].ToString();
                    occp.fechaInicio = ds.Tables[0].Rows[i][3].ToString();
                    occp.fechaFin = ds.Tables[0].Rows[i][4].ToString();
                    occp.netoAPagarR = ds.Tables[0].Rows[i][5].ToString();
                    occp.fechaCreacion = ds.Tables[0].Rows[i][6].ToString();
                    occp.idSegUsuarioCreacion = Convert.ToInt32(ds.Tables[0].Rows[i][7].ToString());
                    occp.fechaCierre = ds.Tables[0].Rows[i][8].ToString();
                    occp.idSegUsuarioCierre = Convert.ToInt32(ds.Tables[0].Rows[i][9].ToString());
                    occp.estado = Convert.ToBoolean(ds.Tables[0].Rows[i][10].ToString());

                    listaTabla.Add(occp);

                }
            }
            else
            {
                //else
            }
            return listaTabla;
        }


        //POST api/OpeCostoComisionPendiente/registrarTabla
        [HttpPost]
        public void registrarTabla(int idOpeCostoComisionPendiente,
            int idVendVendedora,
            string nombre,
            string fechaInicio,
            string fechaFin,
            string netoAPagarR,
            string fechaCreacion,
            int idSegUsuarioCreacion,
            string fechaCierre,
            int idSegUsuarioCierre,
            bool estado)
        {

            OpeCostoComisionPendiente occp = new OpeCostoComisionPendiente();

            occp.idOpeCostoComisionPendiente = idOpeCostoComisionPendiente;
            occp.idVendVendedora = idVendVendedora;
            occp.nombre = nombre;
            occp.fechaInicio = fechaInicio;
            occp.fechaFin = fechaFin;
            occp.netoAPagarR = netoAPagarR;
            occp.fechaCreacion = fechaCreacion;
            occp.idSegUsuarioCreacion = idSegUsuarioCreacion;
            occp.fechaCierre = fechaCierre;
            occp.idSegUsuarioCierre = idSegUsuarioCierre;
            occp.estado = estado;



            bool respuesta = Conexion.ejecutar_comando("DECLARE @SQLString2 nvarchar(max);" +
                "DECLARE @variables2 nvarchar(max);" +
               " execute sp_generico_upd_ins_t 'OpeCostoComisionPendiente','','' ,@SQLString=@SQLString2 output,@variables=@variables2 output" +
               " EXECUTE sp_executesql @SQLString2,@variables2,"
               + occp.idOpeCostoComisionPendiente + " , "
               + occp.idVendVendedora + ",'"
               + occp.nombre + "','"
               + occp.netoAPagarR + "','"
               + occp.fechaInicio + "','"
               + occp.fechaFin + "','"
               + occp.fechaCreacion + "',"
               + occp.idSegUsuarioCreacion + ",'"
               + occp.fechaCierre + "',"
               + occp.idSegUsuarioCierre + ","
               + occp.estado);
            if (respuesta)
            {
                Console.WriteLine("Insertado Correctamente");
            }
            else
            {
                Console.WriteLine("Error al insertar" + respuesta);
            }
        }
    }
}
