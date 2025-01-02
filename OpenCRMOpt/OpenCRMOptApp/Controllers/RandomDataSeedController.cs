using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCRMOptModels;

namespace OpenCRMOptApp.Controllers
{
    public class RandomDataSeedController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public RandomDataSeedController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Seed([Bind("NLotti,NMacchine,NModelli,CoefSparsitaMatrice")] RandomDataSeeder randomDataSeeder)
        {
            
            var httpClient = _httpClientFactory.CreateClient();
            JsonContent content = JsonContent.Create(randomDataSeeder);
            var httpResponseMessage = await httpClient.PostAsync("http://localhost:5055/api/RandomDataSeed/Seed", content);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.Message = "Database correttamente popolato.";
            }
            return View("Index");
        }
    }
}
