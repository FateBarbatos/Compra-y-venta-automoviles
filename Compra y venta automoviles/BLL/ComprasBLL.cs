using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compra_y_venta_automoviles.BLL
{
    public class ComprasBLL
    {
        private int id_compra;
        private string precio;
        private int id_proveedores;
        private string marca;
        private int cantidad;
        private int id_carro;

        public ComprasBLL(int id_compra)
        {
            this.id_compra = id_compra;
        }

        public ComprasBLL(int id_compra, string precio, int id_proveedores, string marca, int cantidad, int id_carro)
        {
            this.id_compra = id_compra;
            this.precio = precio;
            this.id_proveedores = id_proveedores;
            this.marca = marca;
            this.cantidad = cantidad;
            this.id_carro = id_carro;
        }

        public int Id_compra { get => id_compra; set => id_compra = value; }
        public string Precio { get => precio; set => precio = value; }
        public int Id_proveedores { get => id_proveedores; set => id_proveedores = value; }
        public string Marca { get => marca; set => marca = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Id_carro { get => id_carro; set => id_carro = value; }
    }
}
