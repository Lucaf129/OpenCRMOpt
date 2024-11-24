using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCRMOptModels;

namespace OpenCRMOptApp.Controllers
{
    public class MacchineController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MacchineController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var httpClient = _httpClientFactory.CreateClient();

            var httpResponseMessage = await httpClient.GetAsync("http://localhost:5055/api/Macchine");

            if (httpResponseMessage.IsSuccessStatusCode)
            {

                var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                StreamReader reader = new StreamReader(contentStream);
                string text = reader.ReadToEnd();

                var macchineList = JsonConvert.DeserializeObject<List<Macchine>>(text);

                //var lottiList = JsonSerializer.Deserialize<List<Lotti>>(text);
                return View(macchineList);
            }

            return View();

        }
    }
}
