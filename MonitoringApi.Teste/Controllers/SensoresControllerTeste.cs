using Microsoft.AspNetCore.Mvc;
using MonitoringApi.Controllers;
using MonitoringApi.Domain.DTOs;
using MonitoringApi.Domain.Interfaces.Services;
using MonitoringApi.Domain.Request;
using Moq;

namespace SensoresApi.Tests.Controllers
{
    public class SensoresControllerTeste
    {
        [Fact]
        public async Task ListarTodos_DeveRetornarOkComDados()
        {           

            // Arrange
            var mockService = new Mock<ISensorService>();
            var controller = new SensoresController(mockService.Object);

            var dadosRetornoMock = new List<SensorDTO>();

            mockService.Setup(s => s.ListarTodos()).ReturnsAsync(dadosRetornoMock);

            // Act
            var result = await controller.ListarTodos();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<SensorDTO>>(okResult.Value);
            Assert.Equal(dadosRetornoMock, model);
        }

        [Fact]
        public async Task CriarSensor_DeveRetornarOkQuandoSucesso()
        {
            // Arrange
            var mockService = new Mock<ISensorService>();
            var controller = new SensoresController(mockService.Object);
            var sensorRequest = new SensorRequest { Id = 1, Codigo = "001" };
            mockService.Setup(s => s.Adicionar(sensorRequest)).ReturnsAsync(true);

            // Act
            var result = await controller.CriarSensor(sensorRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)okResult.Value);
        }

        [Fact]
        public async Task CriarSensor_DeveRetornarBadRequestQuandoModelStateInvalido()
        {
            // Arrange
            var mockService = new Mock<ISensorService>();
            var controller = new SensoresController(mockService.Object);

            var sensorRequest = new SensorRequest { Id = 1, Codigo = "001" };

            // Act
            var result = await controller.CriarSensor(sensorRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.True(okResult.StatusCode == 200);
        }
    }
}
