namespace MonitoringApi.Domain.Entities
{
    public class Sensor
    {
        public int Id { get; set; }
        public int? SetorEquipamentoId { get; set; }
        public string? Codigo { get; set; }
        public decimal ValorEsperado { get; set; }

        public virtual List<Medicao>? Medicoes { get; set; } 
    }
}
