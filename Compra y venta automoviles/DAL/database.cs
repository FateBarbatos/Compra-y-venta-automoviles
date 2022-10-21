using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Compra_y_venta_automoviles.Properties;

namespace Compra_y_venta_automoviles
{
    public class database
    {
        //Crear una nueva conexion
        public static string getStrConnection()
        {
            return Settings.Default.compra_venta_carrosConnectionString;
        }

        //Obtener conexion con la base de datos
        public SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection(getStrConnection());
            return con;
        }
    }
}
