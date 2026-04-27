using Microsoft.AspNetCore.Mvc;
using GreenDriveApiSeuRa.Data;
using GreenDriveApiSeuRa.Models;

namespace GreenDriveApiSeuRa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BateriasController : ControllerBase
    {
        private readonly GreenDriveContext _context;

        public BateriasController(GreenDriveContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(Bateria bateria)
        {
            _context.Baterias.Add(bateria);
            _context.SaveChanges();
            return Ok(bateria);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Baterias.ToList());
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] int novaSaude)
        {
            var bateria = _context.Baterias.Find(id);

            if (bateria == null)
                return NotFound();

            if (bateria.SaudeBateria <= 10 && novaSaude > bateria.SaudeBateria)
                return Conflict("Fraude detectada: bateria inativa não pode recuperar saúde.");

            bateria.SaudeBateria = novaSaude;
            _context.SaveChanges();

            return Ok(bateria);
        }
    }
}