using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1Ap1_LuisTejada.UI.Consultas
{
    public partial class ConsultarEmpleados : Form
    {
        public ConsultarEmpleados()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            if(FiltrarCheckBox.Checked == false) DataGridView.DataSource = BLL.EmpleadoBLL.GetList();
            else
            {
                if (FechaCheckBox.Checked == true && NombreCheckBox.Checked == true)
                {
                    if (Utils.NoWhiteNoSpace(SearchTextBox.Text)) DataGridView.DataSource = BLL.EmpleadoBLL.GetListFechaAndNombre(DesdeDateTimePicker.Value.Date, HastaDateTimePicker.Value.Date, SearchTextBox.Text);
                    else ErrorProvider.SetError(SearchTextBox, "No puede estar vacio!");
                }
                else
                {
                    if(FechaCheckBox.Checked == true)
                    {
                        DataGridView.DataSource = BLL.EmpleadoBLL.GetListFecha(DesdeDateTimePicker.Value.Date, HastaDateTimePicker.Value.Date);
                    }
                    else if(NombreCheckBox.Checked == true)
                    {
                        if(Utils.NoWhiteNoSpace(SearchTextBox.Text)) DataGridView.DataSource = BLL.EmpleadoBLL.GetListNombre(SearchTextBox.Text);
                        else ErrorProvider.SetError(SearchTextBox, "No puede estar vacio!");
                    }
                }
            }
        }

        private void FiltrarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(FiltrarCheckBox.Checked == true)
            {
                FechaCheckBox.Checked = true;
                NombreCheckBox.Checked = true;
                FechaCheckBox.Enabled = true;
                NombreCheckBox.Enabled = true;
                SearchTextBox.Enabled = true;
            }
            else
            {
                FechaCheckBox.Checked = false;
                NombreCheckBox.Checked = false;
                FechaCheckBox.Enabled = false;
                NombreCheckBox.Enabled = false;
            }
        }

        private void ConsultarEmpleados_Load(object sender, EventArgs e)
        {
            FechaCheckBox.Enabled = false;
            NombreCheckBox.Enabled = false;
            SearchTextBox.Enabled = false;
        }
    }
}
