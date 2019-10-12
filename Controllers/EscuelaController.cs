using System;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            var escuela = new Escuela();
            escuela.Year = 2005;
            escuela.EscuelaId = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi Scool";

            ViewBag.CosaDinamica ="La monja.";
            
            return View(escuela);
        }

    }
}