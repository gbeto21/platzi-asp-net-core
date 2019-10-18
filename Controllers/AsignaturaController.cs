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

        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{pAsignaturaId}")]
        public IActionResult Index(string pAsignaturaId)
        {
            if (string.IsNullOrEmpty(pAsignaturaId))
                return Content("No encontramos la asignatura solicitada.");

            else
            {
                var asignatura = from asig in mescContexto.Asignaturas
                                 where asig.Id == pAsignaturaId
                                 select asig;

                return View(asignatura.SingleOrDefault());
            }
        }

        public IActionResult MultiAsignatura()
        {
            return View(mescContexto.Asignaturas);
        }
        #endregion

    }
}