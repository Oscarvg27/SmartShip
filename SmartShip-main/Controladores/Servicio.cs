using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Configuration.Internal;
using System.Windows.Input;

namespace Controladores
{
    public class Servicio
    {
        public void InsertarDireccion(string Calle, int Numero,string Colonia,int NumP,string Estado)
        {
            string sql = "insert into direccion (calle,numero,colonia,codigopostal,estado)" + "values (@Calle, @Numero, @Colonia, @NumP, @Estado)";
            SqlCommand command = new SqlCommand(sql, Singleton.Instance.conectarBase());
            command.Parameters.AddWithValue("@Calle",Calle);
            command.Parameters.AddWithValue("@Numero",Numero );
            command.Parameters.AddWithValue("@Colonia", Colonia);
            command.Parameters.AddWithValue("@NumP", NumP);
            command.Parameters.AddWithValue("@Estado", Estado);

            command.ExecuteNonQuery();
        }

        public void LlenarDatos(ComboBox combo1)
        {
            SqlCommand comand;
            SqlDataReader reader;

            string sql = "select calle,numero,colonia,codigopostal,estado from direccion";
            comand = new SqlCommand(sql, Singleton.Instance.conectarBase());
            reader = comand.ExecuteReader();

            while(reader.Read())
            {
                string dato = Convert.ToString(reader.GetValue(0)) + " " + Convert.ToString(reader.GetValue(1)) + " " + Convert.ToString(reader.GetValue(2)) + " " + Convert.ToString(reader.GetValue(3)) + " " + Convert.ToString(reader.GetValue(0));

                combo1.Items.Add(dato);
            }
        }
    }
}
