using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;
using System;
using System.Linq;

namespace platzi_asp_net_core.Controllers
{
    public class CursoController : Controller
    {

        #region Variables
        private EscuelaContext mescContexto;

        #endregion

        #region Constructores
        public CursoController(EscuelaContext pContext)
        {
            this.mescContexto = pContext;
        }

        #endregion

        #region Métodos públicos
        [Route("Curso/Index")]
        [Route("Curso/Index/{pCursoId}")]
        public IActionResult Index(string pCursoId)
        {
            if (string.IsNullOrEmpty(pCursoId))
                return Content("No encontramos el Curso solicitado.");

            else
            {
                var curso = from curs in mescContexto.Cursos
                             where curs.Id == pCursoId
                             select curs;

                return View(curso.SingleOrDefault());
            }
        }

        public IActionResult MultiCurso()
        {
            return View(mescContexto.Cursos);
        }

        //public IActionResult Index()
        //{
        //    ViewBag.Fecha = DateTime.Now;
        //    return View(mescContexto.Cursos.FirstOrDefault());
        //}
        #endregion

    }
}