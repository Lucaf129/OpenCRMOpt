using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCRMOptModels;

namespace OpenCRMOptApp.Controllers
{
    public class LottiMacchineController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LottiMacchineController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var httpClient = _httpClientFactory.CreateClient();

            var httpResponseMessage = await httpClient.GetAsync("http://localhost:5055/api/LottiMacchine");

            if (httpResponseMessage.IsSuccessStatusCode)
            {

                var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                StreamReader reader = new StreamReader(contentStream);
                string text = reader.ReadToEnd();

                var macchineList = JsonConvert.DeserializeObject<List<LottiMacchine>>(text);

                //var lottiList = JsonSerializer.Deserialize<List<Lotti>>(text);
                return View(macchineList);
            }

            return View();

        }
    }
}
