
namespace Compra_y_venta_automoviles
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btnTablaCarros = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTablaClientes = new System.Windows.Forms.Button();
            this.btnTablaEmpleados = new System.Windows.Forms.Button();
            this.btnTablaProveedores = new System.Windows.Forms.Button();
            this.btnTablaCompras = new System.Windows.Forms.Button();
            this.btnTablaVentas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 86);
            this.button1.TabIndex = 0;
            this.button1.Text = "Comprobar conexion con el servidor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTablaCarros
            // 
            this.btnTablaCarros.Location = new System.Drawing.Point(208, 110);
            this.btnTablaCarros.Name = "btnTablaCarros";
            this.btnTablaCarros.Size = new System.Drawing.Size(75, 67);
            this.btnTablaCarros.TabIndex = 1;
            this.btnTablaCarros.Text = "Tabla carros";
            this.btnTablaCarros.UseVisualStyleBackColor = true;
            this.btnTablaCarros.Click += new System.EventHandler(this.btnTablaCarros_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tablas de la base de datos";
            // 
            // btnTablaClientes
            // 
            this.btnTablaClientes.Location = new System.Drawing.Point(207, 40);
            this.btnTablaClientes.Name = "btnTablaClientes";
            this.btnTablaClientes.Size = new System.Drawing.Size(75, 66);
            this.btnTablaClientes.TabIndex = 3;
            this.btnTablaClientes.Text = "Tabla clientes";
            this.btnTablaClientes.UseVisualStyleBackColor = true;
            this.btnTablaClientes.Click += new System.EventHandler(this.btnTablaClientes_Click);
            // 
            // btnTablaEmpleados
            // 
            this.btnTablaEmpleados.Location = new System.Drawing.Point(93, 111);
            this.btnTablaEmpleados.Name = "btnTablaEmpleados";
            this.btnTablaEmpleados.Size = new System.Drawing.Size(108, 66);
            this.btnTablaEmpleados.TabIndex = 4;
            this.btnTablaEmpleados.Text = "Tabla empleados";
            this.btnTablaEmpleados.UseVisualStyleBackColor = true;
            this.btnTablaEmpleados.Click += new System.EventHandler(this.btnTablaEmpleados_Click);
            // 
            // btnTablaProveedores
            // 
            this.btnTablaProveedores.Location = new System.Drawing.Point(93, 39);
            this.btnTablaProveedores.Name = "btnTablaProveedores";
            this.btnTablaProveedores.Size = new System.Drawing.Size(108, 67);
            this.btnTablaProveedores.TabIndex = 5;
            this.btnTablaProveedores.Text = "Tabla proveedores";
            this.btnTablaProveedores.UseVisualStyleBackColor = true;
            this.btnTablaProveedores.Click += new System.EventHandler(this.btnTablaProveedores_Click);
            // 
            // btnTablaCompras
            // 
            this.btnTablaCompras.Location = new System.Drawing.Point(8, 39);
            this.btnTablaCompras.Name = "btnTablaCompras";
            this.btnTablaCompras.Size = new System.Drawing.Size(76, 66);
            this.btnTablaCompras.TabIndex = 6;
            this.btnTablaCompras.Text = "Tabla compras";
            this.btnTablaCompras.UseVisualStyleBackColor = true;
            this.btnTablaCompras.Click += new System.EventHandler(this.btnTablaCompras_Click);
            // 
            // btnTablaVentas
            // 
            this.btnTablaVentas.Location = new System.Drawing.Point(12, 111);
            this.btnTablaVentas.Name = "btnTablaVentas";
            this.btnTablaVentas.Size = new System.Drawing.Size(72, 66);
            this.btnTablaVentas.TabIndex = 7;
            this.btnTablaVentas.Text = "Tabla ventas";
            this.btnTablaVentas.UseVisualStyleBackColor = true;
            this.btnTablaVentas.Click += new System.EventHandler(this.btnTablaVentas_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 282);
            this.Controls.Add(this.btnTablaVentas);
            this.Controls.Add(this.btnTablaCompras);
            this.Controls.Add(this.btnTablaProveedores);
            this.Controls.Add(this.btnTablaEmpleados);
            this.Controls.Add(this.btnTablaClientes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTablaCarros);
            this.Controls.Add(this.button1);
            this.Name = "frmPrincipal";
            this.Text = "Ventana principal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTablaCarros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTablaClientes;
        private System.Windows.Forms.Button btnTablaEmpleados;
        private System.Windows.Forms.Button btnTablaProveedores;
        private System.Windows.Forms.Button btnTablaCompras;
        private System.Windows.Forms.Button btnTablaVentas;
    }
}

