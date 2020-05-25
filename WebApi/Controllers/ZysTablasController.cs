using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ZysTablasController : ApiController
    {
        // GET api/ZysTablas/obtenerTablas
        [HttpGet]
        //O llenarGrilla
        public IEnumerable<ZysTabla> obtenerTablas(int PageSize, int CurrentPage, string SortColumn, string SortOrder, string tabla, string filtro, string IdUsuario)
        {
            IList<ZysTabla> listaTabla = new List<ZysTabla>();
            DataSet ds = Conexion.ejecutar_select("sp_Paginacion_Grilla2 "+PageSize+","+CurrentPage+",'"+SortColumn+"','"+SortOrder+"','"+tabla+"','"+filtro+"','"+IdUsuario+"'");

            ZysTabla zysTabla = null;

            if (ds.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
                {
                    zysTabla = new ZysTabla();
                    zysTabla.detalle = Convert.ToBoolean(ds.Tables[1].Rows[i][0].ToString());
                    zysTabla.mensaje = ds.Tables[1].Rows[i][1].ToString();
                    zysTabla.nombreTabla = ds.Tables[1].Rows[i][2].ToString();
                    zysTabla.orden = Convert.ToInt16(ds.Tables[1].Rows[i][3].ToString());
                    zysTabla.panel = Convert.ToBoolean(ds.Tables[1].Rows[i][4].ToString());
                    zysTabla.subGrid = false;
                    zysTabla.idZysTabla = Convert.ToInt32(ds.Tables[1].Rows[i][6].ToString());
                    zysTabla.pageCount = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());

                    listaTabla.Add(zysTabla);

                }
            }
            else
            {
                zysTabla = new ZysTabla();
                zysTabla.detalle = false;
                zysTabla.mensaje = "";
                zysTabla.nombreTabla = "";
                zysTabla.orden = 0;
                zysTabla.panel = false;
                zysTabla.subGrid = false;
                zysTabla.idZysTabla = 0;
                
            }
            return listaTabla;
        }

        // GET api/ZysTablas/llenarUpdate
        [HttpGet]
        public IEnumerable<ZysTabla> llenarUpdate(int id)
        {
            IList<ZysTabla> listaTabla = new List<ZysTabla>();
            string tabla = "ZysTabla";
            DataSet ds = Conexion.ejecutar_select("sp_generico_sel '" + tabla  + "','" + id + "'");

            ZysTabla zysTabla = new ZysTabla();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    zysTabla.idZysTabla = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                    zysTabla.claveSql=ds.Tables[0].Rows[i][1].ToString();
                    zysTabla.proceso=Convert.ToBoolean(ds.Tables[0].Rows[i][2].ToString());
                    zysTabla.nombreTabla=ds.Tables[0].Rows[i][3].ToString();
                    zysTabla.idZysMenu=Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
                    zysTabla.orden=Convert.ToInt16(ds.Tables[0].Rows[i][5].ToString());
                    zysTabla.mensaje=ds.Tables[0].Rows[i][6].ToString();
                    zysTabla.panel=Convert.ToBoolean(ds.Tables[0].Rows[i][7].ToString());
                    zysTabla.detalle=Convert.ToBoolean(ds.Tables[0].Rows[i][8].ToString());
                    zysTabla.urlImg=ds.Tables[0].Rows[i][9].ToString();
                    zysTabla.reglaCampo=Convert.ToBoolean(ds.Tables[0].Rows[i][10].ToString());
                    zysTabla.urlManual=ds.Tables[0].Rows[i][11].ToString();
                    zysTabla.urlVideo=ds.Tables[0].Rows[i][12].ToString();
                    zysTabla.inicializa=Convert.ToBoolean(ds.Tables[0].Rows[i][13].ToString());
                    zysTabla.estado=Convert.ToBoolean(ds.Tables[0].Rows[i][14].ToString());
                    zysTabla.btnNuevo=Convert.ToBoolean(ds.Tables[0].Rows[i][15].ToString());
                    zysTabla.btnAdicional=ds.Tables[0].Rows[i][16].ToString();
                    zysTabla.btnOtros=ds.Tables[0].Rows[i][17].ToString();
                    zysTabla.btnEdit=Convert.ToBoolean(ds.Tables[0].Rows[i][18].ToString());
                    zysTabla.btnClonar=Convert.ToBoolean(ds.Tables[0].Rows[i][19].ToString());
                    zysTabla.btnEliminar=Convert.ToBoolean(ds.Tables[0].Rows[i][20].ToString());
                    zysTabla.btnVer=Convert.ToBoolean(ds.Tables[0].Rows[i][21].ToString());
                    zysTabla.btnEditHijo=Convert.ToBoolean(ds.Tables[0].Rows[i][22].ToString());
                    zysTabla.btnClonarHijo=Convert.ToBoolean(ds.Tables[0].Rows[i][23].ToString());
                    zysTabla.btnEliminarHijo=Convert.ToBoolean(ds.Tables[0].Rows[i][24].ToString());
                    zysTabla.btnVerHijo=Convert.ToBoolean(ds.Tables[0].Rows[i][25].ToString());
                    zysTabla.sinValida=Convert.ToBoolean(ds.Tables[0].Rows[i][26].ToString());
                    zysTabla.dosColumnas=Convert.ToInt32(ds.Tables[0].Rows[i][27].ToString());
                    zysTabla.integridad=ds.Tables[0].Rows[i][28].ToString();
                    zysTabla.sPValidaDel=ds.Tables[0].Rows[i][29].ToString();
                    zysTabla.controlUser=ds.Tables[0].Rows[i][30].ToString();
                    zysTabla.controlUserB=ds.Tables[0].Rows[i][31].ToString();
                    zysTabla.cerrarFormulario=Convert.ToBoolean(ds.Tables[0].Rows[i][32].ToString());
                    zysTabla.btnDel=ds.Tables[0].Rows[i][33].ToString();
                    zysTabla.subGrid=Convert.ToBoolean(ds.Tables[0].Rows[i][34].ToString());
                    zysTabla.confirmarGrabar=Convert.ToBoolean(ds.Tables[0].Rows[i][35].ToString());
                    zysTabla.grillaCssFila=ds.Tables[0].Rows[i][36].ToString();
                    zysTabla.validaGenerico=ds.Tables[0].Rows[i][37].ToString();
                    zysTabla.gridPadreHeight=Convert.ToInt32(ds.Tables[0].Rows[i][38].ToString());
                    zysTabla.bloqueaCampo=Convert.ToBoolean(ds.Tables[0].Rows[i][39].ToString());
                    zysTabla.bloqueaCampoCondicion=ds.Tables[0].Rows[i][40].ToString();
                    zysTabla.grillaSeleccionHijo=Convert.ToBoolean(ds.Tables[0].Rows[i][41].ToString());
                    zysTabla.campoValor=ds.Tables[0].Rows[i][42].ToString();
                    zysTabla.campoFiltro=ds.Tables[0].Rows[i][43].ToString();
                    zysTabla.spValidaBotonNuevo=ds.Tables[0].Rows[i][44].ToString();
                    zysTabla.btnGrabar=Convert.ToBoolean(ds.Tables[0].Rows[i][45].ToString());
                    zysTabla.cantidadFilas=Convert.ToInt32(ds.Tables[0].Rows[i][46].ToString());
                    zysTabla.grillaAccionCompleta=ds.Tables[0].Rows[i][47].ToString();


                    listaTabla.Add(zysTabla);

                }
            }
            else
            {
                //else
            }
            return listaTabla;
        }


        //POST api/ZysTablas
        [HttpPost]
        public void registrarTabla(int idZystabla,
            string claveSql,
            bool proceso,
            string nombreTabla,
            int idZysMenu,

            Int16 orden,
            string mensaje,
            bool panel,
            bool detalle,
            string urlImg,

            bool reglaCampo,
            string urlManual,
            string urlVideo,
            bool inicializa,
            bool estado,

            bool btnNuevo,
            string btnAdicional,
            string btnOtros,
            bool btnEdit,
            bool btnClonar,

            bool btnEliminar,
            bool btnVer,
            bool btnEditHijo,
            bool btnClonarHijo,
            bool btnEliminarHijo,

            bool btnVerHijo,
            bool sinValida,
            int dosColumna,
            string integridad,
            string spValidaDel,

            string controlUser,
            string controlUserB,
            bool cerrarFormulario,
            string btnDel,
            bool subGrid,

            bool confirmarGrabar,
            string grillaCssFila,
            string validaGenerico,
            int gridPadreHeight,
            bool bloqueaCampo,

            string bloqueaCampoCondicion,
            bool grillaSeleccionHijo,
            string campoValor,
            string campoFiltro,
            string spValidaBotonNuevo,

            bool btnGrabar,
            int cantidadFilas,
            string grillaAccionCompleta)
        {

            ZysTabla tabla = new ZysTabla();

            tabla.idZysTabla = idZystabla;
            tabla.claveSql = claveSql;
            tabla.proceso = proceso;
            tabla.nombreTabla = nombreTabla;
            tabla.idZysMenu = idZysMenu;
            tabla.orden = orden;
            tabla.mensaje = mensaje;
            tabla.panel = panel;
            tabla.detalle = detalle;
            tabla.urlImg = urlImg;
            tabla.reglaCampo = reglaCampo;
            tabla.urlManual = urlManual;
            tabla.urlVideo = urlVideo;
            tabla.inicializa = inicializa;
            tabla.estado = estado;
            tabla.btnNuevo = btnNuevo;
            tabla.btnAdicional = btnAdicional;
            tabla.btnOtros = btnOtros;
            tabla.btnEdit = btnEdit;
            tabla.btnClonar = btnClonar;
            tabla.btnEliminar = btnEliminar;
            tabla.btnVer = btnVer;
            tabla.btnEditHijo = btnEditHijo;
            tabla.btnClonarHijo = btnClonarHijo;
            tabla.btnEliminarHijo = btnEliminarHijo;
            tabla.btnVerHijo = btnVerHijo;
            tabla.sinValida = sinValida;
            tabla.dosColumnas = dosColumna;
            tabla.integridad = integridad;
            tabla.sPValidaDel = spValidaDel;
            tabla.controlUser = controlUser;
            tabla.controlUserB = controlUserB;
            tabla.cerrarFormulario = cerrarFormulario;
            tabla.btnDel = btnDel;
            tabla.subGrid = subGrid;
            tabla.confirmarGrabar = confirmarGrabar;
            tabla.grillaCssFila = grillaCssFila;
            tabla.validaGenerico = validaGenerico;
            tabla.gridPadreHeight = gridPadreHeight;
            tabla.bloqueaCampo = bloqueaCampo;
            tabla.bloqueaCampoCondicion = bloqueaCampoCondicion;
            tabla.grillaSeleccionHijo = grillaSeleccionHijo;
            tabla.campoValor = campoValor;
            tabla.campoFiltro = campoFiltro;
            tabla.spValidaBotonNuevo = spValidaBotonNuevo;
            tabla.btnGrabar = btnGrabar;
            tabla.cantidadFilas = cantidadFilas;
            tabla.grillaAccionCompleta = grillaAccionCompleta;



            bool respuesta = Conexion.ejecutar_comando("DECLARE @SQLString2 nvarchar(max);"+
                "DECLARE @variables2 nvarchar(max);"+
               " execute sp_generico_upd_ins_t 'ZysTabla','','' ,@SQLString=@SQLString2 output,@variables=@variables2 output"+
               " EXECUTE sp_executesql @SQLString2,@variables2,"+tabla.idZysTabla+" , '"
               +tabla.claveSql+"' ,"
               +tabla.proceso+",'"
               +tabla.nombreTabla+"',"
               +tabla.idZysMenu+","
               +tabla.orden+",'"
               +tabla.mensaje+"',"
               +tabla.panel+","
               +tabla.detalle+",'"
               +tabla.urlImg+"',"
               +tabla.reglaCampo+",'"
               +tabla.urlManual+"','"
               +tabla.urlVideo+"',"
               +tabla.inicializa+","
               +tabla.estado+","
               +tabla.btnNuevo+",'"
               +tabla.btnAdicional+"','"
               +tabla.btnOtros+"',"
               +tabla.btnEdit+ "," 
               +tabla.btnClonar+ "," 
               + tabla.btnEliminar + "," 
               + tabla.btnVer + "," 
               + tabla.btnEditHijo + "," 
               + tabla.btnClonarHijo + "," 
               + tabla.btnEliminarHijo + "," 
               + tabla.btnVerHijo + "," 
               + tabla.sinValida + ","
               +tabla.dosColumnas+",'"
               +tabla.integridad+"','"
               +tabla.sPValidaDel+"','"
               +tabla.controlUser+"','"
               +tabla.controlUserB+"',"
               +tabla.cerrarFormulario+",'"
               +tabla.btnDel+"',"
               +tabla.subGrid+","
               +tabla.confirmarGrabar+",'"
               +tabla.grillaCssFila+"','"
               +tabla.validaGenerico+"',"
               +tabla.gridPadreHeight+","
               +tabla.bloqueaCampo+",'"
               +tabla.bloqueaCampoCondicion+"',"
               +tabla.grillaSeleccionHijo+",'"
               +tabla.campoValor+"','"
               +tabla.campoFiltro+"','"
               +tabla.spValidaBotonNuevo+"',"
               +tabla.btnGrabar+","
               +tabla.cantidadFilas+",'"
               +tabla.grillaAccionCompleta+"'");
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
