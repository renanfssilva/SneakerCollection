using SneakerCollection.Application.Sneakers.Commands.DeleteSneaker;
using SneakerCollection.Domain.Tests.TestUtils.Constants;

namespace SneakerCollection.Application.Tests.Sneakers.Commands.TestUtils
{
    public static class DeleteSneakerCommandUtils
    {
        public static DeleteSneakerCommand DeleteCommand(Guid? sneakerId = null, string? userId = null)
            => new(
                sneakerId ?? Constants.Sneaker.Id.Value,
                userId ?? Constants.User.Id.Value.ToString()!);
    }
}
