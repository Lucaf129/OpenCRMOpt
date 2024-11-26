using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCRMOptModels;

namespace OpenCRMOptApp.Controllers
{
    public class ModelliLottiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ModelliLottiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var httpClient = _httpClientFactory.CreateClient();

            var httpResponseMessage = await httpClient.GetAsync("http://localhost:5055/api/ModelliLotti");

            if (httpResponseMessage.IsSuccessStatusCode)
            {

                var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                StreamReader reader = new StreamReader(contentStream);
                string text = reader.ReadToEnd();

                var modelliLottiList = JsonConvert.DeserializeObject<List<ModelliLotti>>(text);

                //var lottiList = JsonSerializer.Deserialize<List<Lotti>>(text);
                return View(modelliLottiList);
            }

            return View();

        }
    }
}
