using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ZysTabla
    {
        public int idZysTabla { get; set; }
        public string claveSql { get; set; }
        public bool proceso { get; set; }
        public string nombreTabla { get; set; }
        public int idZysMenu { get; set; }
        public Int16 orden { get; set; }
        public string mensaje { get; set; }
        public bool panel { get; set; }
        public bool detalle { get; set; }
        public string urlImg { get; set; }
        public bool reglaCampo { get; set; }
        public string urlManual { get; set; }
        public string urlVideo { get; set; }
        public bool inicializa { get; set; }
        public bool estado { get; set; }
        public bool btnNuevo { get; set; }
        public string btnAdicional { get; set; }
        public string btnOtros { get; set; }
        public bool btnEdit { get; set; }
        public bool btnClonar { get; set; }
        public bool btnEliminar { get; set; }
        public bool btnVer { get; set; }
        public bool btnEditHijo { get; set; }
        public bool btnClonarHijo { get; set; }
        public bool btnEliminarHijo { get; set; }
        public bool btnVerHijo { get; set; }
        public bool sinValida { get; set; }
        public int dosColumnas { get; set; }
        public string integridad { get; set; }
        public string sPValidaDel { get; set; }
        public string controlUser { get; set; }
        public string controlUserB { get; set; }
        public bool cerrarFormulario { get; set; }
        public string btnDel { get; set; }
        public bool subGrid { get; set; }
        public bool confirmarGrabar { get; set; }
        public string grillaCssFila { get; set; }
        public string validaGenerico { get; set; }
        public int gridPadreHeight { get; set; }
        public bool bloqueaCampo { get; set; }
        public string bloqueaCampoCondicion { get; set; }
        public bool grillaSeleccionHijo { get; set; }
        public string campoValor { get; set; }
        public string campoFiltro { get; set; }
        public string spValidaBotonNuevo { get; set; }
        public bool btnGrabar { get; set; }
        public int cantidadFilas { get; set; }
        public string grillaAccionCompleta { get; set; }

        //LLENAR GRILLA
        public int pageCount { get; set; }

        public ZysTabla()
        {
            idZysTabla = 0;
            claveSql = "";
            proceso = false;
            nombreTabla = "";
            idZysMenu = 0;
            orden = 0;
            mensaje = "";
            panel = false;
            detalle = false;
            urlImg = "";
            reglaCampo = false;
            urlManual = "";
            urlVideo = "";
            inicializa = false;
            estado = false;
            btnNuevo = false;
            btnAdicional = "";
            btnOtros = "";
            btnEdit = false;
            btnClonar = false;
            btnEliminar = false;
            btnVer = false;
            btnEditHijo = false;
            btnClonarHijo = false;
            btnEliminarHijo = false;
            btnVerHijo = false;
            sinValida = false;
            dosColumnas = 0;
            integridad = "";
            sPValidaDel = "";
            controlUser = "";
            controlUserB = "";
            cerrarFormulario = false;
            btnDel = "";
            subGrid = false;
            confirmarGrabar = false;
            grillaCssFila = "";
            validaGenerico = "";
            gridPadreHeight = 0;
            bloqueaCampo = false;
            bloqueaCampoCondicion = "";
            grillaSeleccionHijo = false;
            campoValor = "";
            campoFiltro = "";
            spValidaBotonNuevo = "";
            btnGrabar = false;
            cantidadFilas = 0;
            grillaAccionCompleta = "";
        }

    }
}