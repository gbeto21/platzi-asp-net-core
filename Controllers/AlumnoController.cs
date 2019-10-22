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

        #region Index (Details)

        [Route("Alumno/Index")]
        [Route("Alumno/Index/{id}")]
        public IActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Content("No encontramos el alumno solicitado.");

            else
                return View(GetAlumno(id));
        }

        #endregion

        #region Multialumno

        public IActionResult MultiAlumno()
        {
            return View("Multialumno", mescContexto.Alumnos);
        }

        #endregion

        #region Crear

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Alumno pAlumno)
        {
            if (ModelState.IsValid)
                return SaveAlumno(3, pAlumno, Guid.NewGuid().ToString());
            else
                return View(pAlumno);
        }

        #endregion

        #region Editar
        [Route("Alumno/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Content("Los datos proporcionados no son suficientes.");

            else
                return GetViewAlumno("Edit", GetAlumno(id));
        }

        [HttpPost]
        [Route("Alumno/Edit/{pAlumnoId}")]
        public IActionResult Edit(Alumno pAlumno, string pAlumnoId)
        {
            if (ModelState.IsValid)
                return SaveAlumno(1, pAlumno, pAlumnoId);

            else
                return View(pAlumno);
        }

        #endregion

        #region Eliminar
        [Route("Alumno/Delete/{id}")]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Content("Los datos proporcionados no son suficientes.");
            else
                return GetViewAlumno("Delete", GetAlumno(id));
        }

        [HttpPost]
        [Route("Alumno/Delete/{pAlumnoId}")]
        public IActionResult Delete(Alumno pAlumno, string pAlumnoId)
        {
            if (ModelState.IsValid)
                return SaveAlumno(2, pAlumno, pAlumnoId);
            else
                return MultiAlumno();
        }

        #endregion

        #endregion

        #region Métodos privados

        private IActionResult GetViewAlumno(string pAccion, Alumno pAlumno)
        {
            bool alumnoIsNull = AlumnoIsNull(pAlumno);
            if (alumnoIsNull)
                return Content("Alumno no encontrado.");

            else
                return View(pAccion, pAlumno);
        }

        private bool AlumnoIsNull(Alumno pAlumno)
        {
            return pAlumno == null;
        }

        private IActionResult SaveAlumno(short pTypeManage, Alumno pAlumno, string pAlumnoId)
        {
            pAlumno.Id = pAlumnoId;
            ManageAlumnoDataBase(pTypeManage, pAlumno);
            mescContexto.SaveChanges();
            return MultiAlumno();
        }

        private void ManageAlumnoDataBase(short pTypeManage, Alumno pAlumno)
        {
            switch (pTypeManage)
            {
                case 1:
                    mescContexto.Alumnos.Update(pAlumno);
                    break;
                case 2:
                    mescContexto.Alumnos.Remove(pAlumno);
                    break;
                case 3:
                    mescContexto.Alumnos.Add(pAlumno);
                    break;
                default:
                    break;
            }
        }

        private Alumno GetAlumno(string pAlumnoId)
        {

            var alumnosResults = from alumno in mescContexto.Alumnos
                                 where alumno.Id == pAlumnoId
                                 select alumno;

            return alumnosResults.SingleOrDefault();
        }
        #endregion
    }
}