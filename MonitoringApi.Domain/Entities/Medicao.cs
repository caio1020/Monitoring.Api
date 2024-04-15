namespace MonitoringApi.Domain.Entities
{
    public class Medicao
    {
        public int Id { get; set; }
        public int SensorId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }
    }
}
