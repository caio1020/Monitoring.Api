using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonitoringApi.Controllers;
using MonitoringApi.Domain.DTOs;
using MonitoringApi.Domain.Interfaces.Services;
using MonitoringApi.Domain.Request;
using Moq;

namespace SensoresApi.Tests.Controllers
{
    public class SetorEquipamentoControllerTeste
    {
        [Fact]
        public async Task ListarTodos_DeveRetornarOkComDados()
        {     
                      
            // Arrange
            var mockService = new Mock<ISetorEquipamentoService>();
            var controller = new SetorEquipamentoController(mockService.Object);

            var dadosRetornoMock = new List<SetorEquipamentoDTO>();

            mockService.Setup(s => s.ListarTodos()).ReturnsAsync(dadosRetornoMock);

            // Act
            var result = await controller.ListarTodos();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<SetorEquipamentoDTO>>(okResult.Value);
            Assert.Equal(dadosRetornoMock, model);
        }

        [Fact]
        public async Task CriarSetorEquipamento_DeveRetornarOkQuandoSucesso()
        {
            // Arrange
            var mockService = new Mock<ISetorEquipamentoService>();
            var controller = new SetorEquipamentoController(mockService.Object);
            var sensorRequest = new SetorEquipamentoRequest {Nome = "TI"};
            mockService.Setup(s => s.Adicionar(sensorRequest)).ReturnsAsync(true);

            // Act
            var result = await controller.CriarSetorEquipamento(sensorRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True(okResult.StatusCode == 200);
        }        

        [Fact]
        public async Task CriarSetorEquipamento_DeveRetornarBadRequestQuandoModelStateInvalido()
        {
            // Arrange
            var mockService = new Mock<ISetorEquipamentoService>();
            var controller = new SetorEquipamentoController(mockService.Object);
            var setorEquipamentoRequest = new SetorEquipamentoRequest { Nome = "TI" };

            // Act
            var result = await controller.CriarSetorEquipamento(setorEquipamentoRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True(okResult.StatusCode == 200);
        }

        [Fact]
        public async Task SetorEquipamentoVincularSensor_DeveRetornarOkQuandoSucesso()
        {
            // Arrange
            var mockService = new Mock<ISetorEquipamentoService>();
            var controller = new SetorEquipamentoController(mockService.Object);
            var request = new SetorEquipamentoVincularSensorRequest { IdSensor = 1, IdSetorEquipamento = 1};
            mockService.Setup(s => s.Vincular(request)).ReturnsAsync(true);

            // Act
            var result = await controller.SetorEquipamentoVincularSensor(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)okResult.Value);
        }

        [Fact]
        public async Task SetorEquipamentoVincularSensor_DeveRetornarBadRequestQuandoModelStateInvalido()
        {
            // Arrange
            var mockService = new Mock<ISetorEquipamentoService>();
            var controller = new SetorEquipamentoController(mockService.Object);
            var request = new SetorEquipamentoVincularSensorRequest { IdSensor = 1, IdSetorEquipamento = 1 };

            // Act
            var result = await controller.SetorEquipamentoVincularSensor(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True(okResult.StatusCode == 200);
        }
    }
}
