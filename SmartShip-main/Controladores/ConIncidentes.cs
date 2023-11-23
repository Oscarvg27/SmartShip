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

namespace Controladores
{
    public class ConIncidentes
    {
        public void InsertarIncidente(string Incidentes,int OpUn,int Ruta)
        {
            string sql = "insert into incidentes (descripcion,cve_operadores_unidades,cve_rutas) " + "VALUES (@Incidentes,@OpUn,@Ruta)";
            SqlCommand command = new SqlCommand(sql, Singleton.Instance.conectarBase());
            command.Parameters.AddWithValue("@Incidentes",Incidentes);
            command.Parameters.AddWithValue("@OpUn", OpUn);
            command.Parameters.AddWithValue("@Ruta", Ruta);

            command.ExecuteNonQuery();
        }

        public void LlenarIncidentes(DataGridView tabla1)
        {

            string sql = "select descripcion,cve_operadores_unidades,cve_rutas from incidentes";

            //Hace el select a la base
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, Singleton.Instance.conectarBase());
            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);

            tabla1.DataSource = dt;

            tabla1.Columns[0].HeaderText = "Descripcion";
            tabla1.Columns[1].HeaderText = "Clave Operador";
            tabla1.Columns[2].HeaderText = "Clave Ruta";
        }
    }
}
