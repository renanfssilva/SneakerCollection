using ErrorOr;
using SneakerCollection.Domain.Common.Errors;
using SneakerCollection.Domain.Common.Models.Identities;

namespace SneakerCollection.Domain.UserAggregate.ValueObjects
{
    public sealed class UserId : AggregateRootId<Guid>
    {
        private UserId(Guid value) : base(value)
        {
        }

        public static UserId CreateUnique()
            => new(Guid.NewGuid());

        public static UserId Create(Guid userId)
            => new(userId);

        public static ErrorOr<UserId> Create(string value)
            => Guid.TryParse(value, out var guid)
                ? (ErrorOr<UserId>)new UserId(guid)
                : (ErrorOr<UserId>)Errors.User.InvalidUserId;
    }
}
