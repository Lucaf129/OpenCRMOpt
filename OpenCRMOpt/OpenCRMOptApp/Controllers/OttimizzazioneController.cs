using Microsoft.AspNetCore.Mvc;

namespace OpenCRMOptApp.Controllers
{
    public class OttimizzazioneController : Controller
    {

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
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
