using MonitoringApi.Domain.DTOs;
using MonitoringApi.Domain.Request;

namespace MonitoringApi.Domain.Interfaces.Services
{
    public interface ISetorEquipamentoService
    {
        Task<bool> Adicionar(SetorEquipamentoRequest request);

        Task<bool> Vincular(SetorEquipamentoVincularSensorRequest request);

        Task<List<SetorEquipamentoDTO>> ListarTodos();


    }
}
