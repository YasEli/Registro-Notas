using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win.RegistroNotas.BL.RegistroNotas
{
    public class SeguridadBL
    {
        public List<Usuario>ListadeUsuarios { get; set; }

        public SeguridadBL()
        {
            ListadeUsuarios = new List<Usuario>();
            CargarDatos();
        }

        private void CargarDatos()
        {
            var usuario1 = new Usuario("admin", "1234");
            var usuario2 = new Usuario("admin2", "5678");

            ListadeUsuarios.Add(usuario1);
            ListadeUsuarios.Add(usuario2);
        }

        public Usuario Autenticar(string nombre, string contrasena)
        {
            foreach (var usuario in ListadeUsuarios)
            {
                if (usuario.Nombre == nombre && usuario.Contrasena == contrasena)
                {
                    return usuario;
                }
            }

            return null;
        }

        public class Usuario
        {
            public string Nombre { get; set; }
            public string Contrasena { get; set; }

            public Usuario(string nombre, string contrasena)
            {
                Nombre = nombre;
                Contrasena = contrasena;
            }
        }
    }
}
