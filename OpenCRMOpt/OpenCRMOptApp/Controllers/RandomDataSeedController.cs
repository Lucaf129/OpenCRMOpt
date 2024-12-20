using Microsoft.AspNetCore.Mvc;

namespace OpenCRMOptApp.Controllers
{
    public class RandomDataSeedController : Controller
    {
        public IActionResult Seed()
        {
            return View();
        }
    }
}
