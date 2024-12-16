using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCRMOptModels;

namespace OpenCRMOptApp.Controllers
{
    public class OttimizzazioneController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public OttimizzazioneController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OttimizzaNaive()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> OttimizzaConEuristica()
        {
            var httpClient = _httpClientFactory.CreateClient();

            var httpResponseMessage = await httpClient.GetAsync("http://localhost:5055/api/Ottimizzazione/OttimizzazioneConEuristica");

            if (httpResponseMessage.IsSuccessStatusCode)
            {

                var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                StreamReader reader = new StreamReader(contentStream);
                string text = reader.ReadToEnd();

                var modelliLottiList = JsonConvert.DeserializeObject<RisultatoOttimizzazione>(text);

                //var lottiList = JsonSerializer.Deserialize<List<Lotti>>(text);
                return View(modelliLottiList);
            }

            return View();
        }
    }
}
