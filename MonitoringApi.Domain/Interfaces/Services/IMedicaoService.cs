using MonitoringApi.Domain.DTOs;
using MonitoringApi.Domain.Request;

namespace MonitoringApi.Domain.Interfaces.Services
{
    public interface IMedicaoService
    {
        Task<bool> Adicionar(MedicaoRequest request);
        Task<List<UltimasMedicoesDTO>> ListarUltimasMedicoes(int sertoEquipamentoId);


    }
}
