using DragonsOfMugloar.DTOs;
using DragonsOfMugloar.Services.Strategy;
using Xunit;

namespace DragonsOfMugloar.Tests
{
    public class LongDryWeatherStrategyTests
    {
        private readonly IWeatherStrategy _longDryStrategy;
        private readonly DragonDto _dragonModel;

        public LongDryWeatherStrategyTests()
        {
            _longDryStrategy = new LongDryWeatherStrategy();
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
            var expectedDragon = new DragonDto
            {
                ClawSharpness = 5,
                FireBreath = 5,
                ScaleThickness = 5,
                WingStrength = 5
            };

            var result = _longDryStrategy.CreateDragon(_dragonModel, null);

            Assert.NotNull(result);
            Assert.Equal(expectedDragon.FireBreath, result.FireBreath);
            Assert.Equal(expectedDragon.ClawSharpness, result.ClawSharpness);
            Assert.Equal(expectedDragon.ScaleThickness, result.ScaleThickness);
            Assert.Equal(expectedDragon.WingStrength, result.WingStrength);
        }
    }
}
