using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;
using System;
using System.Linq;

namespace platzi_asp_net_core.Controllers
{
    public class AsignaturaController : Controller
    {

        #region Variables
        private EscuelaContext mescContexto;

        #endregion

        #region Constructores
        public AsignaturaController(EscuelaContext pContext)
        {
            this.mescContexto = pContext;
        }

        #endregion

        #region Métodos públicos

        public IActionResult Index()
        {
            var asignatura = mescContexto.Asignaturas.FirstOrDefault();

            ViewBag.Fecha = DateTime.Now;
            return View(asignatura);
        }

        public IActionResult MultiAsignatura()
        {
            return View(mescContexto.Asignaturas);
        }
        #endregion

    }
}