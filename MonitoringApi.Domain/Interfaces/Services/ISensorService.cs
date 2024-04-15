using MonitoringApi.Domain.DTOs;
using MonitoringApi.Domain.Request;

namespace MonitoringApi.Domain.Interfaces.Services
{
    public interface ISensorService
    {
        Task<List<SensorDTO>> ListarTodos();

        Task<bool> Adicionar(SensorRequest request);

    }
}
