using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;
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
        [Route("Alumno/Index")]
        [Route("Alumno/Index/{pAlumnoId}")]
        public IActionResult Index(string pAlumnoId)
        {
            if (string.IsNullOrEmpty(pAlumnoId))
                return Content("No encontramos el alumno solicitado.");

            else
            {
                var alumno = from alum in mescContexto.Alumnos
                             where alum.Id == pAlumnoId
                             select alum;

                return View(alumno.SingleOrDefault());
            }
        }

        public IActionResult MultiAlumno()
        {
            return View(mescContexto.Alumnos);
        }

        //public IActionResult Index()
        //{
        //    ViewBag.Fecha = DateTime.Now;
        //    return View(mescContexto.Alumnos.FirstOrDefault());
        //}
        #endregion

    }
}