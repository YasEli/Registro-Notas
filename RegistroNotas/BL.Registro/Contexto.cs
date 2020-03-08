using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.Registro.AlumnosBL;

namespace BL.Registro
{
    public class Contexto: DbContext
    {
        public Contexto(): base("Registro")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Alumno> Alumnos { get; set; }
    }
}
