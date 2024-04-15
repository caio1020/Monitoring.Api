using Microsoft.AspNetCore.Mvc;
using MonitoringApi.Domain.Interfaces.Services;
using MonitoringApi.Domain.Request;

namespace MonitoringApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicaoController : ControllerBase
    {
        private readonly IMedicaoService _service;

        public MedicaoController(IMedicaoService medicaoService)
        {
            _service = medicaoService;
        }

        [HttpGet("ultimas-medicoes/{idSetorEquipamento}")]
        public async Task<IActionResult> ListarUltimasMedicoes(int idSetorEquipamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _service.ListarUltimasMedicoes(idSetorEquipamento));
        }

        [HttpPost]
        public async Task<IActionResult> InserirMedicao(MedicaoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sucesso = await _service.Adicionar(request);

            if (sucesso)
            {
                return Ok("Medição inserida com sucesso!");
            }
            else
            {
                return NotFound("Sensor não encontrado.");
            }
        }

    }
}
