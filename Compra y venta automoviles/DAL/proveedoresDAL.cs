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
    public class proveedoresDAL
    {
        database dbProveedores;

        public proveedoresDAL()
        {
            dbProveedores = new database();
        }

        public DataTable dtProveedores()
        {
            DataTable dtProveedores = new DataTable();
            SqlConnection con = dbProveedores.getConnection();
            using(SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM proveedores;";
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                adaptador.Fill(dtProveedores);
                con.Close();
            }

            return dtProveedores;
        }

        public bool insertarProveedor(ProveedoresBLL ProveedoresBLL)
        {

            try
            {
                SqlConnection con = dbProveedores.getConnection();
                con.Open();
                using(SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO proveedores (nombre_proveedores , telefono , e_mail) VALUES (@nombre , @telefono , @email);";
                    cmd.Parameters.AddWithValue("@nombre",ProveedoresBLL.Nombre_proveedores);
                    cmd.Parameters.AddWithValue("@telefono", ProveedoresBLL.Telefono);
                    cmd.Parameters.AddWithValue("@email",ProveedoresBLL.E_mail);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarProveedor(ProveedoresBLL proveedoresBLL)
        {
            try
            {

                SqlConnection con = dbProveedores.getConnection(); con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM proveedores WHERE id_proveedores = @idProveedor";
                    cmd.Parameters.AddWithValue("@idProveedor", proveedoresBLL.Id_proveedores);
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

        public bool actualizarTabla(ProveedoresBLL proveedores)
        {
            try
            {
                SqlConnection con = dbProveedores.getConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "UPDATE proveedores SET nombre_proveedores = @nom, telefono = @tel, e_mail = @email WHERE id_proveedores = @idProveedores;";
                    cmd.Parameters.AddWithValue("@nom", proveedores.Nombre_proveedores);
                    cmd.Parameters.AddWithValue("@tel", proveedores.Telefono);
                    cmd.Parameters.AddWithValue("@email", proveedores.E_mail);
                    cmd.Parameters.AddWithValue("@idProveedores", proveedores.Id_proveedores);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
