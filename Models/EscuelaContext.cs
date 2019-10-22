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

            var escuela = CrearEscuela();
            var cursos = CrearCursos(escuela.Id);
            var asignaturas = CrearAsignaturas(cursos);
            var alumnos = CrearAlumnos(cursos);

            pModelBuilder.Entity<Escuela>().HasData(escuela);
            pModelBuilder.Entity<Curso>().HasData(cursos);
            pModelBuilder.Entity<Asignatura>().HasData(asignaturas);
            pModelBuilder.Entity<Alumno>().HasData(alumnos);
            //Tarea: Cargar evaluaciones.

        }

        #endregion

        #region Métodos privados

        private Escuela CrearEscuela()
        {
            return new Escuela()
            {
                AñoDeCreación = 2005,
                Id = Guid.NewGuid().ToString(),
                Nombre = "Platzi School",
                Ciudad = "Bogotá",
                Pais = "Colombia",
                TipoEscuela = TiposEscuela.Secundaria,
                Dirección = "Av. Calle Uno",
            };
        }

        private IEnumerable<Alumno> CrearAlumnos(IEnumerable<Curso> pCursos)
        {
            var alumnos = new List<Alumno>();
            Random random = new Random();

            foreach (var curso in pCursos)
            {
                int cantidadAlumnos = random.Next(5, 20);
                alumnos.AddRange(CrearAlumnos(curso.Id, cantidadAlumnos));
            }

            return alumnos;
        }

        private IEnumerable<Asignatura> CrearAsignaturas(IEnumerable<Curso> pCursos)
        {
            var asignaturas = new List<Asignatura>();
            foreach (var curso in pCursos)
                asignaturas.AddRange(CrearAsignaturas(curso.Id));

            return asignaturas;
        }

        private List<Asignatura> CrearAsignaturas(string pCursoId)
        {
            return new List<Asignatura>() {
                            new Asignatura {CursoId = pCursoId, Nombre = "Matemáticas", Id = Guid.NewGuid().ToString() },
                            new Asignatura {CursoId = pCursoId, Nombre = "Educación Física", Id = Guid.NewGuid().ToString() },
                            new Asignatura {CursoId = pCursoId, Nombre = "Castellano", Id = Guid.NewGuid().ToString() },
                            new Asignatura {CursoId = pCursoId, Nombre = "Ciencias Naturales", Id = Guid.NewGuid().ToString() },
                            new Asignatura {CursoId = pCursoId, Nombre = "Programación OO", Id = Guid.NewGuid().ToString()}
            };
        }

        private IEnumerable<Alumno> CrearAlumnos(string pCursoId, int pCantidadAlumnos)
        {
            string[] nombre1 = { "José", "Josué", "Javier", "Jimena", "Jesús", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno
                               {
                                   CursoId = pCursoId,
                                   Nombre = $"{n1} {n2} {a1}",
                                   Id = Guid.NewGuid().ToString()
                               };

            return listaAlumnos.OrderBy((al) => al.Id).Take(pCantidadAlumnos).ToList();
        }

        private IEnumerable<Curso> CrearCursos(string pEscuelaId)
        {
            return new List<Curso>() {
                CrearCurso(pEscuelaId,"101",TiposJornada.Mañana, "Av. Jitomates"),
                CrearCurso(pEscuelaId,"201",TiposJornada.Mañana, "Av. Jitomates"),
                CrearCurso(pEscuelaId,"301",TiposJornada.Mañana, "Av. Jitomates"),
                CrearCurso(pEscuelaId,"401",TiposJornada.Tarde, "Av. Jitomates"),
                CrearCurso(pEscuelaId,"501",TiposJornada.Tarde, "Av. Jitomates")
            };
        }

        private Curso CrearCurso(string pEscuelaId, string pNombre, TiposJornada pTipoJornada, string pDireccion = null)
        {
            return new Curso()
            {
                Id = Guid.NewGuid().ToString(),
                EscuelaId = pEscuelaId,
                Nombre = pNombre,
                Jornada = pTipoJornada,
                Dirección = pDireccion
            };
        }

        #endregion

    }
}