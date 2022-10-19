using Microsoft.Extensions.Logging;
using Moq;
using RoomBookingApp.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingApp.Api.Tests
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public void Should_Return_Forecast_Results()
        {
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);

            var result = controller.Get();

            Assert.NotNull(result);
            Assert.True(result.Count() > 1, "The amount was not greater than 0.");
        }
    }
}
