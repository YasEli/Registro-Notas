using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.Registro.AlumnosBL;

namespace BL.Registro
{
    public class AlumnosBL
    {
        public BindingList<Alumno> ListaAlumnos { get; set; }

        public AlumnosBL()
        {
            ListaAlumnos = new BindingList<Alumno>();

            var alumno1 = new Alumno();
            alumno1.Id = 1;
            alumno1.Nombre = "Jorge Cobos";
            alumno1.NumeroIdentidad = "12345678";
            alumno1.Curso = "Electricidad";
            alumno1.AnioCursado = 1;

            var alumno2 = new Alumno();
            alumno2.Id = 2;
            alumno2.Nombre = "Edith Lopez";
            alumno2.NumeroIdentidad = "12345678";
            alumno2.Curso = "Inglés";
            alumno2.AnioCursado = 3;

            var alumno3 = new Alumno();
            alumno3.Id = 3;
            alumno3.Nombre = "Greysi Alvarado";
            alumno3.NumeroIdentidad = "12345678";
            alumno3.Curso = "Contabilidad";
            alumno3.AnioCursado = 2;

            ListaAlumnos.Add(alumno1);
            ListaAlumnos.Add(alumno2);
            ListaAlumnos.Add(alumno3);
        }

        public BindingList<Alumno> ObtenerAlumnos()
        {
            return ListaAlumnos;
        }

        public class Alumno
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string NumeroIdentidad { get; set; }
            public string Curso { get; set; }
            public int AnioCursado { get; set; }
        }
    }
}
