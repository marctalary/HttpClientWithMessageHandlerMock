using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientWithMessageHandlerMockTests
{
    public class ExampleClassUnderTest
    {
        private readonly HttpClient _client;

        public ExampleClassUnderTest(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> MethodWhichCallsSendAsync(HttpRequestMessage request)
        {
            return await _client.SendAsync(request);
        }
    }
}
