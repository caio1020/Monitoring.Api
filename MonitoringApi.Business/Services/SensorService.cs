using MonitoringApi.Domain.DTOs;
using MonitoringApi.Domain.Entities;
using MonitoringApi.Domain.Interfaces.Services;
using MonitoringApi.Domain.Request;

namespace MonitoringApi.Business.Services
{
    public class SensorService : ISensorService
    {
        private readonly ISensorRepository _repository;

        public SensorService(ISensorRepository sensorDataRepository)
        {
            _repository = sensorDataRepository;
        }
        public async Task<bool> Adicionar(SensorRequest request)
        {
            Sensor sensor = new Sensor()
            {
                Id = request.Id,
                Codigo = request.Codigo
            };

            return await _repository.Inserir(sensor);
        }

        public async Task<List<SensorDTO>> ListarTodos()
        {
            List<Sensor> sensor = await _repository.ListarTodos();

            var response = MapearListaSensor(sensor);

            return response;
        }

        private List<SensorDTO> MapearListaSensor(List<Sensor> sensores)
        {
            var response = new List<SensorDTO>();

            foreach (var lst in sensores)
            {
                var sensor = new SensorDTO
                {
                    Id = lst.Id,
                    SetorEquipamentoId = lst.SetorEquipamentoId,
                    Codigo = lst.Codigo
                };

                response.Add(sensor);
            }

            return response;
        }
    }
}
