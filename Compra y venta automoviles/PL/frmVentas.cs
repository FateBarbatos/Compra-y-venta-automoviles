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
    public partial class frmVentas : Form
    {
        VentasDAL ventas;
        EmpleadosDAL empleados;
        clientesDAL clientes;
        carrosDAL carros;
        public frmVentas()
        {
            InitializeComponent();
            this.ventas = new VentasDAL();
            this.empleados = new EmpleadosDAL();
            this.clientes = new clientesDAL();
            this.carros = new carrosDAL();
        }

        private void cargarDataGrid()
        {
            dgvVentas.DataSource = ventas.tbVentas();
        }

        private void cargarEmpleados()
        {
            cmbEmpleado.DataSource = empleados.dtEmpleados();
            cmbEmpleado.DisplayMember = "nombre";
            cmbEmpleado.ValueMember = "id_empleados";
        }

        private void cargarClientes()
        {
            cmbCliente.DataSource = clientes.getCLients();
            cmbCliente.DisplayMember = "nombre";
            cmbCliente.ValueMember = "id_cliente";
        }

        private void cargarCarros()
        {
            cmbCarros.DataSource = carros.getAllCarros();
            cmbCarros.DisplayMember = "modelo";
            cmbCarros.ValueMember = "id_carro";
        }

        private void limpiarCampos()
        {
            txtIdVentas.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            cargarDataGrid();
            cargarClientes();
            cargarCarros();
            cargarEmpleados();
        }

        private void dgvVentasCellMouse_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            txtIdVentas.Text = dgvVentas.Rows[index].Cells[0].Value.ToString();
            txtPrecio.Text = dgvVentas.Rows[index].Cells[1].Value.ToString();
            cmbCliente.SelectedValue = Convert.ToInt32(dgvVentas.Rows[index].Cells[2].Value);
            cmbEmpleado.SelectedValue = Convert.ToInt32(dgvVentas.Rows[index].Cells[3].Value);
            txtCantidad.Text = dgvVentas.Rows[index].Cells[4].Value.ToString();
            cmbCarros.SelectedValue = Convert.ToInt32(dgvVentas.Rows[index].Cells[5].Value);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdVentas.Text))
            {
                MessageBox.Show("Debe seleccionar una venta para editar");
            }
            else
            {
                int id_venta = Convert.ToInt32(txtIdVentas.Text);
                string precio = txtPrecio.Text;
                int id_cliente = Convert.ToInt32(cmbCliente.SelectedValue);
                int id_empleado = Convert.ToInt32(cmbEmpleado.SelectedValue);
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                int id_carro = Convert.ToInt32(cmbCarros.SelectedValue);

                VentasBLL ventasBLL = new VentasBLL(id_venta,precio,cantidad);
                CLientesBLL clientesBLL = new CLientesBLL(id_cliente,null,null,null);
                EmpleadosBLL empleadosBLL = new EmpleadosBLL(id_empleado,null,null,null,null);
                carrosBLL carrosBLL = new carrosBLL(id_carro,null,null,null);

                if (ventas.actualizarTabla(ventasBLL,empleadosBLL,clientesBLL,carrosBLL))
                {
                    MessageBox.Show("El registro se actualizo correctamente");
                    cargarDataGrid();
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se ha podido actualizar el registro");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdVentas.Text))
            {
                MessageBox.Show("Debe selecionar a un usuario de la tabla");
            }
            else
            {
                int id_venta = Convert.ToInt32(txtIdVentas.Text);
                VentasBLL venta = new VentasBLL(id_venta);
                var confirmar = MessageBox.Show("Esta seguro que desea borrar este usuario", "aceptar", MessageBoxButtons.YesNo);
                if (confirmar == DialogResult.Yes)
                {
                    if (ventas.eliminar(venta))
                    {
                        MessageBox.Show("Se ha eliminado al empleado correctamente");
                        limpiarCampos();
                        cargarDataGrid();
                    }
                }
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrecio.Text) || string.IsNullOrEmpty(cmbCliente.Text) || string.IsNullOrEmpty(cmbEmpleado.Text) || string.IsNullOrEmpty(cmbCarros.Text))
            {
                MessageBox.Show("Debe seleccionar una venta para editar");
            }
            else
            {
                string precio = txtPrecio.Text;
                int id_cliente = Convert.ToInt32(cmbCliente.SelectedValue);
                int id_empleado = Convert.ToInt32(cmbEmpleado.SelectedValue);
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                int id_carro = Convert.ToInt32(cmbCarros.SelectedValue);
                VentasBLL ventasBLL = new VentasBLL(0, precio, cantidad);
                CLientesBLL clientesBLL = new CLientesBLL(id_cliente, null, null, null);
                EmpleadosBLL empleadosBLL = new EmpleadosBLL(id_empleado, null, null, null, null);
                carrosBLL carrosBLL = new carrosBLL(id_carro, null, null, null);
                if (ventas.insertarRegistro(ventasBLL, clientesBLL, empleadosBLL, carrosBLL))
                {
                    MessageBox.Show("Se ha creado el nuevo registro con exito");
                    limpiarCampos();
                    cargarDataGrid();
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
                this.Close();
        }
    }
}
