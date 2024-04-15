using Microsoft.EntityFrameworkCore;
using MonitoringApi.Business.Services;
using MonitoringApi.Domain.Interfaces.Services;
using MonitoringApi.Infra.Data;
using MonitoringApi.Infra.Repositories;

namespace MonitoringApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<MonitoramentoDbContex>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ISensorService, SensorService>();
            builder.Services.AddScoped<ISensorRepository, SensorRepository>();

            builder.Services.AddScoped<ISetorEquipamentoService, SetorEquipamentoService>();
            builder.Services.AddScoped<ISetorEquipamentoRepository, SetorEquipamentoRepository>();

            builder.Services.AddScoped<IMedicaoService, MedicaoService>();
            builder.Services.AddScoped<IMedicaoRepository, MedicaoRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}