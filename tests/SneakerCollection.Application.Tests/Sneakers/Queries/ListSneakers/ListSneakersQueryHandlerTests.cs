using ErrorOr;
using FluentAssertions;
using Moq;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Application.Sneakers.Queries.ListSneakers;
using SneakerCollection.Application.Tests.Sneakers.Queries.TestUtils;
using SneakerCollection.Application.Tests.Sneakers.Utils;
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
            var sneaker = SneakerUtils.CreateSneaker();
            _mockSneakerRepository.Setup(s => s.ListAsync(It.IsAny<UserId>())).ReturnsAsync([sneaker]);
            var query = ListSneakersQueryUtils.GetQuery();

            // Act
            var result = await _handler.Handle(query, default);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().BeEquivalentTo([sneaker]);
            _mockSneakerRepository.Verify(s => s.ListAsync(It.IsAny<UserId>()), Times.Once);
        }

        [Fact]
        public async Task HandleListSneakersQuery_WhenSneakersDoNotExist_ShouldReturnEmptyList()
        {
            // Arrange
            _mockSneakerRepository.Setup(s => s.ListAsync(It.IsAny<UserId>())).ReturnsAsync([]);
            var query = ListSneakersQueryUtils.GetQuery();

            // Act
            var result = await _handler.Handle(query, default);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().BeEmpty();
            _mockSneakerRepository.Verify(s => s.ListAsync(It.IsAny<UserId>()), Times.Once);
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
            _mockSneakerRepository.Verify(s => s.ListAsync(It.IsAny<UserId>()), Times.Never);
        }
    }
}
