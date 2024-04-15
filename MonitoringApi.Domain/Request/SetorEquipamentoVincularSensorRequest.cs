namespace MonitoringApi.Domain.Request
{
    public class SetorEquipamentoVincularSensorRequest
    {
        public int IdSensor { get; set; }
        public int IdSetorEquipamento { get; set; }
    }
}
