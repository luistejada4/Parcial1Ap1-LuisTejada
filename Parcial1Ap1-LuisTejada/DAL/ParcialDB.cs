using Parcial1Ap1_LuisTejada.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1Ap1_LuisTejada.DAL
{
    public class ParcialDB : DbContext
    {
        public ParcialDB() : base("ConStr")
        {

        }
        public DbSet<Empleados> Empleados { get; set; }
    }
}
