using Microsoft.AspNetCore.Mvc;
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

        // GET: api/Lotti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lotti>>> GetLottis(bool heuristic)
        {

            //chiamare un altro controller per ottenere la matrice lotti-Macchine

            try
            {
                var lmController = new LottiMacchineController(_context);

                var matriceLottiMacchine = lmController.GetMatriceLottiMacchine();

                var unwrapped = (OkObjectResult)matriceLottiMacchine;

                var res = (List<LottiMacchine>)unwrapped.Value;
            }
            catch (Exception ex)
            {

                throw new Exception("Impossibile ottenere la matrice lotti-macchine", ex);
            }

            if (heuristic)
            {

            }
            else
            {

            }
            return Ok();
        }
    }
}
