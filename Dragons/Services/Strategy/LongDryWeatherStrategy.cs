using DragonsOfMugloar.DTOs;

namespace DragonsOfMugloar.Services.Strategy
{
    public class LongDryWeatherStrategy : IWeatherStrategy
    {
        public DragonDto CreateDragon(DragonDto dragon, KnightDto knight)
        {
            dragon = new DragonDto
            {
                ClawSharpness = 5,
                FireBreath = 5,
                ScaleThickness = 5,
                WingStrength = 5
            };

            return dragon;
        }
    }
}
