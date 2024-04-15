namespace MonitoringApi.Domain.Request
{
    public class MedicaoRequest
    {
        public int SensorId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }
    }
}
