using Microsoft.AspNetCore.Mvc;
using GreenDriveApiSeuRa.Data;
using GreenDriveApiSeuRa.Models;

namespace GreenDriveApiSeuRa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroTelemetriaController : ControllerBase
    {
        private readonly GreenDriveContext _context;

        public RegistroTelemetriaController(GreenDriveContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(RegistroTelemetria registro)
        {
            var bateria = _context.Baterias.Find(registro.BateriaId);

            if (bateria == null)
                return BadRequest("Bateria não encontrada.");

            if (registro.Temperatura > 85)
            {
                Console.WriteLine($"ALERTA DE SEGURANÇA: Risco térmico detectado na bateria {bateria.NumeroSerie}! Registro bloqueado para investigação.");
                return BadRequest("Temperatura acima do limite de segurança.");
            }

            _context.RegistrosTelemetria.Add(registro);
            _context.SaveChanges();

            return Ok(registro);
        }
    }
}