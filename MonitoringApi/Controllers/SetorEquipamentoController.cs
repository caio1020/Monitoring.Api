using Microsoft.AspNetCore.Mvc;
using MonitoringApi.Domain.Interfaces.Services;
using MonitoringApi.Domain.Request;

namespace MonitoringApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorEquipamentoController : ControllerBase
    {
        private readonly ISetorEquipamentoService _service;

        public SetorEquipamentoController(ISetorEquipamentoService setorEquipamentoService)
        {
            _service = setorEquipamentoService;
        }

        [HttpGet("listartodos")]
        public async Task<IActionResult> ListarTodos()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _service.ListarTodos());
        }

        [HttpPost]
        public async Task<IActionResult> CriarSetorEquipamento(SetorEquipamentoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _service.Adicionar(request));
        }

        [HttpPost("vincularsensor")]
        public async Task<IActionResult> SetorEquipamentoVincularSensor(SetorEquipamentoVincularSensorRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _service.Vincular(request));
        }
    }
}
