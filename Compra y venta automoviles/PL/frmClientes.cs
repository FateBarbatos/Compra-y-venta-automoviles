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
    public partial class frmClientes : Form
    {

        clientesDAL clientes;
        public frmClientes()
        {
            this.clientes = new clientesDAL();
            InitializeComponent();
        }

        public void dtgvClientes()
        {
            dgvClientes.DataSource = clientes.getCLients();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            dtgvClientes();
        }
        private void limpCampos()
        {
            txtIdClientes.Clear();
            txtContacto.Clear();
            txtDui.Clear();
            txtNombreCliente.Clear();
        }

        public void dtvClientesCellMouse_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtIdClientes.Text = dgvClientes.Rows[index].Cells[0].Value.ToString();
                txtNombreCliente.Text = dgvClientes.Rows[index].Cells[1].Value.ToString();
                txtDui.Text = dgvClientes.Rows[index].Cells[3].Value.ToString();
                txtContacto.Text = dgvClientes.Rows[index].Cells[2].Value.ToString();
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreCliente.Text) || string.IsNullOrEmpty(txtContacto.Text) || string.IsNullOrEmpty(txtDui.Text))
            {
                MessageBox.Show("Debe llenar los campos nombre y dui y contacto");
            }
            else
            {
                string nombreCLiente = txtNombreCliente.Text;
                string contactoCliente = txtContacto.Text;
                string dui = txtDui.Text;

                CLientesBLL cLientes = new CLientesBLL(0, nombreCLiente, contactoCliente, dui);
                if (clientes.insertarCLiente(cLientes))
                {
                    MessageBox.Show("Se ha completado el registro correctamente");
                    txtNombreCliente.Clear();
                    txtContacto.Clear();
                    txtDui.Clear();
                    dtgvClientes();
                }
                else
                {
                    MessageBox.Show("Error al crear el nuevo registro");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdClientes.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente para eliminar");
            }
            else
            {
                int id_cliente = Convert.ToInt32(txtIdClientes.Text);
                var confirmacion = MessageBox.Show("Desea eliminar a este cliente?", "Aceptar", MessageBoxButtons.YesNo);
                CLientesBLL elimClien = new CLientesBLL(id_cliente);
                if (confirmacion == DialogResult.Yes)
                {
                    if (clientes.eliminar(elimClien))
                    {
                        MessageBox.Show("El cliente se ha eliminado correctamente");
                        dtgvClientes();
                        limpCampos();

                    }
                    else
                    {
                        MessageBox.Show("El cliente no se ha podido eliminar");
                    }
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdClientes.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente de la tabla");
            }
            else
            {
                int id_cliente = Convert.ToInt32(txtIdClientes.Text);
                string nombre = txtNombreCliente.Text;
                string dui = txtDui.Text;
                string telefono = txtContacto.Text;
                CLientesBLL cliente = new CLientesBLL(id_cliente, nombre, telefono, dui);
                if (clientes.actualizar(cliente))
                {
                    MessageBox.Show("Se han actualizado correctamente los datos del cliente");
                    dtgvClientes();
                    limpCampos();
                }
                else
                {
                    MessageBox.Show("No se han podido actualizar los datos del cliente");
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
