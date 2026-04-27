using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenDriveApiSeuRa.Data;

namespace GreenDriveApiSeuRa.Controllers
{
    [ApiController]
    [Route("api/intelligence")]
    public class GridIntelligenceController : ControllerBase
    {
        private readonly GreenDriveContext _context;

        public GridIntelligenceController(GreenDriveContext context)
        {
            _context = context;
        }

        [HttpGet("carbon-footprint")]
        public async Task<IActionResult> GetCarbonFootprint()
        {
            await Task.Delay(3000);

            var resultado = await _context.OrdensReciclagem
                .Include(o => o.EstacaoCarga)
                .GroupBy(o => o.EstacaoCarga.Localizacao)
                .Select(g => new
                {
                    Cidade = g.Key,
                    TotalCusto = g.Sum(x => x.CustoProcessamento)
                })
                .ToListAsync();

            return Ok(resultado);
        }
    }
}