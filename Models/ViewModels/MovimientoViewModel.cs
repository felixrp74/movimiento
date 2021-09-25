using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_1.Models.ViewModels
{
    public class MovimientoViewModel
    {
        public string Responsable { set; get; }

        public List<Equipos> Equipos { set; get; }

        public List<Movimientos> Movimientos { set; get; }

    }

    public class Equipos
    {
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
    }

    public class Movimientos
    {
        public string Fecha { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public int Clave_D1 { get; set; }
        public int Clave_R1 { get; set; }
    }



}