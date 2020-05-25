using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class MaeEmpresa
    {


        public int idMaeEmpresa { get; set; }
        public int idMaeRubro { get; set; }
        public int idClieCliente { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }

        public MaeEmpresa()
        {
            idMaeEmpresa = 0;
            idMaeRubro = 0;
            idClieCliente = 0;
            nombre = "";
            estado = false;
        }
    }
}