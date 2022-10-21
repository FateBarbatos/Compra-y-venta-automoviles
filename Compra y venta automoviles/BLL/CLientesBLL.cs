using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compra_y_venta_automoviles.BLL
{
    public class CLientesBLL
    {
        private int id_cliente;
        private string nombre;
        private string contacto;
        private string dui;

        public CLientesBLL(int id_cliente)
        {
            this.id_cliente = id_cliente;
        }

        public CLientesBLL(int id_cliente, string nombre, string contacto, string dui)
        {
            this.id_cliente = id_cliente;
            this.nombre = nombre;
            this.contacto = contacto;
            this.dui = dui;
        }

        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Contacto { get => contacto; set => contacto = value; }
        public string Dui { get => dui; set => dui = value; }
    }
}
