using DragonsOfMugloar.DTOs;

namespace DragonsOfMugloar.Services.Strategy
{
    public interface IWeatherStrategy
    {
        DragonDto CreateDragon(DragonDto dragon, KnightDto knight);
    }
}
