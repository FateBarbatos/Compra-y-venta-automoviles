using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compra_y_venta_automoviles.BLL
{
    public class EmpleadosBLL
    {
        int id_empleados;
        string nombreEmpleados;
        string apellidoEmpleados;
        string duiEmpleados;
        string telefonoEmpleado;

        public EmpleadosBLL(int id_empleados)
        {
            this.id_empleados = id_empleados;
        }

        public EmpleadosBLL(int id_empleados, string nombreEmpleados, string apellidoEmpleados, string duiEmpleados, string telefonoEmpleado)
        {
            this.id_empleados = id_empleados;
            this.nombreEmpleados = nombreEmpleados;
            this.apellidoEmpleados = apellidoEmpleados;
            this.duiEmpleados = duiEmpleados;
            this.telefonoEmpleado = telefonoEmpleado;
        }

        public int Id_empleados { get => id_empleados; set => id_empleados = value; }
        public string NombreEmpleados { get => nombreEmpleados; set => nombreEmpleados = value; }
        public string ApellidoEmpleados { get => apellidoEmpleados; set => apellidoEmpleados = value; }
        public string DuiEmpleados { get => duiEmpleados; set => duiEmpleados = value; }
        public string TelefonoEmpleado { get => telefonoEmpleado; set => telefonoEmpleado = value; }
    }
}
