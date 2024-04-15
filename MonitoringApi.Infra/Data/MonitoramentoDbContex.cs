using Microsoft.EntityFrameworkCore;
using MonitoringApi.Domain.Entities;

namespace MonitoringApi.Infra.Data
{
    public class MonitoramentoDbContex : DbContext
    {
        public MonitoramentoDbContex(DbContextOptions<MonitoramentoDbContex> options) : base(options)
        {
        }

        public DbSet<Sensor> Sensores { get; set; }
        public DbSet<SetorEquipamento> SetorEquipamentos { get; set; }
        public DbSet<Medicao> Medicao { get; set; }
    }
}
