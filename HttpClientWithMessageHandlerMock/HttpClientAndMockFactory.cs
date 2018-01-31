using Moq;
using System.Net.Http;

namespace HttpClientWithMessageHandlerMock
{
    public class HttpClientAndMockFactory
    {
        public static (HttpClient HttpClient, Mock<MockableHandler> HttpMessageHandlerMock) Create()
        {
            var httpMessageHandlerWithMock = new HttpMessageHandlerProxy(new Mock<MockableHandler>());

            return (
                new HttpClient(httpMessageHandlerWithMock),
                httpMessageHandlerWithMock.HandlerMock
                );
        }
    }
}