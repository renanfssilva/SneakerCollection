namespace SneakerCollection.Tests.Systems.Services
{
    public class TestSneakersService
    {
        //[Fact]
        //public async Task GetAllSneakers_WhenCalled_InvokesHttpGetRequest()
        //{
        //    // Arrange
        //    var expectedResponse = SneakersFixture.GetTestSneakers();
        //    var handlerMock = MockHttpMessageHandler<Sneaker>.SetupBasicGetResourceList(expectedResponse);
        //    var httpClient = new HttpClient(handlerMock.Object);
        //    var endpoint = "https://example.com";
        //    var config = Options.Create(new SneakersApiOptions
        //    {
        //        Endpoint = endpoint,
        //    });
        //    var sut = new SneakersService(httpClient, config);

        //    // Act
        //    await sut.GetAllSneakers();

        //    // Assert
        //    handlerMock
        //        .Protected()
        //        .Verify(
        //            "SendAsync",
        //            Times.Exactly(1),
        //            ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
        //            ItExpr.IsAny<CancellationToken>()
        //        );
        //}

        //[Fact]
        //public async Task GetAllSneakers_WhenCalled_ReturnsListOfSneakers()
        //{
        //    // Arrange
        //    var expectedResponse = SneakersFixture.GetTestSneakers();
        //    var handlerMock = MockHttpMessageHandler<Sneaker>.SetupBasicGetResourceList(expectedResponse);
        //    var httpClient = new HttpClient(handlerMock.Object);
        //    var endpoint = "https://example.com";
        //    var config = Options.Create(new SneakersApiOptions
        //    {
        //        Endpoint = endpoint,
        //    });
        //    var sut = new SneakersService(httpClient, config);

        //    // Act
        //    var result = await sut.GetAllSneakers();

        //    // Assert
        //    result.Should().BeOfType<List<Sneaker>>();
        //}

        //[Fact]
        //public async Task GetAllSneakers_WhenHits404_ReturnsEmptyListOfSneakers()
        //{
        //    // Arrange
        //    var handlerMock = MockHttpMessageHandler<Sneaker>.SetupReturn404();
        //    var httpClient = new HttpClient(handlerMock.Object);
        //    var endpoint = "https://example.com";
        //    var config = Options.Create(new SneakersApiOptions
        //    {
        //        Endpoint = endpoint,
        //    });
        //    var sut = new SneakersService(httpClient, config);

        //    // Act
        //    var result = await sut.GetAllSneakers();

        //    // Assert
        //    result.Count.Should().Be(0);
        //}

        //[Fact]
        //public async Task GetAllSneakers_WhenCalled_ReturnsListOfSneakersOfExpectedSize()
        //{
        //    // Arrange
        //    var expectedResponse = SneakersFixture.GetTestSneakers();
        //    var handlerMock = MockHttpMessageHandler<Sneaker>.SetupBasicGetResourceList(expectedResponse);
        //    var httpClient = new HttpClient(handlerMock.Object);
        //    var endpoint = "https://example.com";
        //    var config = Options.Create(new SneakersApiOptions
        //    {
        //        Endpoint = endpoint,
        //    });
        //    var sut = new SneakersService(httpClient, config);

        //    // Act
        //    var result = await sut.GetAllSneakers();

        //    // Assert
        //    result.Count.Should().Be(expectedResponse.Count);
        //}

        //[Fact]
        //public async Task GetAllSneakers_WhenCalled_InvokesConfigureExternalUrl()
        //{
        //    // Arrange
        //    var expectedResponse = SneakersFixture.GetTestSneakers();
        //    var endpoint = "http://example.com/users";
        //    var handlerMock = MockHttpMessageHandler<Sneaker>.SetupBasicGetResourceList(expectedResponse);
        //    var httpClient = new HttpClient(handlerMock.Object);

        //    var config = Options.Create(new SneakersApiOptions
        //    {
        //        Endpoint = endpoint,
        //    });
        //    var sut = new SneakersService(httpClient, config);

        //    // Act
        //    var result = await sut.GetAllSneakers();
        //    var uri = new Uri(endpoint);

        //    // Assert
        //    handlerMock
        //        .Protected()
        //        .Verify(
        //            "SendAsync",
        //            Times.Exactly(1),
        //            ItExpr.Is<HttpRequestMessage>(
        //                req => req.Method == HttpMethod.Get
        //                && req.RequestUri == uri),
        //            ItExpr.IsAny<CancellationToken>()
        //        );
        //}
    }
}
