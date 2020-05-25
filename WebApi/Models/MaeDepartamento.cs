using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class MaeDepartamento
    {
        public int idMaeDepartamento { get; set; }
        public int idMaeEmpresa { get; set; }
        public string nombre { get; set; }
        public string cuentaContable { get; set; }
        public bool estado { get; set; }

        public MaeDepartamento()
        {
            idMaeDepartamento = 0;
            idMaeEmpresa = 0;
            nombre ="";
            nombre = "";
            estado = false;
        }
    }
}