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
    public partial class frmProveedores : Form
    {
        proveedoresDAL proveedores;
        public frmProveedores()
        {
            this.proveedores = new proveedoresDAL();
            InitializeComponent();
        }

        private void ActualizarTabla()
        {
            dgvTablaProveedores.DataSource = proveedores.dtProveedores();
        }

        private void eliminarCampos()
        {
            txtIdProveedores.Clear();
            txtNombreProveedor.Clear();
            txtTelefonoProveedor.Clear();
            txtEmailProveedor.Clear();
        }

        private void dgvTablaProveedoresCellMouse_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            txtIdProveedores.Text = dgvTablaProveedores.Rows[index].Cells[0].Value.ToString();
            txtNombreProveedor.Text = dgvTablaProveedores.Rows[index].Cells[1].Value.ToString();
            txtTelefonoProveedor.Text = dgvTablaProveedores.Rows[index].Cells[2].Value.ToString();
            txtEmailProveedor.Text = dgvTablaProveedores.Rows[index].Cells[3].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtIdProveedores.Text))
            {
                MessageBox.Show("Debe especificar una id para cambiar o datos de la tabla");
            }
            else
            {
                int idProveedor = Convert.ToInt32(txtIdProveedores.Text);
                string nombreProveedor = txtNombreProveedor.Text;
                string telefonoProveedor = txtTelefonoProveedor.Text;
                string emailProveedor = txtEmailProveedor.Text;
                ProveedoresBLL proveedor = new ProveedoresBLL(idProveedor,nombreProveedor,telefonoProveedor,emailProveedor);
                if (proveedores.actualizarTabla(proveedor))
                {
                    MessageBox.Show("No hemos podido actualizar el registro");
                }
                else
                {
                    MessageBox.Show("Se ha actualizado el registro correctamente");
                    eliminarCampos();
                    ActualizarTabla();
                }
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreProveedor.Text) || string.IsNullOrEmpty(txtTelefonoProveedor.Text))
            {
                MessageBox.Show("Debe rellenar al menos el nombre y el numero de telefono");
            }
            else
            {
                string nombreProveedor = txtNombreProveedor.Text;
                string telefonoProveedor = txtTelefonoProveedor.Text;
                string emailProveedor = txtEmailProveedor.Text;
                ProveedoresBLL proveedor = new ProveedoresBLL(0, nombreProveedor, telefonoProveedor, emailProveedor);
                if (proveedores.insertarProveedor(proveedor))
                {
                    MessageBox.Show("No se pudo crear el registro");
                    
                }
                else
                {
                    MessageBox.Show("El registro se creo correctamente");
                    ActualizarTabla();
                    eliminarCampos();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdProveedores.Text))
            {
                MessageBox.Show("Debe de seleccionar un empleado");
            }
            else
            {
                var opcion = MessageBox.Show("Desea eliminar este empleado?","Aceptar",MessageBoxButtons.YesNo);
                if (opcion == DialogResult.Yes)
                {
                    int id_proveedor = Convert.ToInt32(txtIdProveedores.Text);
                    ProveedoresBLL proveedor = new ProveedoresBLL(id_proveedor);
                    if (proveedores.eliminarProveedor(proveedor))
                    {
                        MessageBox.Show("Se ha eliminado el registro correctamente");
                        eliminarCampos();
                        ActualizarTabla();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar el registro");
                    }
                }
            }
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
