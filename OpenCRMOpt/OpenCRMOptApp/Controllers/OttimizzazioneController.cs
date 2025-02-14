﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCRMOptApp.ViewModels;
using OpenCRMOptModels;

namespace OpenCRMOptApp.Controllers
{
    public class OttimizzazioneController : Controller
    {

        OttimizzazioneViewModel _model = new OttimizzazioneViewModel();

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

            model.RisultatoNaive = new RisultatoOttimizzazione();

            model.RisultatoNaive.Initialize(0);

            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> Ottimizza()
        {
            var httpClient = _httpClientFactory.CreateClient();

            // questo httpclient potrà aspettare più a lungo degli altri
            httpClient.Timeout = TimeSpan.FromMinutes(10);

            var httpResponseMessage = await httpClient.PostAsync("http://localhost:5055/api/Ottimizzazione/OttimizzazioneConEuristica", null);

            if (httpResponseMessage.IsSuccessStatusCode)
            {

                var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                StreamReader reader = new StreamReader(contentStream);
                string text = reader.ReadToEnd();

                RisultatoOttimizzazione res = new RisultatoOttimizzazione();

                res = JsonConvert.DeserializeObject<RisultatoOttimizzazione>(text);

                //var lottiList = JsonSerializer.Deserialize<List<Lotti>>(text);

                //res.GetPeso();

                _model.RisultatoConEuristica = res;

                httpResponseMessage = await httpClient.PostAsync("http://localhost:5055/api/Ottimizzazione/OttimizzazioneNaive", null);

                if (httpResponseMessage.IsSuccessStatusCode)
                {

                    contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                    reader = new StreamReader(contentStream);
                    text = reader.ReadToEnd();

                    res = new RisultatoOttimizzazione();

                    res = JsonConvert.DeserializeObject<RisultatoOttimizzazione>(text);

                    //var lottiList = JsonSerializer.Deserialize<List<Lotti>>(text);

                    //res.GetPeso();

                    _model.RisultatoNaive = res;

                    return View("Index", _model);
                }
                return View("Index");
            }

            return View("Index");
        }

       
    }
}
