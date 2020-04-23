using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.Registro.AlumnosBL;
using static BL.Registro.SeguridadBL;

namespace BL.Registro
{
    public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var usuario = new Usuario();
            usuario.Nombre = "admin";
            usuario.Contrasena = "1234";
            usuario.TipoUsuario = "Administradores";

            contexto.Usuarios.Add(usuario);

            /*
            var carrera1 = new Carrera();
            carrera1.Descripcion = "Administracion de Empresas";

            var carrera2 = new Carrera();
            carrera2.Descripcion = "Contaduria y finanzas";

            var carrera3 = new Carrera();
            carrera3.Descripcion = "Matematicas";

            contexto.Carreras.Add(carrera1);
            contexto.Carreras.Add(carrera2);
            contexto.Carreras.Add(carrera3);

            var materia1 = new Materia();
            materia1.Descripcion = "Español";

            var materia2 = new Materia();
            materia2.Descripcion = "Matematicas";

            var materia3 = new Materia();
            materia3.Descripcion = "Historia";

            var materia4 = new Materia();
            materia4.Descripcion = "Sociologia";

            contexto.Materias.Add(materia1);
            contexto.Materias.Add(materia2);
            contexto.Materias.Add(materia3);
            contexto.Materias.Add(materia4);
            

            var seccion1 = new Seccion();
            seccion1.Descripcion = "S1";

            var seccion2 = new Seccion();
            seccion2.Descripcion = "S2";

            var seccion3 = new Seccion();
            seccion3.Descripcion = "S3";

            contexto.Secciones.Add(seccion1);
            contexto.Secciones.Add(seccion2);
            contexto.Secciones.Add(seccion3);
            */

            var archivo = "../../../clientes.csv";
            using (var reader = new StreamReader(archivo))
            {
                reader.ReadLine(); // Lee primera fila de encabezados

                while (!reader.EndOfStream)
                {
                    var linea = reader.ReadLine();
                    var valores = linea.Split(',');

                    var materiaNueva = new Materia();
                    materiaNueva.Descripcion = valores[0].ToString();
                    
                    contexto.Materias.Add(materiaNueva);
                }
            }

            var archivo2 = "../../../carreras.csv";
            using (var reader = new StreamReader(archivo2))
            {
                reader.ReadLine(); // Lee primera fila de encabezados

                while (!reader.EndOfStream)
                {
                    var linea = reader.ReadLine();
                    var valores = linea.Split(',');

                    var carreraNueva = new Carrera();
                    carreraNueva.Descripcion = valores[0].ToString();
                    
                    contexto.Carreras.Add(carreraNueva);
                }
            }

            var archivo3 = "../../../secciones.csv";
            using (var reader = new StreamReader(archivo3))
            {
                reader.ReadLine(); // Lee primera fila de encabezados

                while (!reader.EndOfStream)
                {
                    var linea = reader.ReadLine();
                    var valores = linea.Split(',');

                    var seccionNueva = new Seccion();
                    seccionNueva.Descripcion = valores[0].ToString();

                    contexto.Secciones.Add(seccionNueva);
                }
            }

            base.Seed(contexto);
        }
    }
}
