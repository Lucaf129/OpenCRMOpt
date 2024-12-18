using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCRMOptApp.ViewModels;
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

            OttimizzazioneViewModel model = new OttimizzazioneViewModel();

            model.RisultatoConEuristica = new RisultatoOttimizzazione();

            model.RisultatoConEuristica.Initialize(0);

            return View(model);

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

            var httpResponseMessage = await httpClient.PostAsync("http://localhost:5055/api/Ottimizzazione/OttimizzazioneConEuristica", null);

            if (httpResponseMessage.IsSuccessStatusCode)
            {

                var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                StreamReader reader = new StreamReader(contentStream);
                string text = reader.ReadToEnd();

                RisultatoOttimizzazione res = new RisultatoOttimizzazione();

                res = JsonConvert.DeserializeObject<RisultatoOttimizzazione>(text);

                //var lottiList = JsonSerializer.Deserialize<List<Lotti>>(text);

                OttimizzazioneViewModel model = new OttimizzazioneViewModel();

                //res.GetPeso();

                model.RisultatoConEuristica = res;

                return View("Index", model);
            }

            return View("Index");
        }
    }
}
