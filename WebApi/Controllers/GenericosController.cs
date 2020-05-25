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
    public class GenericosController : ApiController
    {
        public class lista
        {
            public int idClieCliente { get; set; }
            public string rut { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string razonSocial { get; set; }

        }

        public class ComboBox
        {
            public int id;
            public string nombre;
        }

        [HttpGet]
        public IEnumerable<lista> getLista(string tabla, string nombreCampo, string nombreValor, string campoRetorno, string idUsuario )
        {
            IList<lista> listaClientes = new List<lista>();
            DataSet ds = Conexion.ejecutar_select("sp_generico_lst2 '" + tabla + "','" + nombreCampo + "','" + nombreValor + "','" + campoRetorno + "'");

            lista cli = null;

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    cli = new lista();
                    cli.idClieCliente = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                    cli.rut = ds.Tables[0].Rows[i][2].ToString();
                    cli.nombre = ds.Tables[0].Rows[i][3].ToString();
                    cli.apellido = ds.Tables[0].Rows[i][4].ToString();
                    cli.razonSocial = ds.Tables[0].Rows[i][5].ToString();
                    listaClientes.Add(cli);

                }
            }
            else
            {

            }
            return listaClientes;
        }

        [HttpGet]
        public IEnumerable<ComboBox> llenarCb(string campos, string tabla, string order)
        {
            IList<ComboBox> listaCombobox = new List<ComboBox>();
            DataSet ds = Conexion.ejecutar_select("sp_llenaDropDown '" + campos + "','" + tabla + "','" + order + "'");

            ComboBox cb = null;

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    cb = new ComboBox();
                    cb.id = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                    cb.nombre = ds.Tables[0].Rows[i][1].ToString();
                    listaCombobox.Add(cb);

                }
            }
            else
            {
            }
            return listaCombobox;
        }

        //POST api/ZysTablas
        [HttpPost]
        public void eliminarTabla(string tabla, int id)
        {
            bool respuesta = Conexion.ejecutar_comando("sp_generico_del '"+tabla+"', '"+id+"'");
            if (respuesta)
            {
                Console.WriteLine("Eliminado correctamente");
            }
            else
            {
                Console.WriteLine("Error al eliminar" + respuesta);
            }
        }
    }
}
