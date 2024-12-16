using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCRMOptAPI.Ottimizzazione;
using OpenCRMOptModels;

namespace OpenCRMOptAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OttimizzazioneController : Controller
    {
        private readonly OptDbContext _context;

        public OttimizzazioneController(OptDbContext context)
        {
            _context = context;
        }

        // GET: api/OttimizzazioneConEuristica
        [HttpGet("OttimizzazioneConEuristica")]
        public async Task<ActionResult<RisultatoOttimizzazione>> GetOttimizzazioneConEuristica()
        {

            //chiamare un altro controller per ottenere la matrice lotti-Macchine

            try
            {
                var lmController = new LottiMacchineController(_context);

                var matriceLottiMacchine = lmController.GetMatriceLottiMacchine();

                var unwrapped = matriceLottiMacchine as OkObjectResult;

                var value = unwrapped.Value;

                var json = JsonConvert.SerializeObject(value);

                var matriceLM = JsonConvert.DeserializeObject<List<LottiMacchine>>(json);

                var ottimizzatore = new Ottimizzatore(_context);

                var res = await ottimizzatore.OttimizzaConEuristica( matriceLM);

                return Ok(res);

            }
            catch (Exception ex)
            {

                throw new Exception("Impossibile ottenere la matrice lotti-macchine", ex);
            }
        }

        // GET: api/OttimizzazioneConEuristica
        [HttpGet("OttimizzazioneNaive")]
        public async Task<ActionResult<RisultatoOttimizzazione>> GetOttimizzazioneNaive()
        {

            //chiamare un altro controller per ottenere la matrice lotti-Macchine

            try
            {
                var lmController = new LottiMacchineController(_context);

                var matriceLottiMacchine = lmController.GetMatriceLottiMacchine();

                var unwrapped = (OkObjectResult)matriceLottiMacchine;

                var matriceLM = (List<LottiMacchine>)unwrapped.Value!;

                //var json = JsonConvert.SerializeObject(res);

                var ottimizzatore = new Ottimizzatore(_context);

                var res = await ottimizzatore.OttimizzaConEuristica(matriceLM);

                return Ok(res);

            }
            catch (Exception ex)
            {

                throw new Exception("Impossibile ottenere la matrice lotti-macchine", ex);
            }



        }

    }
}
