using Parcial1Ap1_LuisTejada.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1Ap1_LuisTejada.UI.Registros
{
    public partial class RegistrarEmpleado : Form
    {
        public RegistrarEmpleado()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdTextBox.Clear();
            NombreTextBox.Clear();
            SueldoTextBox.Clear();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Utils.NoWhiteNoSpace(NombreTextBox.Text) && Utils.NoWhiteNoSpace(SueldoTextBox.Text))
            {
                int id = 0;
                id = BLL.EmpleadoBLL.Guardar(new Empleados(Utils.NoWhiteNoSpace(IdTextBox.Text) == false ? 0 : int.Parse(IdTextBox.Text), NombreTextBox.Text, dateTimePicker.Value.Date, int.Parse(SueldoTextBox.Text)));
                if(id != 0)
                {
                    IdTextBox.Text = id.ToString();          
                    MessageBox.Show("Empleado guardado/modificado!");
                    ErrorProvider.Clear();
                }
                else
                {
                    MessageBox.Show("Empleado no se puedo guardar!");
                }                         
            }
            else
            {
                if (!Utils.NoWhiteNoSpace(NombreTextBox.Text) && !Utils.NoWhiteNoSpace(SueldoTextBox.Text))
                {
                    ErrorProvider.SetError(NombreTextBox, "Nombre vacio");
                    ErrorProvider.SetError(SueldoTextBox, "Sueldo vacio");
                }
                else
                {
                    if (!Utils.NoWhiteNoSpace(NombreTextBox.Text))
                        {
                            ErrorProvider.SetError(NombreTextBox, "Nombre vacio");
                        }
                    else
                    {
                        ErrorProvider.SetError(SueldoTextBox, "Sueldo vacio");
                    }          
                }
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if(Utils.NoWhiteNoSpace(IdTextBox.Text))
            {
                if(BLL.EmpleadoBLL.Eliminar(int.Parse(IdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Este empleado eliminado!");
                }
                else
                {

                    MessageBox.Show("No se puedo eliminar!");
                }
            }
            else
            {
                ErrorProvider.SetError(IdTextBox, "Id vacio!");
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            if(Utils.NoWhiteNoSpace(IdTextBox.Text))
            {
                Empleados empleado = BLL.EmpleadoBLL.Buscar(int.Parse(IdTextBox.Text));

                if(empleado != null)
                {
                    NombreTextBox.Text = empleado.Nombres;
                    dateTimePicker.Value = empleado.FechaNacimientos;
                    SueldoTextBox.Text = empleado.Sueldos.ToString();
                    ErrorProvider.Clear();
                }
                else
                {
                    MessageBox.Show("Este id de empleado no existe!");
                }
            }
            else
            {
                ErrorProvider.SetError(IdTextBox, "Id vacio!");
            }
        }
    }
}
