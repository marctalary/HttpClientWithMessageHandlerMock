using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientWithMessageHandlerMock
{
    public abstract class MockableHandler
    {
        public abstract Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
    }
}