using System.ComponentModel;
using System.Data.Entity;

namespace BL.Registro
{
    public class CarrerasBL
    {
        Contexto _contexto;
        public BindingList<Carrera> ListaCarreras { get; set; }

        public CarrerasBL()
        {
            _contexto = new Contexto();
            ListaCarreras = new BindingList<Carrera>();
        }

        public BindingList<Carrera> ObtenerCarreras()
        {
            _contexto.Carreras.Load();
            ListaCarreras = _contexto.Carreras.Local.ToBindingList();

            return ListaCarreras;
        }
    }

    public class Carrera
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
