using Microsoft.AspNetCore.Mvc;
using GreenDriveApiSeuRa.Data;
using GreenDriveApiSeuRa.Models;

namespace GreenDriveApiSeuRa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstacoesCargaController : ControllerBase
    {
        private readonly GreenDriveContext _context;

        public EstacoesCargaController(GreenDriveContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(EstacaoCarga estacao)
        {
            _context.EstacoesCarga.Add(estacao);
            _context.SaveChanges();
            return Ok(estacao);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.EstacoesCarga.ToList());
        }
    }
}