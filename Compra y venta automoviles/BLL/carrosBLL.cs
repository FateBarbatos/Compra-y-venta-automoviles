using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compra_y_venta_automoviles.BLL
{
    //clase publica para interactuar con la database
    public class carrosBLL
    {
        private int id_carros;
        private string modelo;
        private string compra;
        private string venta;

        //metodo constructor del boton eliminar
        public carrosBLL(int id_carros)
        {
            this.id_carros = id_carros;
        }

        //metodo constructor del boton insertar
        public carrosBLL(int id_carros, string modelo, string compra, string venta)
        {
            this.id_carros = id_carros;
            this.modelo = modelo;
            this.compra = compra;
            this.venta = venta;
        }

        //clases de los datos
        public int Id_carros { get => id_carros; set => id_carros = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Compra { get => compra; set => compra = value; }
        public string Venta { get => venta; set => venta = value; }
    }
}
