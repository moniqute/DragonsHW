using System;
using System.IO;
using System.Xml.Serialization;
using DragonsOfMugloar.DTOs;
using DragonsOfMugloar.Services.Logger;

namespace DragonsOfMugloar.Services
{
    public class WeatherClient
    {
        private readonly IHttpClient _httpClient;
        private readonly ILogger _logger;
        private readonly string _uri;

        public WeatherClient(IHttpClient httpClient, ILogger logger, string uri)
        {
            _httpClient = httpClient;
            _logger = logger;
            _uri = uri;
        }

        public ReportDto GetWeather(int gameId)
        {
            var path = Convert.ToString(gameId);
            var fullPath = String.Format("{0}{1}", _uri, path);

            var response = _httpClient.DoGet(fullPath);

            var serializer = new XmlSerializer(typeof(ReportDto));
            TextReader reader = new StringReader(response.Result);
            
            var result = (ReportDto)serializer.Deserialize(reader);
            reader.Dispose();

            _logger.Write("Weather code = " + result.Code);
            _logger.Write("Weather message = " + result.Message);
            _logger.Write("Weather Rating = " + result.Rating);

            return result;
        }
    }
}
