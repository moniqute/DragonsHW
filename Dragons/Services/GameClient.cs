using System;
using System.Threading.Tasks;
using DragonsOfMugloar.DTOs;
using DragonsOfMugloar.Services.Logger;
using Newtonsoft.Json;

namespace DragonsOfMugloar.Services
{
    public class GameClient
    {
        private readonly IHttpClient _httpClient;
        private readonly ILogger _logger;
        private readonly string _uri;

        public GameClient(IHttpClient httpClient, ILogger logger, string uri)
        {
            _httpClient = httpClient;
            _logger = logger;
            _uri = uri;
        }

        public GameDto GetGame()
        {
            var gameInfo = _httpClient.DoGet(_uri);

            var result = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<GameDto>(gameInfo.Result)).Result;

            _logger.Write("GameId = " + result.GameId);
            _logger.Write("Knight's name = " + result.Knight.Name);
            _logger.Write("Knight's agility = " + result.Knight.Agility);
            _logger.Write("Knight's armor = " + result.Knight.Armor);
            _logger.Write("Knight's attack = " + result.Knight.Attack);
            _logger.Write("Knight's endurance = " + result.Knight.Endurance);
            
            return result;
        }

        public GameResultDto SolveBattle(int gameId, DragonDto dragon)
        {
            if (dragon != null)
            {
                _logger.Write("Claw sharpness = " + dragon.ClawSharpness);
                _logger.Write("Firebreath = " + dragon.FireBreath);
                _logger.Write("Scale thickness = " + dragon.ScaleThickness);
                _logger.Write("Wing strength = " + dragon.WingStrength);
            }
            
            var partOfPath = "/{gameid}/solution/";
            var path = partOfPath.Replace("{gameid}", gameId.ToString());
            var fullPath = String.Format("{0}{1}", _uri, path);

            var dragonWrapper = new DragonDtoWrapper{ Dragon = dragon};

            var response = _httpClient.DoPut(dragonWrapper, fullPath);

            var gameResult = response.Result.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<GameResultDto>(gameResult);

            _logger.Write("Game Status: " + result.Status);
            _logger.Write("Message: " + result.Message);

            return result;
        }
    }
}
