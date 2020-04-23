using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.Registro.AlumnosBL;

namespace BL.Registro
{
    public class SeguridadBL
    {
        Contexto _contexto;

        public BindingList<Usuario> ListaUsuarios { get; set; }

        public SeguridadBL()
        {
            _contexto = new Contexto();
            ListaUsuarios = new BindingList<Usuario>();
        }

        public BindingList<Usuario> ObtenerUsuarios()
        {
            ListaUsuarios = new BindingList<Usuario>(
                _contexto.Usuarios.OrderBy(o => o.Nombre).ToList()
            );

            return ListaUsuarios;
        }

        public BindingList<Usuario> ObtenerUsuarios(string buscar)
        {
            var query = _contexto.Usuarios
                .Where(u => u.Nombre.ToLower().Contains(buscar.ToLower()) == true).ToList();

            var resultado = new BindingList<Usuario>(query);

            return resultado;
        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }

        public Resultado GuardarUsuario(Usuario usuario)
        {
            var resultado = Validar(usuario);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();
            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarUsuario()
        {
            var nuevoUsuario = new Usuario();
            _contexto.Usuarios.Add(nuevoUsuario);
        }

        public bool EliminarUsuario(int id)
        {
            foreach (var usuario in ListaUsuarios.ToList())
            {
                if (usuario.Id == id)
                {
                    ListaUsuarios.Remove(usuario);
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        private Resultado Validar(Usuario usuario)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (usuario == null)
            {
                resultado.Mensaje = "Agregue un usuario valido";
                resultado.Exitoso = false;

                return resultado;
            }

            return resultado;
        }
        
        public Usuario Autorizar(string nombre, string contrasena)
        {
            var usuarios = _contexto.Usuarios.ToList();

            foreach (var usuario in usuarios)
            {
                if(nombre == usuario.Nombre && contrasena == usuario.Contrasena)
                {
                    return usuario;
                }
            }
            return null;
        }
        
        public class Usuario
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Contrasena { get; set; }
            public string TipoUsuario { get; set; }

        }
       
    }
}
