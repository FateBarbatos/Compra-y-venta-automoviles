using Compra_y_venta_automoviles.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compra_y_venta_automoviles.DAL
{
    public class ComprasDAL
    {
        database comprasDAL;

        public ComprasDAL()
        {
            comprasDAL = new database();
        }

        public DataTable tablaCompras()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = comprasDAL.getConnection();
                con.Open();
                using(SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM compras;";
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                }
                con.Close();
                return dt;
            }
            catch
            {
                return dt;
            }
        }

        public bool eliminar(ComprasBLL compras)
        {
            try
            {
                SqlConnection con = comprasDAL.getConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM compras WHERE id_compra = @id_compras";
                    cmd.Parameters.AddWithValue("@id_compras",compras.Id_compra);
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

        public bool actualizarDatos(ComprasBLL compras)
        {
            try
            {
                SqlConnection con = comprasDAL.getConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "UPDATE compras SET precio = @precio , id_proveedores = @id_proveedores , marca = @marca , cantidad = @cantidad , id_carro = @id_carro WHERE id_compra = @id_compras";
                    cmd.Parameters.AddWithValue("@precio",compras.Precio);
                    cmd.Parameters.AddWithValue("@id_proveedores",compras.Id_proveedores);
                    cmd.Parameters.AddWithValue("@marca",compras.Marca);
                    cmd.Parameters.AddWithValue("@cantidad",compras.Cantidad);
                    cmd.Parameters.AddWithValue("@id_carro",compras.Id_carro);
                    cmd.Parameters.AddWithValue("@id_compras",compras.Id_compra);
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

        public bool insertarDatos(ComprasBLL compras)
        {
            try
            {
                SqlConnection con = comprasDAL.getConnection();
                con.Open();
                using(SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO compras (precio , id_proveedores , marca , cantidad , id_carro) VALUES (@precio , @id_proveedores , @marcas , @cantidad , @id_carro)";
                    cmd.Parameters.AddWithValue("@precio", compras.Precio);
                    cmd.Parameters.AddWithValue("@id_proveedores", compras.Id_proveedores);
                    cmd.Parameters.AddWithValue("@marcas", compras.Marca);
                    cmd.Parameters.AddWithValue("@cantidad",compras.Cantidad);
                    cmd.Parameters.AddWithValue("@id_carro",compras.Id_carro);
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
