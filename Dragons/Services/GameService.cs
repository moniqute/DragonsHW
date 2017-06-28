using System;
using System.Collections.Generic;
using System.Linq;
using DragonsOfMugloar.Infrastructure;
using DragonsOfMugloar.DTOs;
using DragonsOfMugloar.Services.Logger;
using DragonsOfMugloar.Services.Strategy;

namespace DragonsOfMugloar.Services
{
    public class GameService
    {
        private readonly ILogger _logger;

        private readonly IHttpClient _httpClient;


        public GameService(ILogger logger, IHttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public string StartNewGame()
        {
            var gameClient = new GameClient(_httpClient, _logger, Constants.GameUri);
            var weatherClient = new WeatherClient(_httpClient, _logger, Constants.WeatherUri);

            var gameInfo = gameClient.GetGame();

            var weather = weatherClient.GetWeather(gameInfo.GameId);

            var dragon = Context.CreateDragon(Constants.WeatherNormal, new DragonDto(), gameInfo.Knight); 

            if (weather.Code != Constants.WeatherNormal)
            {
                dragon = Context.CreateDragon(weather.Code, dragon, gameInfo.Knight); // Modifies dragon if weather is not normal
            }

            var result = gameClient.SolveBattle(gameInfo.GameId, dragon);

            return result.Status;
        }

        public void ShowStatistics(long gameStartTime, List<string> results)
        {
            var wonGames = results.Where(x => x == "Victory").ToList();

            _logger.Write("Games played: " + results.Count + " Games won: " + wonGames.Count + " Percentage: " + (int)Math.Round(((decimal)wonGames.Count / (decimal)results.Count) * 100) + "%");
            _logger.Write("Time taken to finish : "+ ((DateTime.Now.Ticks - gameStartTime) / 1000));
        }
    }
}
