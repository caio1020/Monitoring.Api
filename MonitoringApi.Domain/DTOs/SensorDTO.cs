namespace MonitoringApi.Domain.DTOs
{
    public class SensorDTO
    {
        public int Id { get; set; }
        public int? SetorEquipamentoId { get; set; }
        public string? Codigo { get; set; }
    }
}
