using Microsoft.AspNetCore.Mvc;

namespace project_work_libreria.Controllers {
    public class ClienteController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Dettagli() {
            return View();
        }
    }
}
