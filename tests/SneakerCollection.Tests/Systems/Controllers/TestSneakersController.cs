namespace SneakerCollection.Tests.Systems.Controllers
{
    public class TestSneakersController
    {
        //[Fact]
        //public async Task Get_OnSuccess_ReturnsStatusCode200()
        //{
        //    // Arrange
        //    var mockSneakersService = new Mock<ISneakersService>();
        //    mockSneakersService
        //        .Setup(service => service.GetAllSneakers())
        //        .ReturnsAsync(SneakersFixture.GetTestSneakers());

        //    var sut = new SneakersController(mockSneakersService.Object);

        //    // Act
        //    var result = (OkObjectResult)await sut.Get();

        //    // Assert
        //    result.StatusCode.Should().Be(200);
        //}

        //[Fact]
        //public async Task Get_OnSuccess_InvokesSneakersServiceExactlyOnce()
        //{
        //    // Arrange
        //    var mockSneakersService = new Mock<ISneakersService>();
        //    mockSneakersService
        //        .Setup(service => service.GetAllSneakers())
        //        .ReturnsAsync([]);

        //    var sut = new SneakersController(mockSneakersService.Object);

        //    // Act
        //    var result = await sut.Get();

        //    // Assert
        //    mockSneakersService.Verify(
        //        service => service.GetAllSneakers(),
        //        Times.Once());
        //}

        //[Fact]
        //public async Task Get_OnSuccess_ReturnsListOfSneakers()
        //{
        //    // Arrange
        //    var mockSneakersService = new Mock<ISneakersService>();
        //    mockSneakersService
        //        .Setup(service => service.GetAllSneakers())
        //        .ReturnsAsync(SneakersFixture.GetTestSneakers());

        //    var sut = new SneakersController(mockSneakersService.Object);

        //    // Act
        //    var result = await sut.Get();

        //    // Assert
        //    result.Should().BeOfType<OkObjectResult>();
        //    var objectResult = (OkObjectResult)result;
        //    objectResult.Value.Should().BeOfType<List<Sneaker>>();
        //}

        //[Fact]
        //public async Task Get_OnNoSneakersFound_Returns404()
        //{
        //    // Arrange
        //    var mockSneakersService = new Mock<ISneakersService>();
        //    mockSneakersService
        //        .Setup(service => service.GetAllSneakers())
        //        .ReturnsAsync([]);

        //    var sut = new SneakersController(mockSneakersService.Object);

        //    // Act
        //    var result = await sut.Get();

        //    // Assert
        //    result.Should().BeOfType<NotFoundObjectResult>();
        //    var objectResult = (NotFoundObjectResult)result;
        //    objectResult.StatusCode.Should().Be(404);
        //}
    }
}