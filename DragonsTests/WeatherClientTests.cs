using System.Threading.Tasks;
using DragonsOfMugloar.DTOs;
using DragonsOfMugloar.Infrastructure;
using DragonsOfMugloar.Services;
using DragonsOfMugloar.Services.Logger;
using Moq;
using Xunit;

namespace DragonsOfMugloar.Tests
{
    public class WeatherClientTests
    {
        private readonly WeatherClient _weatherClient;
        private readonly Mock<IHttpClient> _httpClient;
        private readonly Mock<ILogger> _logger;
        private readonly string _weatherResults;

        public WeatherClientTests()
        {
            _httpClient = new Mock<IHttpClient>();
            _logger = new Mock<ILogger>();
            _weatherResults = @"<?xml version=""1.0"" encoding=""UTF - 8""?><report><time/><coords><x>3916.234</x><y>169.914</y><z>6.33</z></coords><code>NMR</code><message>Another day of everyday normal regular weather, business as usual, unless it’s going to be like the time of the Great Paprika Mayonnaise Incident of 2014, that was some pretty nasty stuff.</message><varX-Rating>8</varX-Rating></report>";
            _httpClient.Setup(x => x.DoGet(It.IsAny<string>())).Returns(Task.FromResult(_weatherResults));
            _weatherClient = new WeatherClient(_httpClient.Object, _logger.Object, "uri");
        }

        [Fact]
        public void GetWeather_ShouldReturnWeather()
        {
            var expectedResult = new ReportDto()
            {
                Code = Constants.WeatherNormal,
                Message = "Another day of everyday normal regular weather, business as usual, unless it’s going to be like the time of the Great Paprika Mayonnaise Incident of 2014, that was some pretty nasty stuff.",
                Rating = "8"
            };

            var result = _weatherClient.GetWeather(00001);

            Assert.NotNull(result);
            Assert.Equal(expectedResult.Code, result.Code);
            Assert.Equal(expectedResult.Message, result.Message);
            Assert.Equal(expectedResult.Rating, result.Rating);
        }
    }
}
