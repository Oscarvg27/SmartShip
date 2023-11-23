using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class usuarios
    {
        public string correo { get; set; }
        public string password { get; set; }
    }

    public class cliente
    {
        public string nombre { get; set; }
        public string ap_materno { get; set; }
        public string ap_paterno { get; set; }
    }

    public class empresa
    {
        public string nombre { get; set;}
    }

    public class direccion
    {
        public string calle { get; set; }
        public int numero { get; set; }
        public string colonia { get; set; }
        public int codigopostal { get; set; }
        public string estado { get; set; }
    }

    public class rutas
    {
        public float totalviaje { get; set; }
    }

    public class unidades
    {
        public string placa { get; set; }
        public int cant_carga { get; set; }
        public string marca { get; set; }
        public int numremolques { get; set; }
    }

    public class operadores
    {
        public string nombre { get; set; }
        public string ap_materno { get; set; }
        public string ap_paterno { get; set; }
        //public int cve_inventario { get; set; }
        public int num_licencia { get; set; }
    }

    public class director
    {
        public string nombre { get; set; }
        public string ap_materno { get; set; }
        public string ap_paterno { get; set; }
    }

    public class tipo_reporte
    {
        public string nombre { get; set; }
    }

    public class GPS
    {
        public string no_serie { get; set; }
    }

    public class incidentes
    {
        public string descripcion { get; set; }
    }


        
}
