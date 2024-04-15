using MonitoringApi.Domain.Entities;
using MonitoringApi.Domain.Interfaces.Services;

namespace Monitoring.SensorAlerta
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISensorRepository _sensorRepository;

        private const int LimiteInferior = 1;
        private const int LimiteSuperior = 50;
        private const int NumeroMedicoesConsecutivas = 5;

        public Worker(ILogger<Worker> logger,
                      ISensorRepository sensorRepository)
        {
            _logger = logger;
            _sensorRepository = sensorRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Executando o JOB de Alerta em: {time}", DateTimeOffset.Now);

                var sensores = await _sensorRepository.ListarTodos();

                VerificarSensores(sensores);

                await Task.Delay(5000, stoppingToken);
            }
        }

        private void VerificarSensores(List<Sensor> sensores)
        {
            foreach (var sensor in sensores)
            {
                if (sensor.Medicoes == null) continue;

                // Verificar medições fora dos limites
                VerificarLimites(sensor);
            }
        }

        private void VerificarLimites(Sensor sensor)
        {
            if (sensor.Medicoes != null)
            {
                var ultimasMedicoes = sensor.Medicoes.TakeLast(NumeroMedicoesConsecutivas);
                var medicoesForaDosLimites = ultimasMedicoes.Where(m => m.Valor < LimiteInferior || m.Valor > LimiteSuperior);

                if (medicoesForaDosLimites.Count() >= NumeroMedicoesConsecutivas)
                {
                    string mensagem = "Medições fora dos limites por mais de 5 vezes consecutivas.";
                    _logger.LogInformation(mensagem);
                    EnviarEmailAlerta(sensor, mensagem);
                }
            }
        }

        private void EnviarEmailAlerta(Sensor sensor, string mensagem)
        {
            string destinatario = "email@exemplo.com";
            string assunto = $"Alerta: Sensor {sensor.Id}";
            string corpo = mensagem;

            EnviarEmail(destinatario, assunto, corpo);
        }

        private void EnviarEmail(string destinatario, string assunto, string corpo)
        {
            // TODO ENVIO DE EMAIL

            _logger.LogInformation("E-mail enviado com sucesso!");
        }
    }
}