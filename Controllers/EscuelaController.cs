using Microsoft.AspNetCore.Mvc;

namespace platzi_asp_net_core.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}