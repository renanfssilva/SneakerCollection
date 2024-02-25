using SneakerCollection.Domain.Common.Models.Identities;

namespace SneakerCollection.Domain.SneakerAggregate.ValueObjects
{
    public sealed class SneakerId : AggregateRootId<Guid>
    {
        private SneakerId(Guid value) : base(value) { }

        public static SneakerId CreateUnique()
            => new(Guid.NewGuid());

        public static SneakerId Create(Guid value)
            => new(value);
    }
}
