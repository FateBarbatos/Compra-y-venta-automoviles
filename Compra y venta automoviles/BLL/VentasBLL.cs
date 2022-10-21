using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compra_y_venta_automoviles.BLL
{
    public class VentasBLL
    {
        private int id_venta;
        private string precio;
        private int cantidad;

        public VentasBLL(int id_venta)
        {
            this.id_venta = id_venta;
        }

        public VentasBLL(int id_venta, string precio, int cantidad)
        {
            this.id_venta = id_venta;
            this.precio = precio;
            this.cantidad = cantidad;
        }

        public int Id_venta { get => id_venta; set => id_venta = value; }
        public string Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}
