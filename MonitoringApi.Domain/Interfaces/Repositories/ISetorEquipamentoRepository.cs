using MonitoringApi.Domain.Entities;

namespace MonitoringApi.Domain.Interfaces.Services
{
    public interface ISetorEquipamentoRepository
    {
        Task<bool> Inserir(SetorEquipamento setorEquipamento);

        Task<bool> Vincular(Sensor sensor);

        Task<List<SetorEquipamento>> ListarTodos();

    }
}
