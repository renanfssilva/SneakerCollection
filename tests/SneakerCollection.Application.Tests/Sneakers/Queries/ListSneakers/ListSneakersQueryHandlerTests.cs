using ErrorOr;
using FluentAssertions;
using MockQueryable.Moq;
using Moq;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Application.Sneakers.Queries.ListSneakers;
using SneakerCollection.Application.Tests.Sneakers.Queries.TestUtils;
using SneakerCollection.Application.Tests.Sneakers.Utils;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Application.Tests.Sneakers.Queries.ListSneakers
{
    public class ListSneakersQueryHandlerTests
    {
        private readonly ListSneakersQueryHandler _handler;
        private readonly Mock<ISneakerRepository> _mockSneakerRepository;

        public ListSneakersQueryHandlerTests()
        {
            _mockSneakerRepository = new Mock<ISneakerRepository>();
            _handler = new ListSneakersQueryHandler(_mockSneakerRepository.Object);
        }

        [Fact]
        public async Task HandleListSneakersQuery_WhenSneakersExist_ShouldReturnSneakers()
        {
            // Arrange
            var sneakerList = new List<Sneaker> { SneakerUtils.CreateSneaker() };
            var mockList = sneakerList.AsQueryable().BuildMock();
            _mockSneakerRepository.Setup(s => s.List(It.IsAny<UserId>(),
                                                          It.IsAny<string>(),
                                                          It.IsAny<string>(),
                                                          It.IsAny<string>())).Returns(mockList);
            var query = ListSneakersQueryUtils.GetQuery();

            // Act
            var result = await _handler.Handle(query, default);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Items.Should().BeEquivalentTo(sneakerList.AsQueryable());
            _mockSneakerRepository.Verify(s => s.List(It.IsAny<UserId>(),
                                                           It.IsAny<string>(),
                                                           It.IsAny<string>(),
                                                           It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task HandleListSneakersQuery_WhenSneakersDoNotExist_ShouldReturnEmptyList()
        {
            // Arrange
            var sneakerList = new List<Sneaker>();
            var mockList = sneakerList.AsQueryable().BuildMock();
            _mockSneakerRepository.Setup(s => s.List(It.IsAny<UserId>(),
                                                           It.IsAny<string>(),
                                                           It.IsAny<string>(),
                                                           It.IsAny<string>())).Returns(mockList);
            var query = ListSneakersQueryUtils.GetQuery();

            // Act
            var result = await _handler.Handle(query, default);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Items.Should().BeEmpty();
            _mockSneakerRepository.Verify(s => s.List(It.IsAny<UserId>(),
                                                           It.IsAny<string>(),
                                                           It.IsAny<string>(),
                                                           It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task HandleListSneakersQuery_WhenUserIdIsInvalid_ShouldReturnError()
        {
            // Arrange
            var query = ListSneakersQueryUtils.GetQuery(userId: string.Empty);

            // Act
            var result = await _handler.Handle(query, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            _mockSneakerRepository.Verify(s => s.List(It.IsAny<UserId>(),
                                                           It.IsAny<string>(),
                                                           It.IsAny<string>(),
                                                           It.IsAny<string>()), Times.Never);
        }
    }
}
