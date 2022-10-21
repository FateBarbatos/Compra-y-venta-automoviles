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
    public class VentasDAL
    {
        database ventas;

        public VentasDAL()
        {
            ventas = new database();
        }

        public DataTable tbVentas()
        {
            DataTable dt = new DataTable();
            SqlConnection con = ventas.getConnection();
            try
            {
                con.Open();
                using(SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM ventas;";
                    SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                    adaptador.Fill(dt);
                }
                con.Close();
                return dt;
            }
            catch
            {
                return dt;
            }
        }

        public bool eliminar(VentasBLL elim)
        {
            try
            {
                SqlConnection con = ventas.getConnection();
                con.Open();
                using(SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM ventas WHERE id_venta = @id;";
                    cmd.Parameters.AddWithValue("@id",elim.Id_venta);
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
        public bool actualizarTabla(VentasBLL insert,EmpleadosBLL empleados ,CLientesBLL clientes , carrosBLL carros)
        {
            try
            {
                SqlConnection con = ventas.getConnection();
                con.Open();
                using(SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "UPDATE ventas SET precio = @precio , id_cliente = @id_cliente , id_empleado = @id_empleado , cantidad = @cantidad , id_carros = @id_carros WHERE id_venta = @id_venta;";
                    cmd.Parameters.AddWithValue("@precio",insert.Precio);
                    cmd.Parameters.AddWithValue("@id_cliente",clientes.Id_cliente);
                    cmd.Parameters.AddWithValue("@id_empleado" , empleados.Id_empleados);
                    cmd.Parameters.AddWithValue("@cantidad", insert.Cantidad);
                    cmd.Parameters.AddWithValue("@id_carros",carros.Id_carros);
                    cmd.Parameters.AddWithValue("@id_venta", insert.Id_venta);
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
        public bool insertarRegistro(VentasBLL venta, CLientesBLL cliente , EmpleadosBLL empleado , carrosBLL carro)
        {
            try
            {
                SqlConnection con = ventas.getConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO ventas (precio , id_cliente , id_empleado , cantidad , id_carros) VALUES (@precio , @id_cliente , @id_empleado , @cantidad , @id_carros);";
                    cmd.Parameters.AddWithValue("@precio" , venta.Precio);
                    cmd.Parameters.AddWithValue("@id_cliente", cliente.Id_cliente );
                    cmd.Parameters.AddWithValue("@id_empleado", empleado.Id_empleados );
                    cmd.Parameters.AddWithValue("@cantidad", venta.Cantidad);
                    cmd.Parameters.AddWithValue("@id_carros", carro.Id_carros );
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
