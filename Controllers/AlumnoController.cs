using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;
using System;
using System.Linq;

namespace platzi_asp_net_core.Controllers
{
    public class AlumnoController : Controller
    {

        #region Variables
        private EscuelaContext mescContexto;

        #endregion

        #region Constructores
        public AlumnoController(EscuelaContext pContext)
        {
            this.mescContexto = pContext;
        }

        #endregion

        #region Métodos públicos

        public IActionResult Index()
        {
            ViewBag.Fecha = DateTime.Now;
            return View(mescContexto.Alumnos.FirstOrDefault());
        }

        public IActionResult MultiAlumno()
        {
            return View(mescContexto.Alumnos);
        }

        #endregion

    }
}