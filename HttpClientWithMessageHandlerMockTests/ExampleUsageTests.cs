using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HttpClientWithMessageHandlerMock;
using Moq;
using Xunit;

namespace HttpClientWithMessageHandlerMockTests
{
    public class ExampleUsageTests
    {
        [Theory]
        [InlineData("DELETE", "http://test1")]
        [InlineData("POST", "http://test2")]
        [InlineData("PUT", "http://test3")]
        [InlineData("GET", "http://test4")]
        [InlineData("PATCH", "http://test5")]
        public async Task TestThatShizzle(string method, string url)
        {
            // Given
            var clientAndMock = HttpClientAndMockFactory.Create();
            var classUnderTest = new ExampleClassUnderTest(clientAndMock.HttpClient);

            clientAndMock.HttpMessageHandlerMock.Setup(h => h.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>()))
                                                .ReturnsAsync(new HttpResponseMessage());

            var httpMethod = new HttpMethod(method);
            var uri = new Uri(url);

            // When
            await classUnderTest.MethodWhichCallsSendAsync(new HttpRequestMessage { Method = httpMethod, RequestUri = uri });

            // Then
            clientAndMock.HttpMessageHandlerMock.Verify(h => h.SendAsync(It.Is<HttpRequestMessage>(m => m.Method == httpMethod), It.IsAny<CancellationToken>()), 
                                                        Times.Once());

            clientAndMock.HttpMessageHandlerMock.Verify(h => h.SendAsync(It.Is<HttpRequestMessage>(m => m.RequestUri == uri), It.IsAny<CancellationToken>()), 
                                                        Times.Once());
        }
    }
}
