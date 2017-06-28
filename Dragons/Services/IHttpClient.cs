using System.Net.Http;
using System.Threading.Tasks;

namespace DragonsOfMugloar.Services
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> DoPut(object jsonBody, string uri);

        Task<string> DoGet(string uri);
    }
}
