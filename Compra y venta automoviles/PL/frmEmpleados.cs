using Compra_y_venta_automoviles.BLL;
using Compra_y_venta_automoviles.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compra_y_venta_automoviles.PL
{
    public partial class frmEmpleados : Form
    {
        EmpleadosDAL empleados;

        
        public frmEmpleados()
        {
            this.empleados = new EmpleadosDAL();
            InitializeComponent();
        }

        public void getEmpleados()
        {
            dgvEmpleados.DataSource = empleados.dtEmpleados();
        }

        public void dgvEmpleadoCellMouse_Click(object sender , DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtIdEmpleado.Text = dgvEmpleados.Rows[index].Cells[0].Value.ToString();
                txtNombreEmpleado.Text = dgvEmpleados.Rows[index].Cells[1].Value.ToString();
                txtApellidoEmpleado.Text = dgvEmpleados.Rows[index].Cells[2].Value.ToString();
                txtDuiEmpleado.Text = dgvEmpleados.Rows[index].Cells[3].Value.ToString();
                txtTelefonoEmpleado.Text = dgvEmpleados.Rows[index].Cells[4].Value.ToString();
            }
        }

        public void limpiarCampos()
        {
            txtIdEmpleado.Clear();
            txtNombreEmpleado.Clear();
            txtApellidoEmpleado.Clear();
            txtDuiEmpleado.Clear();
            txtTelefonoEmpleado.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdEmpleado.Text))
            {
                MessageBox.Show("Debe seleccionar al menos un empleado");
            }
            else
            {
                int id = Convert.ToInt32(txtIdEmpleado.Text);
                string nombres = txtNombreEmpleado.Text;
                string apellidos = txtApellidoEmpleado.Text;
                string dui = txtDuiEmpleado.Text;
                string telefono = txtTelefonoEmpleado.Text;
                EmpleadosBLL empleado = new EmpleadosBLL(id,nombres,apellidos,dui,telefono);
                if (empleados.actualizarDatos(empleado))
                {
                    MessageBox.Show("Se ha actualizado el registro");
                    getEmpleados();
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se ha podido actualizar el registro");
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string nombreEmpleado = txtNombreEmpleado.Text;
            string apellidoEmpleado = txtApellidoEmpleado.Text;
            string telefonoEmpleado = txtTelefonoEmpleado.Text;
            string duiEmpleado = txtDuiEmpleado.Text;

            if(string.IsNullOrEmpty(nombreEmpleado) || string.IsNullOrEmpty(apellidoEmpleado) || string.IsNullOrEmpty(telefonoEmpleado) || string.IsNullOrEmpty(duiEmpleado))
            {
                MessageBox.Show("Debe rellenar los nombre, apellido, telefono, dui");
            }
            else
            {
                EmpleadosBLL empleadosBLL = new EmpleadosBLL(0, nombreEmpleado , apellidoEmpleado , duiEmpleado , telefonoEmpleado);
                if (empleados.insertarEmpleado(empleadosBLL))
                {
                    getEmpleados();
                    MessageBox.Show("El registro se creo con exito");
                    txtNombreEmpleado.Clear();
                    txtApellidoEmpleado.Clear();
                    txtDuiEmpleado.Clear();
                    txtTelefonoEmpleado.Clear();
                }
                else
                {
                    MessageBox.Show("No se ha podido crear el registro");
                }
            }
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            getEmpleados();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id_empleado = Convert.ToInt32(txtIdEmpleado.Text);
            if (string.IsNullOrEmpty(txtIdEmpleado.Text))
            {
                MessageBox.Show("Debe seleccionar un empleado de la tabla");
            }
            else
            {
                var confirmar = MessageBox.Show("Desea eliminar este empleado","Aceptar",MessageBoxButtons.YesNo);
                if (confirmar == DialogResult.Yes)
                {
                    EmpleadosBLL empleadoBorrar = new EmpleadosBLL(id_empleado);
                    if (empleados.eliminarDatos(empleadoBorrar))
                    {
                        MessageBox.Show("Se elimino correctamente al empledo");
                        limpiarCampos();
                        getEmpleados();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar al empleado");
                    }
                }
            }
        }
    }
}
