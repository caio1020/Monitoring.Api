using Microsoft.AspNetCore.Mvc;
using MonitoringApi.Domain.Interfaces.Services;
using MonitoringApi.Domain.Request;

namespace MonitoringApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensoresController : ControllerBase
    {
        private readonly ISensorService _service;

        public SensoresController(ISensorService sensorDataService)
        {
            _service = sensorDataService;
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
        public async Task<IActionResult> CriarSensor(SensorRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _service.Adicionar(request));
        }
    }
}
