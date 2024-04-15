using MonitoringApi.Domain.Entities;

namespace MonitoringApi.Domain.Interfaces.Services
{
    public interface ISensorRepository
    {
        Task<bool> Inserir(Sensor sensor);
        Task<List<Sensor>> ListarTodos();

    }
}
