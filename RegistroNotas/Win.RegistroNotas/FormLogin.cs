using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win.RegistroNotas.BL.RegistroNotas;
using static Win.RegistroNotas.BL.RegistroNotas.SeguridadBL;

namespace Win.RegistroNotas
{
    public partial class FormLogin : Form
    {
        SeguridadBL _seguridadBL;

        public Usuario UsuarioAutenticado { get; set; }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nombre = textBox1.Text;
            var contrasena = textBox2.Text;

            var usuarioAutenticar = _seguridadBL.Autenticar(nombre, contrasena);

            if(usuarioAutenticar != null)
            {
                UsuarioAutenticado = usuarioAutenticar;

                this.Close();
            }else
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
        }

        public void CargarDatos(SeguridadBL seguridadBL)
        {
            _seguridadBL = seguridadBL;
        }
    }
}
