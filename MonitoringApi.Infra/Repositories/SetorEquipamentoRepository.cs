using Microsoft.EntityFrameworkCore;
using MonitoringApi.Domain.Entities;
using MonitoringApi.Domain.Interfaces.Services;
using MonitoringApi.Infra.Data;

namespace MonitoringApi.Infra.Repositories
{
    public class SetorEquipamentoRepository : ISetorEquipamentoRepository
    {
        private readonly MonitoramentoDbContex _monitoramentoDbContex;

        public SetorEquipamentoRepository(MonitoramentoDbContex monitoramentoDbContex)
        {
            _monitoramentoDbContex = monitoramentoDbContex;
        }

        public async Task<bool> Inserir(SetorEquipamento request)
        {
            await _monitoramentoDbContex.SetorEquipamentos.AddAsync(request);
            _monitoramentoDbContex.SaveChanges();

            return true;
        }

        public async Task<bool> Vincular(Sensor request)
        {
            var sensorExistente = await _monitoramentoDbContex.Sensores
        .FirstOrDefaultAsync(s => s.Id == request.Id);

            if (sensorExistente != null)
            {
                sensorExistente.SetorEquipamentoId = request.SetorEquipamentoId;
                await _monitoramentoDbContex.SaveChangesAsync();
                return true; 
            }

            return false; 
        }
        public async Task<List<SetorEquipamento>> ListarTodos()
        {
            return await _monitoramentoDbContex.SetorEquipamentos.ToListAsync();
        }
    }
}
