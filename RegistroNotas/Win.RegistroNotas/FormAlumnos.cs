using BL.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BL.Registro.AlumnosBL;

namespace Win.RegistroNotas
{
    public partial class FormAlumnos : Form
    {
        AlumnosBL _alumnos;

        public FormAlumnos()
        {
            InitializeComponent();

            _alumnos = new AlumnosBL();

            listaAlumnosBindingSource.DataSource = _alumnos.ObtenerAlumnos();
        }

        private void listaAlumnosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaAlumnosBindingSource.EndEdit();

            var alumno = (Alumno)listaAlumnosBindingSource.Current;

            var resultado = _alumnos.GuardarAlumno(alumno);

            if(resultado.Exitoso == true)
            {
                listaAlumnosBindingSource.ResetBindings(false);
                DesahilitarHabilitarBotones(true);
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _alumnos.AgregarAlumno();
            listaAlumnosBindingSource.MoveLast();

            DesahilitarHabilitarBotones(false);
        }

        private void DesahilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if(idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("¿Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);

                if(resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }    
            }
        }

        private void Eliminar(int id)
        {
            
            var resultado = _alumnos.EliminarAlumno(id);

            if (resultado == true)
            {
                listaAlumnosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrió un error al eliminar los datos.");
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DesahilitarHabilitarBotones(true);
            Eliminar(0);
        }
    }
}
