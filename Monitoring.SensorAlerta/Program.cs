using Microsoft.EntityFrameworkCore;
using MonitoringApi.Domain.Interfaces.Services;
using MonitoringApi.Infra.Data;
using MonitoringApi.Infra.Repositories;

namespace Monitoring.SensorAlerta
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
               .ConfigureServices((hostContext, services) =>
               {
                    services.AddDbContext<MonitoramentoDbContex>(options =>
                    options.UseNpgsql(hostContext.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);
                        services.AddSingleton<ISensorRepository, SensorRepository>();
                        services.AddHostedService<Worker>();
                    })
                .Build();

            host.Run();
        }
    }
}