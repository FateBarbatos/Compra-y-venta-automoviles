using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compra_y_venta_automoviles.BLL
{
    public class ProveedoresBLL
    {
        int id_proveedores;
        string nombre_proveedores;
        string telefono;
        string e_mail;

        public ProveedoresBLL(int id_proveedores)
        {
            this.id_proveedores = id_proveedores;
        }

        public ProveedoresBLL(int id_proveedores, string nombre_proveedores, string telefono, string e_mail)
        {
            this.id_proveedores = id_proveedores;
            this.nombre_proveedores = nombre_proveedores;
            this.telefono = telefono;
            this.e_mail = e_mail;
        }

        public int Id_proveedores { get => id_proveedores; set => id_proveedores = value; }
        public string Nombre_proveedores { get => nombre_proveedores; set => nombre_proveedores = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string E_mail { get => e_mail; set => e_mail = value; }
    }
}
