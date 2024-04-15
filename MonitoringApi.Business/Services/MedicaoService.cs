using MonitoringApi.Domain.DTOs;
using MonitoringApi.Domain.Entities;
using MonitoringApi.Domain.Interfaces.Services;
using MonitoringApi.Domain.Request;

namespace MonitoringApi.Business.Services
{
    public class MedicaoService : IMedicaoService
    {
        private readonly IMedicaoRepository _repository;

        public MedicaoService(IMedicaoRepository medicaoRepository)
        {
            _repository = medicaoRepository;
        }

        public async Task<bool> Adicionar(MedicaoRequest request)
        {
            Medicao medicao = new Medicao()
            {
                SensorId = request.SensorId,
                Valor = request.Valor,
                DataHora = request.DataHora
            };

            return await _repository.Inserir(medicao);
        }

        public async Task<List<UltimasMedicoesDTO>> ListarUltimasMedicoes(int idSetorEquipamento)
        {
            return await _repository.ListarUltimasMedicoes(idSetorEquipamento);
        }
    }
}
