using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1Ap1_LuisTejada.Entidades
{
    public class Empleados
    {
        [Key]
        public int EmpleadoId { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimientos { get; set; }
        public int Sueldos { get; set; }

        public Empleados()
        {

        }
        public Empleados(int empleadoId, string nombre, DateTime fechaNacimiento, int sueldo)
        {
            this.EmpleadoId = empleadoId;
            this.Nombres = nombre;
            this.FechaNacimientos = fechaNacimiento;
            this.Sueldos = sueldo;
        }
    }
}
