using DragonsOfMugloar.DTOs;
using DragonsOfMugloar.Services.Strategy;
using Xunit;

namespace DragonsOfMugloar.Tests
{
    public class HeavyRainWeatherStrategyTests
    {
        private readonly IWeatherStrategy _heavyRainStrategy;
        private readonly DragonDto _dragon;

        public HeavyRainWeatherStrategyTests()
        {
            _heavyRainStrategy = new HeavyRainWeatherStrategy();
            _dragon = new DragonDto
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
                ClawSharpness = 10,
                FireBreath = 0,
                ScaleThickness = 5,
                WingStrength = 5
            };

            var result = _heavyRainStrategy.CreateDragon(_dragon, null);

            Assert.NotNull(result);
            Assert.Equal(expectedDragon.FireBreath, result.FireBreath);
            Assert.Equal(expectedDragon.ClawSharpness, result.ClawSharpness);
            Assert.Equal(expectedDragon.ScaleThickness, result.ScaleThickness);
            Assert.Equal(expectedDragon.WingStrength, result.WingStrength);
        }
    }
}
