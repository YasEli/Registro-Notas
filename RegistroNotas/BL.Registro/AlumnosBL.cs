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
            alumno1.NumeroIdentidad = "1234567891234";
            alumno1.Curso = "Electricidad";
            alumno1.Anio = 2020;

            var alumno2 = new Alumno();
            alumno2.Id = 2;
            alumno2.Nombre = "Edith Lopez";
            alumno2.NumeroIdentidad = "0410199801044";
            alumno2.Curso = "Inglés";
            alumno2.Anio = 2020;

            var alumno3 = new Alumno();
            alumno3.Id = 3;
            alumno3.Nombre = "Greysi Alvarado";
            alumno3.NumeroIdentidad = "1234567891234";
            alumno3.Curso = "Contabilidad";
            alumno3.Anio = 2020;

            ListaAlumnos.Add(alumno1);
            ListaAlumnos.Add(alumno2);
            ListaAlumnos.Add(alumno3);
        }

        public BindingList<Alumno> ObtenerAlumnos()
        {
            return ListaAlumnos;
        }

        //Método para guardar
        public Resultado GuardarAlumno(Alumno alumno)
        {
            var resultado = Validar(alumno);

            if(resultado.Exitoso == false)
            {
                return resultado;
            }

            if(alumno.Id == 0)
            {
                alumno.Id = ListaAlumnos.Max(item => item.Id) + 1;
            }

            resultado.Exitoso = true;
            return resultado;
        }

        //Método para agregar
        public void AgregarAlumno()
        {
            var nuevoAlumno = new Alumno();
            ListaAlumnos.Add(nuevoAlumno);
        }

        //Método para eliminar
        public bool EliminarAlumno(int id)
        {
            foreach (var alumno in ListaAlumnos)
            {
                if(alumno.Id == id)
                {
                    ListaAlumnos.Remove(alumno);
                    return true;
                }
            }
            return false;
        }

        private Resultado Validar(Alumno alumno)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if(string.IsNullOrEmpty(alumno.Nombre) == true)
            {
                resultado.Mensaje = "Ingrese un nombre";
                resultado.Exitoso = false;
            }

            
            if(string.IsNullOrEmpty(alumno.Curso) == true)
            {
                resultado.Mensaje = "Ingrese un curso.";
                resultado.Exitoso = false;
            }
            
            if(Convert.ToString(alumno.Anio).Trim().Length > 4)
            {
                resultado.Mensaje = "Ingrese un año correcto";
                resultado.Exitoso = false;
            }

            if (Convert.ToString(alumno.Anio).Trim().Length < 4)
            {
                resultado.Mensaje = "Ingrese un año correcto";
                resultado.Exitoso = false;
            }

            if(Convert.ToString(alumno.Anio) == "")
            {
                resultado.Mensaje = "Ingrese un año.";
                resultado.Exitoso = false;
            }
            
            if(string.IsNullOrEmpty(alumno.NumeroIdentidad) == true)
            {
                resultado.Mensaje = "Ingrese un número de identidad.";
                resultado.Exitoso = false;
            }

           if(Double.IsNaN(alumno.Anio) == true)
            {
                resultado.Mensaje = "Ingrese un año correcto.";
                resultado.Exitoso = false;
            }

           if(alumno.NumeroIdentidad.Length < 13 || alumno.NumeroIdentidad.Length > 13)
            {
                resultado.Mensaje = "Ingrese un número de identidad correcto.";
                resultado.Exitoso = false;
            }

            return resultado;
        }
        public class Alumno
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string NumeroIdentidad { get; set; }
            public string Curso { get; set; }
            public double Anio { get; set; }
        }

        public class Resultado
        {
            public bool Exitoso { get; set; }
            public string Mensaje { get; set; }
        }
    }
}
