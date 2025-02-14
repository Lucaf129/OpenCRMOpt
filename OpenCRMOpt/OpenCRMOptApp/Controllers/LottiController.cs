﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCRMOptModels;

namespace OpenCRMOptApp.Controllers
{
    public class LottiController : Controller
    {


        private readonly IHttpClientFactory _httpClientFactory;
        public LottiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var httpClient = _httpClientFactory.CreateClient();

            var httpResponseMessage = await httpClient.GetAsync("http://localhost:5055/api/Lotti");

            if (httpResponseMessage.IsSuccessStatusCode)
            {

                var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                StreamReader reader = new StreamReader(contentStream);
                string text = reader.ReadToEnd();

                var lottiList = JsonConvert.DeserializeObject<List<Lotti>>(text);

                //var lottiList = JsonSerializer.Deserialize<List<Lotti>>(text);
                return View(lottiList);
            }

            return View();

        }
    }
}
