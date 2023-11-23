using Microsoft.Data.SqlClient;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controladores
{
    public class Login
    {
        public int ValidarAdmin(string usuario,string password,string tipo)
        {
            string u, p;

            SqlCommand comand;
            SqlDataReader reader;



            //string sql = "Select correo,password from usuarios where correo='admin@gmail.com' AND password='admin'";
            string sql = string.Format("Select correo,password from usuarios where correo='{0}' AND password='{1}'",usuario,password);

            //Hace el select a la base
            comand = new SqlCommand(sql, Singleton.Instance.conectarBase());
            reader = comand.ExecuteReader();

            while(reader.Read())
            {
                u = Convert.ToString(reader.GetValue(0));
                p = Convert.ToString(reader.GetValue(1));

                MessageBox.Show(u+p);

                MessageBox.Show(usuario + password);


                if ((usuario == u) && (password == p) && (tipo == "Admin"))
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            return 0;
        }
    }
}
