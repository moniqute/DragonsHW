using System.Collections.Generic;
using DragonsOfMugloar.Infrastructure;
using DragonsOfMugloar.DTOs;

namespace DragonsOfMugloar.Services.Strategy
{
    public class Context
    {
        private static readonly Dictionary<string, IWeatherStrategy> _strategies = new Dictionary<string, IWeatherStrategy>();

        static Context()
        {
            _strategies.Add(Constants.WeatherNormal, new NormalWeatherStrategy());
            _strategies.Add(Constants.WeatherFog, new FogyWeatherStrategy());
            _strategies.Add(Constants.WeatherHeavyRain, new HeavyRainWeatherStrategy());
            _strategies.Add(Constants.WeatherLongDry, new LongDryWeatherStrategy());
            _strategies.Add(Constants.WeatherStorm, new StormWeatherStrategy());
        }

        public static DragonDto CreateDragon(string code, DragonDto dragon, KnightDto knight)
        {
            var result = _strategies[code].CreateDragon(dragon, knight);

            return result;
        }

    }
}
