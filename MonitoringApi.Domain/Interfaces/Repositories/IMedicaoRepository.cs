using MonitoringApi.Domain.DTOs;
using MonitoringApi.Domain.Entities;

namespace MonitoringApi.Domain.Interfaces.Services
{
    public interface IMedicaoRepository
    {
        Task<bool> Inserir(Medicao request);
        Task<List<UltimasMedicoesDTO>> ListarUltimasMedicoes(int idSetorEquipamento);

    }
}
