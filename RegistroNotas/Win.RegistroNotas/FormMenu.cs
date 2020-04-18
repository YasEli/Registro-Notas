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


namespace Win.RegistroNotas
{
    public partial class FormMenu : Form
    {
   
        public FormMenu()
        {
            InitializeComponent();

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            var formLogin = new FormLogin();
            formLogin.ShowDialog();

            if(Program.UsuarioLogueado != null)
            {
                toolStripStatusLabel1.Text = "Usuario: " 
                    + Program.UsuarioLogueado.Nombre;
            }
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formAlumnos = new FormAlumnos();
            formAlumnos.MdiParent = this;
            formAlumnos.Show();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formMaterias = new FormMaterias();
            formMaterias.MdiParent = this;
            formMaterias.Show();
        }

        private void registrarNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formNotas = new FormNotas();
            formNotas.MdiParent = this;
            formNotas.Show();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            var formLogin = new FormLogin();
            formLogin.ShowDialog();


        }

        private void carrerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formCarreras = new FormCarreras();
            formCarreras.MdiParent = this;
            formCarreras.Show();
        }

        private void seccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formSecciones = new FormSecciones();
            formSecciones.MdiParent = this;
            formSecciones.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reporteDeAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteAlumnos = new FormReporteAlumnos();
            formReporteAlumnos.MdiParent = this;
            formReporteAlumnos.Show();
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteTransaccion = new FormReporteTransaccion();
            formReporteTransaccion.MdiParent = this;
            formReporteTransaccion.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formUsuarios = new FormUsuarios();
            formUsuarios.MdiParent = this;
            formUsuarios.Show();
        }
        
    }
}
