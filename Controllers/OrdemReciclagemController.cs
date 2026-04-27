using Microsoft.AspNetCore.Mvc;
using GreenDriveApiSeuRa.Data;
using GreenDriveApiSeuRa.Models;

namespace GreenDriveApiSeuRa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdemReciclagemController : ControllerBase
    {
        private readonly GreenDriveContext _context;

        public OrdemReciclagemController(GreenDriveContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(OrdemReciclagem ordem)
        {
            var bateria = _context.Baterias.Find(ordem.BateriaId);
            var estacao = _context.EstacoesCarga.Find(ordem.EstacaoId);

            if (bateria == null || estacao == null)
                return BadRequest("Bateria ou estação inválida.");

            if (bateria.SaudeBateria > 60)
                return BadRequest("Bateria com saúde superior a 60%. Encaminhe para o programa de Reuso Doméstico (Second Life) em vez de reciclagem.");

            if (estacao.TipoCarga == "Ultra-Rapida")
                ordem.CustoProcessamento += 250;

            _context.OrdensReciclagem.Add(ordem);
            _context.SaveChanges();

            return Ok(ordem);
        }
    }
}