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
    public class InventarioDatos
    {
        public void LlenarDatosCamion(DataGridView tabla1)
        {

            string sql = "Select placa,marca,cant_carga,no_remolques from unidades;";

            //Hace el select a la base
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, Singleton.Instance.conectarBase());
            DataTable dt = new DataTable(); 

            dataAdapter.Fill(dt);
            
            tabla1.DataSource = dt;

            tabla1.Columns[0].HeaderText = "PLACA";
            tabla1.Columns[1].HeaderText = "MARCA";
            tabla1.Columns[2].HeaderText = "CANTIDAD DE CARGA";
            tabla1.Columns[3].HeaderText = "NUMERO DE REMOLQUES";
        }

        public void LLenadDatosOperadores(DataGridView tabla2)
        {
            string sql = "Select nombre,ap_paterno,ap_materno,no_licencia from operadores";

            //Hace el select a la base
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, Singleton.Instance.conectarBase());
            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);

            tabla2.DataSource = dt;

            tabla2.Columns[0].HeaderText = "NOMBRE";
            tabla2.Columns[1].HeaderText = "APELLIDO PATERNO";
            tabla2.Columns[2].HeaderText = "APELLIDO MATERNO";
            tabla2.Columns[3].HeaderText = "NUMERO DE LICENCIA";
        }

        //public void InsertarDatosCamion(string P, string M, int C, int No)
        //{
        //    string sql = "insert into unidades (placa,marca,cant_carga,no_remolques) values (" + "'" + P + "'" + "," + "'" + M + "'" + "," + ",C,No)";

        //    //SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, Singleton.Instance.conectarBase());
        //    SqlCommand sc = new SqlCommand(sql, Singleton.Instance.conectarBase());
        //    sc.ExecuteNonQuery();

        //}

        public void InsertarDatosCamion(string Pla, string Mar, int Cant, int No_rem,int Clien)
        {
            string sql = "INSERT INTO unidades  (placa,marca,cant_carga,no_remolques,cve_cliente) " + "VALUES (@Pla, @Mar, @Cant,@No_rem,@Clien)";
            SqlCommand command = new SqlCommand(sql, Singleton.Instance.conectarBase());
            command.Parameters.AddWithValue("@Pla", Pla);
            command.Parameters.AddWithValue("@Mar", Mar);
            command.Parameters.AddWithValue("@Cant", Cant);
            command.Parameters.AddWithValue("@No_rem", No_rem);
            command.Parameters.AddWithValue("@Clien",Clien);

            command.ExecuteNonQuery();
        }

        public void InsertarDatosOperador(string Nom,string Ap,string Am,int Nl,int Us,int Cl)
        {
            string sql = "insert into operadores(nombre,ap_paterno,ap_materno,no_licencia,cve_usuarios,cve_cliente)" + "values (@Nom, @Ap, @Am, @Nl, @Us, @Cl)";
            SqlCommand command = new SqlCommand(sql,Singleton.Instance.conectarBase());
            command.Parameters.AddWithValue("@Nom",Nom);
            command.Parameters.AddWithValue("@Ap",Ap);
            command.Parameters.AddWithValue("@Am",Am);
            command.Parameters.AddWithValue("@Nl",Nl);
            command.Parameters.AddWithValue("@Us",Us);
            command.Parameters.AddWithValue("@Cl",Cl);

            command.ExecuteNonQuery();
        }

        public void EliminarDatosCamion(DataGridView tabla1)
        {
            string p = tabla1.CurrentRow.Cells[0].Value.ToString();
            string sql = "delete from unidades where placa = '" + p + "'";
            MessageBox.Show(sql);

            SqlCommand command = new SqlCommand(sql, Singleton.Instance.conectarBase());

            command.ExecuteNonQuery();
        }

        public void EliminarDatosOperadores(DataGridView tabla2)
        {
            string n = tabla2.CurrentRow.Cells[0].Value.ToString();
            string sql = "delete from operadores where no_licencia =" + n;
            SqlCommand command = new SqlCommand(sql, Singleton.Instance.conectarBase());

            command.ExecuteNonQuery();
        }
    }
}
