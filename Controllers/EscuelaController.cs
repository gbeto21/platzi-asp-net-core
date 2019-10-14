using System;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;
using System.Linq;

namespace platzi_asp_net_core.Controllers
{
    public class EscuelaController : Controller
    {

        #region Variables
        private EscuelaContext mescContexto;


        #endregion

        #region Constructores
        public EscuelaController(EscuelaContext pContext)
        {
            this.mescContexto = pContext;
        }

        #endregion

        #region Métodos públicos
        public IActionResult Index()
        {
            var escuela = mescContexto.Escuelas.FirstOrDefault();
            return View(escuela);
        }

        #endregion


    }
}

/*

            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.UniqueId = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi Scool";
            escuela.Ciudad = "Bogotá";
            escuela.Pais = "Colombia";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            escuela.Dirección = "Av. Calle Uno";
            ViewBag.CosaDinamica = "La monja.";

 */