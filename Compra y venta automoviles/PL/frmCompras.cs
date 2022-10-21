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
    public partial class frmCompras : Form
    {
        ComprasDAL compras;
        proveedoresDAL proveedores;
        carrosDAL carros;
        public frmCompras()
        {
            InitializeComponent();
            this.compras = new ComprasDAL();
            this.proveedores = new proveedoresDAL();
            this.carros = new carrosDAL();
        }

        public void listProveedores()
        {
            cmbProveedores.DataSource = proveedores.dtProveedores();
            cmbProveedores.DisplayMember = "nombre_proveedores";
            cmbProveedores.ValueMember = "id_proveedores";
        }

        public void listCarros()
        {
            cmbCarros.DataSource = carros.getAllCarros();
            cmbCarros.DisplayMember = "modelo";
            cmbCarros.ValueMember = "id_carro";
        }

        public void limpiarCampos()
        {
            txtIdCompra.Clear();
            txtMarca.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
        }

        public void llenarDGV()
        {
            dgvCompras.DataSource = compras.tablaCompras();
        }

        private void dgvComprasCellMouse_CLick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            txtIdCompra.Text = dgvCompras.Rows[index].Cells[0].Value.ToString();
            cmbProveedores.SelectedValue = Convert.ToInt32(dgvCompras.Rows[index].Cells[2].Value);
            txtMarca.Text = dgvCompras.Rows[index].Cells[3].Value.ToString();
            txtCantidad.Text = dgvCompras.Rows[index].Cells[4].Value.ToString();
            txtPrecio.Text = dgvCompras.Rows[index].Cells[1].Value.ToString();
            cmbCarros.SelectedValue = Convert.ToInt32(dgvCompras.Rows[index].Cells[5].Value);
        }
        private void frmCompras_Load(object sender, EventArgs e)
        {
            listCarros();
            listProveedores();
            llenarDGV();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbProveedores.Text))
            {
                MessageBox.Show("Debe rellenar al menos el campo de proveedores");
            }
            else
            {
                int id_proveedor = Convert.ToInt32(cmbProveedores.SelectedValue);
                string precio = txtPrecio.Text;
                string marca = txtMarca.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                int modelo = Convert.ToInt32(cmbCarros.SelectedValue);
                ComprasBLL comprasBLL = new ComprasBLL(0, precio, id_proveedor, marca, cantidad, modelo);
                if (compras.insertarDatos(comprasBLL))
                {
                    MessageBox.Show("Se agrego el nuevo registro");
                    llenarDGV();
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el nuevo registro");
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCompra.Text))
            {
                MessageBox.Show("Debe seleccionar al menos un registro");
            }
            else
            {
                int id_compra = Convert.ToInt32(txtIdCompra.Text);
                int nombreProv = Convert.ToInt32(cmbProveedores.SelectedValue);
                string marca = txtMarca.Text;
                string precio = txtPrecio.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                int modelo = Convert.ToInt32(cmbCarros.SelectedValue);
                ComprasBLL compra = new ComprasBLL(id_compra,precio,nombreProv,marca,cantidad,modelo);
                if (compras.actualizarDatos(compra))
                {
                    MessageBox.Show("Se han actualizado correctamente los datos");
                    limpiarCampos();
                    llenarDGV();
                }
                else
                {
                    MessageBox.Show("No se pudo el registro");
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCompra.Text))
            {
                MessageBox.Show("Debe seleccionar un registro de la tabla para eliminar");
            }else
            {
                var confirmar = MessageBox.Show("Desea eliminar el registro?","Aceptar",MessageBoxButtons.YesNo);
                int id_compra = Convert.ToInt32(txtIdCompra.Text);
                if (DialogResult.Yes == confirmar)
                { 
                    ComprasBLL eliminar = new ComprasBLL(id_compra);
                    if (compras.eliminar(eliminar))
                    {
                        MessageBox.Show("Se ha eliminado correctamente el registro");
                        limpiarCampos();
                        llenarDGV();
                    }
                    else
                    {
                        MessageBox.Show("No se ha eliminado el registro");
                    }
                }
            }
        }
    }
}
