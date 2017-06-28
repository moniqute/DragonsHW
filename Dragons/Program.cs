using System;
using System.Collections.Generic;
using DragonsOfMugloar.Infrastructure;
using DragonsOfMugloar.Services;
using DragonsOfMugloar.Services.Logger;

namespace DragonsOfMugloar
{
    public class Program
    {
        private readonly ConsoleLogger _logger;
        private readonly IHttpClient _httpClient;

        public Program()
        {
            _logger = new ConsoleLogger {NextLogger = new FileLogger(Constants.LogFileName)};
            _httpClient = new HttpClient();
        }

        static void Main(string[] args)
        {
            var program = new Program();

            var gameService = new GameService(program._logger, program._httpClient);

            program._logger.Write("Welcome to the game" );
            program._logger.Write("How many games are you willing to play? Input a number");

            var input = Console.ReadLine();

            int timesGamePlayed;
            var isNumerical = Int32.TryParse(input, out timesGamePlayed);
            var results = new List<string>();
            var timeNow = DateTime.Now.Ticks;
            if (isNumerical)
            {
                for (var i = 0; i < timesGamePlayed; i++)
                {
                    results.Add(gameService.StartNewGame());
                }

                gameService.ShowStatistics(timeNow, results);
            }
            else
            {
                program._logger.Write("haha nice try.");
            }

            Console.ReadLine();
        }
    }
}
