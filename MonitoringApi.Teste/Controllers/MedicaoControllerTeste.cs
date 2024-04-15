using Microsoft.AspNetCore.Mvc;
using MonitoringApi.Controllers;
using MonitoringApi.Domain.DTOs;
using MonitoringApi.Domain.Interfaces.Services;
using MonitoringApi.Domain.Request;
using Moq;

namespace MonitoringApi.Tests.Controllers
{
    public class MedicaoControllerTeste
    {
        [Fact]
        public async Task ListarUltimasMedicoes_DeveRetornarOkComDados()
        {
            // Arrange
            var mockService = new Mock<IMedicaoService>();
            var controller = new MedicaoController(mockService.Object);
            int idSetorEquipamento = 1;

            var dadosRetornoMock = new List<Domain.DTOs.UltimasMedicoesDTO>();

            mockService.Setup(s => s.ListarUltimasMedicoes(It.IsAny<int>())).ReturnsAsync(dadosRetornoMock);

            // Act
            var result = await controller.ListarUltimasMedicoes(idSetorEquipamento);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<UltimasMedicoesDTO>>(okResult.Value);
            Assert.Equal(dadosRetornoMock, model);
        }

        [Fact]
        public async Task InserirMedicao_DeveRetornarOkQuandoSucesso()
        {
            // Arrange
            var mockService = new Mock<IMedicaoService>();
            var controller = new MedicaoController(mockService.Object);
            var medicaoRequest = new MedicaoRequest { SensorId = 1, DataHora = DateTime.Now, Valor = 10 };
            mockService.Setup(s => s.Adicionar(medicaoRequest)).ReturnsAsync(true);

            // Act
            var result = await controller.InserirMedicao(medicaoRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Medição inserida com sucesso!", okResult.Value);
        }

        [Fact]
        public async Task InserirMedicao_DeveRetornarNotFoundQuandoFalha()
        {
            // Arrange
            var mockService = new Mock<IMedicaoService>();
            var controller = new MedicaoController(mockService.Object);
            var medicaoRequest = new MedicaoRequest { SensorId = 1, DataHora = DateTime.Now, Valor = 10 };
            mockService.Setup(s => s.Adicionar(medicaoRequest)).ReturnsAsync(false);

            // Act
            var result = await controller.InserirMedicao(medicaoRequest);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Sensor não encontrado.", notFoundResult.Value);
        }
    }
}
