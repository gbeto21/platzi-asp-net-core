using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace platzi_asp_net_core.Models
{
    public class EscuelaContext : DbContext
    {
        #region Propiedades
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluación> Evaluaciones { get; set; }

        #endregion

        #region Constructores
        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }

        #endregion

        #region Sobreescritura de métodos

        protected override void OnModelCreating(ModelBuilder pModelBuilder)
        {
            base.OnModelCreating(pModelBuilder);
            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi Scool";
            escuela.Ciudad = "Bogotá";
            escuela.Pais = "Colombia";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            escuela.Dirección = "Av. Calle Uno";

            pModelBuilder.Entity<Escuela>().HasData(escuela);

            pModelBuilder.Entity<Asignatura>().HasData(

                            new Asignatura { Nombre = "Matemáticas", Id = Guid.NewGuid().ToString() },
                            new Asignatura { Nombre = "Educación Física", Id = Guid.NewGuid().ToString() },
                            new Asignatura { Nombre = "Castellano", Id = Guid.NewGuid().ToString() },
                            new Asignatura { Nombre = "Ciencias Naturales", Id = Guid.NewGuid().ToString() },
                            new Asignatura { Nombre = "Programación OO", Id = Guid.NewGuid().ToString() }

            );

            pModelBuilder.Entity<Alumno>().HasData(CrearAlumnos());
        }

        #endregion

        #region Métodos privados

        private IEnumerable<Alumno> CrearAlumnos()
        {
            string[] nombre1 = { "José", "Josué", "Javier", "Jimena", "Jesús", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno
                               {
                                   Nombre = $"{n1} {n2} {a1}",
                                   Id = Guid.NewGuid().ToString()
                               };

            return listaAlumnos.OrderBy((al) => al.Id).ToList();
        }

        #endregion

    }
}