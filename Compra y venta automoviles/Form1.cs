using Compra_y_venta_automoviles.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compra_y_venta_automoviles
{
    public partial class frmPrincipal : Form
    {
        database db;
        public frmPrincipal()
        {
            InitializeComponent();
            db = new database();
        }

        



        private void btnTablaCarros_Click(object sender, EventArgs e)
        {
            frmCarros fc = new frmCarros();
            fc.Show();
        }

        private void btnTablaClientes_Click(object sender, EventArgs e)
        {
            frmClientes fClie = new frmClientes();
            fClie.Show();
        }

        private void btnTablaEmpleados_Click(object sender, EventArgs e)
        {
            frmEmpleados frmEmpleados = new frmEmpleados();
            frmEmpleados.Show();
        }

        private void btnTablaProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores frmProveedores = new frmProveedores();
            frmProveedores.Show();
        }

        private void btnTablaVentas_Click(object sender, EventArgs e)
        {
            frmVentas frmVentas = new frmVentas();
            frmVentas.Show();
        }

        private void btnTablaCompras_Click(object sender, EventArgs e)
        {
            frmCompras frmCompras = new frmCompras();
            frmCompras.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Con = db.getConnection();
            Con.Open();
            if (Con.State == System.Data.ConnectionState.Open)
            {
                Con.Close();
                MessageBox.Show("Si se pudo entablar conexion");
            }
            else
            {
                MessageBox.Show("No se pudo entablar conexion");
            }
        }
    }
}
