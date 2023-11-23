using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelos
{
    public class Singleton
    {
        private Singleton() { }

        private static Singleton _instance;

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Singleton();
                return _instance;
            }
        }

        public SqlConnection conectarBase()
        {
            SqlConnection cnn;
            string connectionString = @"Data Source=LAPTOP-PUSDDRN8\SQLEXPRESS ; Initial Catalog = SMARTSHIP; User ID=Jenny;Password = hola123;TrustServerCertificate=True";

            cnn = new SqlConnection(connectionString);

            cnn.Open();

            //Comprobar
            //MessageBox.Show("Connection Open! ");
            return cnn;
        }
    }
}
