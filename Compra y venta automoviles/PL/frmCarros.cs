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
    public partial class frmCarros : Form
    {
        //llamada a el archivo carrosDAL
        carrosDAL carros;

        public frmCarros()
        {
            carros = new carrosDAL();
            InitializeComponent();
        }

        //Eventos
        private void frmCarros_Load(object sender, EventArgs e)
        {
            fillDataGridCarros();
        }

        //Funciones
        private void fillDataGridCarros()
        {
            dgvCarros.DataSource = carros.getAllCarros();
        }
        public void borrarCampos()
        {
            txtIdCarro.Clear();
            txtModelo.Clear();
            txtCompra.Clear();
            txtVenta.Clear();
        }

        //Botones
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCarro.Text))
            {
                MessageBox.Show("Debe seleccionar un regisrto de la base de datos para actualizarlo");
            }
            else
            {
                int idCarro = Convert.ToInt32(txtIdCarro.Text);
                string modelo = txtModelo.Text;
                string compra = txtCompra.Text;
                string venta = txtVenta.Text;
                carrosBLL carro = new carrosBLL(idCarro,modelo,compra,venta);
                if (carros.actualizarDatos(carro))
                {
                    MessageBox.Show("El registro se actualizo con exito");
                    borrarCampos();
                    fillDataGridCarros();
                }
                else
                {
                    MessageBox.Show("No se ha podido actualizar el registro");
                }
            }
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtModelo.Text) || string.IsNullOrEmpty(txtCompra.Text) || string.IsNullOrEmpty(txtVenta.Text))
            {
                MessageBox.Show("Todos los campos deben estar llenos");
            }
            else
            {
                string modelo = txtModelo.Text;
                string compra = txtCompra.Text;
                string venta = txtVenta.Text;
                carrosBLL carro = new carrosBLL(0, modelo , compra, venta);

                if (carros.InsertCar(carro))
                {

                    MessageBox.Show("El registro se creo con exito");
                    fillDataGridCarros();
                    borrarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo crear el registro");
                }

            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCarro.Text))
            {
                MessageBox.Show("Debe seleccionar un carro de la base de datos");
            }
            else
            {
                int id_carro = Convert.ToInt32(txtIdCarro.Text);
                carrosBLL carro = new carrosBLL(id_carro);
                var confirmacion = MessageBox.Show("Estas seguro que deseas eliminar este carro?","Confirmar",MessageBoxButtons.YesNo);
                if(confirmacion == DialogResult.Yes)
                {
                    if (carros.borrarCar(carro))
                    {
                        MessageBox.Show("Se ha eliminado el vehiculo con exito");
                        fillDataGridCarros();
                        borrarCampos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar el usario");
                    }
                }

            }
        }

        private void dgvCarros_CellMouseClick(object sender,DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            if(index >= 0)
            {
                txtIdCarro.Text = dgvCarros.Rows[index].Cells[0].Value.ToString();
                txtModelo.Text = dgvCarros.Rows[index].Cells[1].Value.ToString();
                txtCompra.Text = dgvCarros.Rows[index].Cells[2].Value.ToString();
                txtVenta.Text = dgvCarros.Rows[index].Cells[3].Value.ToString();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
