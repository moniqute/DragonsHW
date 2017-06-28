using DragonsOfMugloar.DTOs;

namespace DragonsOfMugloar.Services.Strategy
{
    public class FogyWeatherStrategy : IWeatherStrategy
    {
        public DragonDto CreateDragon(DragonDto dragon, KnightDto knight)
        {
            return dragon;
        }
    }
}
