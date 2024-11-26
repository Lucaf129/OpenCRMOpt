using Microsoft.AspNetCore.Mvc;

namespace OpenCRMOptApp.Controllers
{
    public class OttimizzazioneController : Controller
    {

        [HttpPost]
        public IActionResult OttimizzaNaive()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OttimizzaConEuristica()
        {
            return View();
        }
    }
}
