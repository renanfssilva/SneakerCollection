using SneakerCollection.Domain.Common.Models;

namespace SneakerCollection.Domain.SneakerAggregate.ValueObjects
{
    public sealed class Brand : ValueObject
    {
        public string Name { get; private set; }

        private Brand(string name)
        {
            Name = name;
        }

        public static Brand Create(string name)
            => new(name);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Brand()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
