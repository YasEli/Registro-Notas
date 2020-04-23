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
    public class MateriasBL
    {
        Contexto _contexto;

        public BindingList<Materia> ListaMaterias { get; set; }

        public MateriasBL()
        {
            _contexto = new Contexto();
            ListaMaterias = new BindingList<Materia>();
        }

        public BindingList<Materia> ObtenerMaterias()
        {
            ListaMaterias = new BindingList<Materia>(
                _contexto.Materias.OrderBy(o => o.Descripcion).ToList()
            );

            return ListaMaterias;
        }

        public BindingList<Materia> ObtenerMaterias(string buscar)
        {
            var query = _contexto.Materias
                .Where(m => m.Descripcion.ToLower().Contains(buscar.ToLower()) == true).ToList();

            var resultado = new BindingList<Materia>(query);

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

        public Resultado GuardarMateria(Materia materia)
        {
            var resultado = Validar(materia);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();
            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarMateria()
        {
            var nuevaMateria = new Materia();
            _contexto.Materias.Add(nuevaMateria);
        }

        public bool EliminarMateria(int id)
        {
            foreach (var materia in ListaMaterias.ToList())
            {
                if (materia.Id == id)
                {
                    ListaMaterias.Remove(materia);
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }


        private Resultado Validar(Materia materia)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (materia == null)
            {
                resultado.Mensaje = "Agregue una materia valida";
                resultado.Exitoso = false;

                return resultado;
            }

            if (string.IsNullOrEmpty(materia.Descripcion) == true)
            {
                resultado.Mensaje = "Ingrese una descripcion";
                resultado.Exitoso = false;
            }

            return resultado;
        }
    }

    public class Materia
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
