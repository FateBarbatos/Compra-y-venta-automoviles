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
    public class EmpleadosDAL
    {
        //Entablamos conexion con nuestra base de datos
        database dbEmpleados;
        public EmpleadosDAL()
        {
            dbEmpleados = new database();
        }

        public DataTable dtEmpleados()
        {
            DataTable tableEmpleados = new DataTable();
            try
            {
                SqlConnection con = dbEmpleados.getConnection();
                using(SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM empleados;";
                    SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                    adaptador.Fill(tableEmpleados);
                    con.Close();
                }
                return tableEmpleados;
            }
            catch
            {
                return tableEmpleados;
            }
        }

        public bool insertarEmpleado(EmpleadosBLL empleadosBLL)
        {
            try
            {
                SqlConnection con = dbEmpleados.getConnection();
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO empleados (nombre , apellidos , dui , telefono) VALUES (@nombre , @apellidos , @dui , @telefono)";
                    cmd.Parameters.AddWithValue("@nombre", empleadosBLL.NombreEmpleados);
                    cmd.Parameters.AddWithValue("@apellidos", empleadosBLL.ApellidoEmpleados);
                    cmd.Parameters.AddWithValue("@dui", empleadosBLL.DuiEmpleados);
                    cmd.Parameters.AddWithValue("@telefono", empleadosBLL.TelefonoEmpleado);
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

        public bool eliminarDatos(EmpleadosBLL eliminar)
        {
            try
            {
                SqlConnection con = dbEmpleados.getConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM empleados WHERE id_empleados = @id_empleados";
                    cmd.Parameters.AddWithValue("@id_empleados",eliminar.Id_empleados);
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

        public bool actualizarDatos(EmpleadosBLL actualizar)
        {
            try
            {
                SqlConnection con = dbEmpleados.getConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "UPDATE empleados SET nombre = @nombre , apellidos = @apellidos , dui = @dui , telefono = @telefono WHERE id_empleados = @id_empleados";
                    cmd.Parameters.AddWithValue("@nombre",actualizar.NombreEmpleados);
                    cmd.Parameters.AddWithValue("@apellidos",actualizar.ApellidoEmpleados);
                    cmd.Parameters.AddWithValue("@dui" , actualizar.DuiEmpleados);
                    cmd.Parameters.AddWithValue("@telefono",actualizar.TelefonoEmpleado);
                    cmd.Parameters.AddWithValue("@id_empleados",actualizar.Id_empleados);
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
