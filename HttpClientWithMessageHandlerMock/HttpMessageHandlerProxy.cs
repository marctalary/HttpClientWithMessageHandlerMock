using Moq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientWithMessageHandlerMock
{
    public class HttpMessageHandlerProxy : HttpMessageHandler
    {
        public HttpMessageHandlerProxy(Mock<MockableHandler> handlerMock)
        {
            HandlerMock = handlerMock;
        }
        
        public Mock<MockableHandler> HandlerMock { get; }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return HandlerMock.Object.SendAsync(request, cancellationToken);
        }
    }

}
