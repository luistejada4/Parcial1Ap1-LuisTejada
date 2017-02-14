using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1Ap1_LuisTejada
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UI.Registros.RegistrarEmpleado().Show();
        }

        private void consultarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UI.Consultas.ConsultarEmpleados().Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
