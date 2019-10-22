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

        #region Index (Details)

        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{id}")]
        public IActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Content("No encontramos la asignatura solicitada.");

            else
                return View(GetAsignatura(id));
        }

        #endregion

        #region MultiAsignatura

        public IActionResult MultiAsignatura()
        {
            return View("Multiasignatura", mescContexto.Asignaturas);
        }

        #endregion

        #region Crear

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Asignatura pAsignatura)
        {
            if (ModelState.IsValid)
                return SaveAsignatura(3, pAsignatura, Guid.NewGuid().ToString());
            else
                return View(pAsignatura);
        }

        #endregion

        #region Editar
        [Route("Asignatura/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Content("Los datos proporcionados no son suficientes.");
            else
                return GetViewAsignatura("Edit", GetAsignatura(id));
        }

        [HttpPost]
        [Route("Asignatura/Edit/{pAsignaturaId}")]
        public IActionResult Edit(Asignatura pAsignatura, string pAsignaturaId)
        {
            if (ModelState.IsValid)
                return SaveAsignatura(1, pAsignatura, pAsignaturaId);
            else
                return View(pAsignatura);
        }

        #endregion

        #region Eliminar
        [Route("Asignatura/Delete/{id}")]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Content("Los datos proporcionados no son suficientes.");
            else
                return GetViewAsignatura("Delete", GetAsignatura(id));
        }

        [HttpPost]
        [Route("Asignatura/Delete/{pAsignaturaId}")]
        public IActionResult Delete(Asignatura pAsignatura, string pAsignaturaId)
        {
            if (ModelState.IsValid)
                return SaveAsignatura(2, pAsignatura, pAsignaturaId);
            else
                return MultiAsignatura();
        }

        #endregion

        #endregion

        #region Métodos privados

        private IActionResult GetViewAsignatura(string pAccion, Asignatura pAsignatura)
        {
            bool asignaturaEsNull = AsignaturaIsNull(pAsignatura);
            if (asignaturaEsNull)
                return Content("Asignatura no encontrada.");
            else
                return View(pAccion, pAsignatura);
        }

        private bool AsignaturaIsNull(Asignatura pAsignatura)
        {
            return pAsignatura == null;
        }

        private Asignatura GetAsignatura(string pAsignaturaId)
        {
            var asignaturasResults = from asignatura in mescContexto.Asignaturas
                                     where asignatura.Id == pAsignaturaId
                                     select asignatura;
            var asignaturaS = asignaturasResults.SingleOrDefault();
            string a = asignaturaS.ToString();
            return asignaturasResults.SingleOrDefault();
        }

        private IActionResult SaveAsignatura(short pTypeManage, Asignatura pAsignatura, string pAsignaturaId)
        {
            pAsignatura.Id = pAsignaturaId;
            ManageAsignaturaDataBase(pTypeManage, pAsignatura);
            mescContexto.SaveChanges();
            return MultiAsignatura();
        }

        private void ManageAsignaturaDataBase(short pTypeManage, Asignatura pAsignatura)
        {
            switch (pTypeManage)
            {
                case 1:
                    mescContexto.Asignaturas.Update(pAsignatura);
                    break;
                case 2:
                    mescContexto.Asignaturas.Remove(pAsignatura);
                    break;
                case 3:
                    //pAsignatura.EscuelaId = mescContexto.Escuelas.FirstOrDefault().Id;
                    mescContexto.Asignaturas.Add(pAsignatura);
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}