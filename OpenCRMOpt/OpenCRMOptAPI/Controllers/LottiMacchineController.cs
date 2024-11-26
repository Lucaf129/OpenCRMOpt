using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenCRMOptModels;

namespace OpenCRMOptAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LottiMacchineController : Controller
    {

        private readonly OptDbContext _context;

        public LottiMacchineController(OptDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMatriceLottiMacchine()
        {
            var result = from lotti in _context.Lottis
                         join modelliLotti in _context.ModelliLottis on lotti.Modello equals modelliLotti.ModelloId into lottiMacchine
                         from lm in lottiMacchine.DefaultIfEmpty()
                         select new LottiMacchine
                         {
                             LottoId = lotti.LottoId,
                             Quantita = lotti.Quantita,
                             Descrizione = lm.Descrizione,
                             MacchineCompatibili = lm.MacchineCompatibili
                         };

            return Ok(result);
        }
    }
}
