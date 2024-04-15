namespace MonitoringApi.Domain.DTOs
{
    public class UltimasMedicoesDTO
    {
        public int IdSetorEquipamento { get; set; }
        public string SetorEquipamento { get; set; }
        public string CodigoSensor { get; set; }
        public decimal ValorMedicao { get; set; }
    }
}
