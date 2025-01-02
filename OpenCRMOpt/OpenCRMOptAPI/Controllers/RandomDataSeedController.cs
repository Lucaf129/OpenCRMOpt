using Microsoft.AspNetCore.Mvc;
using OpenCRMOptModels;
using OpenCRMOptModels.Extensions;
using System.Linq;

namespace OpenCRMOptAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomDataSeedController : Controller
    {
        private readonly OptDbContext _context;

        public RandomDataSeedController(OptDbContext context)
        {
            _context = context;
        }

        [HttpPost("Seed")]
        public async Task<IActionResult> Seed(RandomDataSeeder randomDataSeeder)
        {
            // Clear existing data
            _context.Lottis.RemoveRange(_context.Lottis);
            _context.Macchines.RemoveRange(_context.Macchines);
            _context.ModelliLottis.RemoveRange(_context.ModelliLottis);
            await _context.SaveChangesAsync();

            var random = new Random();

            // Seed ModelliLotti
            for (var i = 0; i < randomDataSeeder.NModelli; i++)
            {

                string macchineCompatibili = string.Empty;

                for (var j =0; j < randomDataSeeder.NMacchine; j++)
                {
                    macchineCompatibili += $"{float.Round(random.NextNormalFloat(randomDataSeeder.CoefSparsitaMatrice))};";
                }

                var modello = new ModelliLotti
                {
                    ModelloId = i + 1,
                    Descrizione = $"Modello {i + 1}",
                    MacchineCompatibili = macchineCompatibili
                };
                _context.ModelliLottis.Add(modello);
            }

            await _context.SaveChangesAsync();

            // Seed Lotti
            for (var i = 0; i < randomDataSeeder.NLotti; i++)
            {
                var lotto = new Lotti
                {
                    Modello = random.Next(1, randomDataSeeder.NModelli + 1),
                    LottoId = i +1,
                    Quantita = random.Next(1, 1000)
                };
                _context.Lottis.Add(lotto);
            }

            await _context.SaveChangesAsync();

            // Seed Macchine
            for (var i = 0; i < randomDataSeeder.NMacchine; i++)
            {
                var macchina = new Macchine
                {
                    MacchineId = i + 1,
                    Descrizione = $"Macchina {i + 1}",
                    Name = $"Machine_{i + 1}",
                    Ip = $"192.168.1.{i + 1}"
                };
                _context.Macchines.Add(macchina);
            }

            await _context.SaveChangesAsync();

            

            return Ok();
        }
    }
}
