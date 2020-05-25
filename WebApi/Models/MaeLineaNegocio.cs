using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class MaeLineaNegocio
    {
        public int idMaeLineaNegocio { get; set; }
        public int idMaeEmpresa { get; set; }
        public int idMaeDepartamento { get; set; }
        public string nombre { get; set; }
        public string cuentaContable { get; set; }
        public bool comisionGrupo { get; set; }
        public bool estado { get; set; }
    }
}