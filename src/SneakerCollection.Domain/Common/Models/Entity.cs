namespace SneakerCollection.Domain.Common.Models
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
        where TId : notnull
    {
        public TId Id { get; protected set; }

        protected Entity(TId id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
            => obj is Entity<TId> entity && Id.Equals(entity.Id);

        public bool Equals(Entity<TId>? other)
            => Equals((object?)other);

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
            => left.Equals(right);

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
            => !left.Equals(right);

        public override int GetHashCode()
            => Id.GetHashCode();

#pragma warning disable CS8618
        protected Entity()
        {
        }
#pragma warning restore CS8618
    }
}
