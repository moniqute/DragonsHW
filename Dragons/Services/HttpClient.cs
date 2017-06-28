using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DragonsOfMugloar.Services
{
    public class HttpClient : IHttpClient
    {
        private readonly System.Net.Http.HttpClient _client;

        public HttpClient()
        {
            _client = new System.Net.Http.HttpClient();
        }

        public Task<HttpResponseMessage> DoPut(object jsonBody, string uri)
        {
            string json = JsonConvert.SerializeObject(jsonBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
    
            var response = _client.PutAsync(uri, content);

            return response;
        }

        public Task<string> DoGet(string uri)
        {
            Task<string> response = _client.GetStringAsync(uri);
            return response;
        }
    }
}
