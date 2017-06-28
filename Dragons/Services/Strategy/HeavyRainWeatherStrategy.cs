using DragonsOfMugloar.DTOs;

namespace DragonsOfMugloar.Services.Strategy
{
    public class HeavyRainWeatherStrategy : IWeatherStrategy
    {
        public DragonDto CreateDragon(DragonDto dragon, KnightDto knight)
        {
            var fire = dragon.FireBreath;
            dragon.ClawSharpness = dragon.ClawSharpness + fire;

            if (dragon.ClawSharpness > 10)
            {
                var attributes = dragon.ClawSharpness - 10;
                dragon.ScaleThickness = dragon.ScaleThickness + attributes;
                dragon.ClawSharpness = 10;
            }
            dragon.FireBreath = 0;

            return dragon;
        }
    }
}
