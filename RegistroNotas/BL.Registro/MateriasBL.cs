using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _contexto.Materias.Load();
            ListaMaterias = _contexto.Materias.Local.ToBindingList();

            return ListaMaterias;
        }
    }

    public class Materia
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
