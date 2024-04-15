using MonitoringApi.Domain.DTOs;
using MonitoringApi.Domain.Entities;
using MonitoringApi.Domain.Interfaces.Services;
using MonitoringApi.Domain.Request;

namespace MonitoringApi.Business.Services
{
    public class SetorEquipamentoService : ISetorEquipamentoService
    {
        private readonly ISetorEquipamentoRepository _repository;

        public SetorEquipamentoService(ISetorEquipamentoRepository setorEquipamentoRepository)
        {
            _repository = setorEquipamentoRepository;
        }

        public async Task<List<SetorEquipamentoDTO>> ListarTodos()
        {          
            List<SetorEquipamento> setorEquipamento = await _repository.ListarTodos();

            var response = MapearListaSetorEquipamento(setorEquipamento);

            return response; 
        }
        public async Task<bool> Adicionar(SetorEquipamentoRequest request)
        {
            SetorEquipamento setorEquipamento = new SetorEquipamento()
            {
                Nome = request.Nome
            };

            return await _repository.Inserir(setorEquipamento);
        }

        public async Task<bool> Vincular(SetorEquipamentoVincularSensorRequest request)
        {
            Sensor sensor = new Sensor()
            {
                Id = request.IdSensor,
                SetorEquipamentoId = request.IdSetorEquipamento
            };

            return await _repository.Vincular(sensor);
        }
        private List<SetorEquipamentoDTO> MapearListaSetorEquipamento(List<SetorEquipamento> setorEquipamentos)
        {
            var response = new List<SetorEquipamentoDTO>();

            foreach (var lst in setorEquipamentos)
            {
                var setorEquipamentoDTO = new SetorEquipamentoDTO
                {
                    Id = lst.Id,
                    Nome = lst.Nome
                };

                response.Add(setorEquipamentoDTO);
            }           

            return response;
        }
    }
}
