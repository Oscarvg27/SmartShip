using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace Controladores
{
    public class Reporte
    {
        public void LlenarDatos(ComboBox combo1)
        {
            SqlCommand comand;
            SqlDataReader reader;

            string sql = "select nombre from tipo_reporte;";
            comand = new SqlCommand(sql, Singleton.Instance.conectarBase());
            reader = comand.ExecuteReader();

            while (reader.Read())
            {
                string dato = Convert.ToString(reader.GetValue(0));

                combo1.Items.Add(dato);
            }
        }
    }
}
