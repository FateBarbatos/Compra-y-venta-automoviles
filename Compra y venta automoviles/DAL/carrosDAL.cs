using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Compra_y_venta_automoviles.BLL;
using System.Data;

namespace Compra_y_venta_automoviles.DAL
{
    
    public class carrosDAL
    {
        //Base de datos
        database db;
        public carrosDAL()
        {
            db = new database();
        }

        //Funcion para obtener todos los objetos de una taba
        public DataTable getAllCarros()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = db.getConnection();
                con.Open();

                using (SqlCommand comand = con.CreateCommand())
                {
                    comand.CommandText = "SELECT * FROM carros;";
                    SqlDataAdapter adapter = new SqlDataAdapter(comand);
                    adapter.Fill(dt);
                    con.Close();
                    return dt;
                }
            }
            catch
            {
                return dt;
            }
        }

        //Funcion para insertar registros del formulario a una tabla
        public bool InsertCar(carrosBLL carrosBLL)
        {
            try {
                SqlConnection con = db.getConnection();
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO carros (modelo , compra , venta) VALUES (@model , @compr , @venta)";
                    cmd.Parameters.AddWithValue("@model", carrosBLL.Modelo);
                    cmd.Parameters.AddWithValue("@compr", carrosBLL.Compra);
                    cmd.Parameters.AddWithValue("@venta", carrosBLL.Venta);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }  
        }

        //Funcion para borrar registros del formulario
        public bool borrarCar(carrosBLL borrarCarro)
        {
            try
            {
                SqlConnection con = db.getConnection();
                con.Open();
                using(SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Carros WHERE id_carro = @id_carro";
                    cmd.Parameters.AddWithValue("@id_carro",borrarCarro.Id_carros);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool actualizarDatos(carrosBLL actualizar)
        {
            try
            {
                SqlConnection con = db.getConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "UPDATE carros SET modelo = @modelo , compra = @compra , venta = @venta WHERE id_carro = @id_carro";
                    cmd.Parameters.AddWithValue("@modelo",actualizar.Modelo);
                    cmd.Parameters.AddWithValue("@compra",actualizar.Compra);
                    cmd.Parameters.AddWithValue("@venta", actualizar.Venta);
                    cmd.Parameters.AddWithValue("@id_carro",actualizar.Id_carros);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
