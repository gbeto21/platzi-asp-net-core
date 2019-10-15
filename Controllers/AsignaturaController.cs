using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core.Controllers
{
    public class AsignaturaController : Controller
    {

        public IActionResult Index()
        {
            var asignatura = new Asignatura()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = "Programación Orientada a Objetos."
            };

            ViewBag.Fecha = DateTime.Now;
            return View(asignatura);
        }

        public IActionResult MultiAsignatura()
        {

            var asignaturas = new List<Asignatura>(){
                            new Asignatura{Nombre="Matemáticas", Id = Guid.NewGuid().ToString()} ,
                            new Asignatura{Nombre="Educación Física", Id = Guid.NewGuid().ToString()},
                            new Asignatura{Nombre="Castellano", Id = Guid.NewGuid().ToString()},
                            new Asignatura{Nombre="Ciencias Naturales", Id = Guid.NewGuid().ToString()},
                            new Asignatura{Nombre="Programación OO", Id = Guid.NewGuid().ToString()}
                };

            return View(asignaturas);
        }

    }
}