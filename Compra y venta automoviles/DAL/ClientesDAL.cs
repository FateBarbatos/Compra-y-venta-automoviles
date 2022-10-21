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
    public class clientesDAL
    {
        database dtCientes;

        public clientesDAL()
        {
            dtCientes = new database();
        }

        //Actualizacion de la tabla
        public DataTable getCLients()
        {
            DataTable dataCLient = new DataTable();
            try
            {
                SqlConnection con = dtCientes.getConnection();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM clientes;";
                    SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                    adaptador.Fill(dataCLient);
                    con.Close();

                    return dataCLient;
                }
            }
            catch
            {
                return dataCLient;
            }
        }

        //insertar clientes dentro de la base de datos 
        public bool insertarCLiente(CLientesBLL CLientesBLL)
        {
            try
            {
                SqlConnection con = dtCientes.getConnection();
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO clientes (nombre , contacto , dui) VALUES (@nombre , @contacto , @dui)";
                    cmd.Parameters.AddWithValue("@nombre", CLientesBLL.Nombre);
                    cmd.Parameters.AddWithValue("@contacto", CLientesBLL.Contacto);
                    cmd.Parameters.AddWithValue("@dui", CLientesBLL.Dui);
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

        public bool eliminar(CLientesBLL cliente)
        {
            try
            {
                SqlConnection con = dtCientes.getConnection();
                con.Open();
                using(SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM clientes WHERE id_cliente = @id;";
                    cmd.Parameters.AddWithValue("@id",cliente.Id_cliente);
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

        public bool actualizar(CLientesBLL cliente)
        {
            try
            {
                SqlConnection con = dtCientes.getConnection();
                con.Open();
                using(SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "UPDATE clientes SET nombre = @nombre , contacto = @contacto , dui = @dui WHERE id_cliente = @id;";
                    cmd.Parameters.AddWithValue("@nombre",cliente.Nombre);
                    cmd.Parameters.AddWithValue("@contacto",cliente.Contacto);
                    cmd.Parameters.AddWithValue("@dui",cliente.Dui);
                    cmd.Parameters.AddWithValue("@id",cliente.Id_cliente);
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
