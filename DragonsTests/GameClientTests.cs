using System.Net.Http;
using System.Threading.Tasks;
using DragonsOfMugloar.DTOs;
using DragonsOfMugloar.Services;
using DragonsOfMugloar.Services.Logger;
using Moq;
using Xunit;

namespace DragonsOfMugloar.Tests
{
    public class GameClientTests
    {
        private readonly GameClient _gameClient;
        private readonly Mock<IHttpClient> _httpClient;
        private readonly string _gameInfo = @"{""gameId"":8045245,""knight"":{""name"":""Sir.Steven Glover of Alberta"",""attack"":2,""armor"":2,""agility"":8,""endurance"":8}}";
        private readonly string _gameResultText = @"{""status"":""Victory"",""message"":""Dragon was successful in a glorious battle""}";
        private readonly Mock<ILogger> _logger;
        private readonly DragonDto _dragonDto;
        private readonly HttpResponseMessage _gameResult;

        public GameClientTests()
        {
            _httpClient = new Mock<IHttpClient>();
            _logger = new Mock<ILogger>();
            _gameResult = new HttpResponseMessage { Content = new StringContent(_gameResultText) };
            _httpClient.Setup(x => x.DoGet(It.IsAny<string>())).Returns(Task.FromResult(_gameInfo));
            _httpClient.Setup(x => x.DoPut(It.IsAny<object>(), It.IsAny<string>())).ReturnsAsync(_gameResult);
            _gameClient = new GameClient(_httpClient.Object, _logger.Object, "uri");
            _dragonDto = new DragonDto
            {
                ClawSharpness = 10,
                FireBreath = 3,
                ScaleThickness = 2,
                WingStrength = 5
            };
        }

        [Fact]
        public void GetGame_ShouldReturnGameInfo()
        {

            var expectedResult = new GameDto
            {
                GameId = 8045245,
                Knight = new KnightDto
                {
                    Armor = 2,
                    Attack = 2,
                    Agility = 8,
                    Endurance = 8
                }
            };

            var result = _gameClient.GetGame();

            Assert.NotNull(result);
            Assert.Equal(expectedResult.GameId, result.GameId);
            Assert.Equal(expectedResult.Knight.Attack, result.Knight.Attack);
            Assert.Equal(expectedResult.Knight.Agility, result.Knight.Agility);
            Assert.Equal(expectedResult.Knight.Armor, result.Knight.Armor);
            Assert.Equal(expectedResult.Knight.Endurance, result.Knight.Endurance);
        }

        [Fact]
        public void SolveBattle_ShouldReturnGameResults()
        {
            var expectedResult = new GameResultDto
            {
                Message = "Dragon was successful in a glorious battle",
                Status = "Victory"
            };

            var result = _gameClient.SolveBattle(00001, _dragonDto);

            Assert.NotNull(result);
            Assert.Equal(expectedResult.Message, result.Message);
            Assert.Equal(expectedResult.Status, result.Status);
        }
    }
}
