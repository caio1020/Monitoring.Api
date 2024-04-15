using Microsoft.EntityFrameworkCore;
using MonitoringApi.Domain.Entities;
using MonitoringApi.Domain.Interfaces.Services;
using MonitoringApi.Infra.Data;

namespace MonitoringApi.Infra.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private readonly MonitoramentoDbContex _monitoramentoDbContex;

        public SensorRepository(MonitoramentoDbContex monitoramentoDbContex)
        {
            _monitoramentoDbContex = monitoramentoDbContex;
        }

        public async Task<bool> Inserir(Sensor sensor)
        {
            await _monitoramentoDbContex.Sensores.AddAsync(sensor);
            _monitoramentoDbContex.SaveChanges();

            return true;
        }

        public async Task<List<Sensor>> ListarTodos()
        {
            return await _monitoramentoDbContex.Sensores
                                                .Include(x => x.Medicoes).ToListAsync();
        }
    }
}
