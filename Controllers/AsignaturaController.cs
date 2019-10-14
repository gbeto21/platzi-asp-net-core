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
                UniqueId = Guid.NewGuid().ToString(),
                Nombre = "Programación Orientada a Objetos."
            };

            ViewBag.Fecha = DateTime.Now;
            return View(asignatura);
        }

        public IActionResult MultiAsignatura()
        {

            var asignaturas = new List<Asignatura>(){
                            new Asignatura{Nombre="Matemáticas", UniqueId = Guid.NewGuid().ToString()} ,
                            new Asignatura{Nombre="Educación Física", UniqueId = Guid.NewGuid().ToString()},
                            new Asignatura{Nombre="Castellano", UniqueId = Guid.NewGuid().ToString()},
                            new Asignatura{Nombre="Ciencias Naturales", UniqueId = Guid.NewGuid().ToString()},
                            new Asignatura{Nombre="Programación OO", UniqueId = Guid.NewGuid().ToString()}
                };

            return View(asignaturas);
        }

    }
}