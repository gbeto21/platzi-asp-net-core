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

        #region Index (Details)

        [Route("Curso/Index")]
        [Route("Curso/Index/{id}")]
        public IActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Content("No encontramos el Curso solicitado.");

            else
                return View(GetCourse(id));
        }

        #endregion

        #region Multicurso

        public IActionResult MultiCurso()
        {
            return View("Multicurso", mescContexto.Cursos);
        }

        #endregion

        #region Crear

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Curso pCurso)
        {
            if (ModelState.IsValid)
                return SaveCourse(3, pCurso, Guid.NewGuid().ToString());
            else
                return View(pCurso);
        }

        #endregion

        #region Editar
        [Route("Curso/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Content("Los datos proporcionados no son suficientes.");

            else
                return GetViewCurso("Edit", GetCourse(id));
        }

        //[HttpPut("{id}")]
        [HttpPost]
        [Route("Curso/Edit/{pCursoId}")]
        public IActionResult Edit(Curso pCurso, string pCursoId)
        {
            if (ModelState.IsValid)
                return SaveCourse(1, pCurso, pCursoId);

            else
                return View(pCurso);
        }

        #endregion

        #region Eliminar

        [Route("Curso/Delete/{id}")]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Content("Los datos proporcionados no son suficientes.");

            else
                return GetViewCurso("Delete", GetCourse(id));
        }

        [HttpPost]
        [Route("Curso/Delete/{pCursoId}")]
        public IActionResult Delete(Curso pCurso, string pCursoId)
        {
            if (ModelState.IsValid)
                return SaveCourse(2, pCurso, pCursoId);

            else
                return MultiCurso();
        }

        #endregion

        #endregion

        #region Métodos privados

        private IActionResult GetViewCurso(string pAccion, Curso pCurso)
        {
            bool cursoEsNull = CursoIsNull(pCurso);
            if (cursoEsNull)
                return Content("Curso no encontrado.");

            else
                return View(pAccion, pCurso);
        }

        private bool CursoIsNull(Curso pCurso)
        {
            return pCurso == null;
        }

        private Curso GetCourse(string pCursoId)
        {
            var cursosResults = from curso in mescContexto.Cursos
                                where curso.Id == pCursoId
                                select curso;

            return cursosResults.SingleOrDefault();
        }

        private IActionResult SaveCourse(short pTipoManage, Curso pCurso, string pCursoId)
        {
            pCurso.Id = pCursoId;
            ManageCourseDataBase(pTipoManage, pCurso);
            mescContexto.SaveChanges();
            return MultiCurso();
        }

        private void ManageCourseDataBase(short pTipoManage, Curso pCurso)
        {
            switch (pTipoManage)
            {
                case 1:
                    mescContexto.Cursos.Update(pCurso);
                    break;
                case 2:
                    mescContexto.Cursos.Remove(pCurso);
                    break;
                case 3:
                    pCurso.EscuelaId = mescContexto.Escuelas.FirstOrDefault().Id;
                    mescContexto.Cursos.Add(pCurso);
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}