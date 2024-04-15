using Microsoft.EntityFrameworkCore;
using MonitoringApi.Domain.DTOs;
using MonitoringApi.Domain.Entities;
using MonitoringApi.Domain.Interfaces.Services;
using MonitoringApi.Infra.Data;

namespace MonitoringApi.Infra.Repositories
{
    public class MedicaoRepository : IMedicaoRepository
    {
        private readonly MonitoramentoDbContex _monitoramentoDbContex;

        public MedicaoRepository(MonitoramentoDbContex monitoramentoDbContex)
        {
            _monitoramentoDbContex = monitoramentoDbContex;
        }

        public async Task<bool> Inserir(Medicao request)
        {
            var sensor = await _monitoramentoDbContex.Sensores.FirstOrDefaultAsync(s => s.Id == request.SensorId);

            if (sensor != null)
            {
                request.SensorId = sensor.Id; // Vincula o sensor à medição
                await _monitoramentoDbContex.Medicao.AddAsync(request);
                await _monitoramentoDbContex.SaveChangesAsync();
                return true; // Medições inseridas com sucesso
            }

            return false; // Sensor não encontrado
        }

        public async Task<List<UltimasMedicoesDTO>> ListarUltimasMedicoes(int idSetorEquipamento)
        {
            var query = from se in _monitoramentoDbContex.SetorEquipamentos
                        join s in _monitoramentoDbContex.Sensores on se.Id equals s.SetorEquipamentoId
                        join m in _monitoramentoDbContex.Medicao on s.Id equals m.SensorId
                        where se.Id == idSetorEquipamento
                        orderby m.DataHora descending
                        select new UltimasMedicoesDTO
                        {
                            IdSetorEquipamento = se.Id,
                            SetorEquipamento = se.Nome,
                            CodigoSensor = s.Codigo,
                            ValorMedicao = m.Valor
                        };

            return await query.Take(10).ToListAsync();
        }
    }
}
