using DragonsOfMugloar.DTOs;
using DragonsOfMugloar.Services.Strategy;
using Xunit;

namespace DragonsOfMugloar.Tests
{
    public class StormWeatherStrategyTests
    {
        private readonly IWeatherStrategy _stormStrategy;
        private readonly DragonDto _dragonModel;

        public StormWeatherStrategyTests()
        {
            _stormStrategy = new StormWeatherStrategy();
            _dragonModel = new DragonDto
            {
                ClawSharpness = 10,
                FireBreath = 3,
                ScaleThickness = 2,
                WingStrength = 5
            };
        }

        [Fact]
        public void CreateDragon_ShouldReturnDragon()
        {
            var result = _stormStrategy.CreateDragon(_dragonModel, null);

            Assert.Null(result);
        }
    }
}
