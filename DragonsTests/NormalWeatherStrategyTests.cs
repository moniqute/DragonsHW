using DragonsOfMugloar.DTOs;
using DragonsOfMugloar.Services.Strategy;
using Xunit;

namespace DragonsOfMugloar.Tests
{
    public class NormalWeatherStrategyTests
    {
        private readonly IWeatherStrategy _normalStrategy;
        private readonly DragonDto _dragon;
        private readonly KnightDto _knight;

        public NormalWeatherStrategyTests()
        {
            _normalStrategy = new NormalWeatherStrategy();
            _dragon = new DragonDto();
            _knight = new KnightDto
            {
                Agility = 8,
                Armor = 4,
                Attack = 0,
                Endurance = 8
            };
        }

        [Fact]
        public void CreateDragon_ShouldReturnDragon()
        {

            var expectedDragon = new DragonDto
            {
                    ClawSharpness = 3,
                    FireBreath = 7,
                    ScaleThickness = 0,
                    WingStrength = 10
            };

            var result = _normalStrategy.CreateDragon(_dragon, _knight);

            Assert.NotNull(result);
            Assert.Equal(expectedDragon.FireBreath, result.FireBreath);
            Assert.Equal(expectedDragon.ClawSharpness, result.ClawSharpness);
            Assert.Equal(expectedDragon.ScaleThickness, result.ScaleThickness);
            Assert.Equal(expectedDragon.WingStrength, result.WingStrength);
        }
    }
}
