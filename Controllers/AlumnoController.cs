using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core.Controllers
{
    public class AlumnoController : Controller
    {

        public IActionResult Index()
        {
            var alumno = new Alumno()
            {
                UniqueId = Guid.NewGuid().ToString(),
                Nombre = "Mario Franco Morales."
            };

            ViewBag.Fecha = DateTime.Now;
            return View(alumno);
        }

        public IActionResult MultiAlumno()
        {

            var alumnos = CrearAlumnos();

            return View(alumnos);
        }

        private List<Alumno> CrearAlumnos()
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
                                   UniqueId = Guid.NewGuid().ToString()
                               };

            return listaAlumnos.OrderBy((al) => al.UniqueId).ToList();
        }

    }
}