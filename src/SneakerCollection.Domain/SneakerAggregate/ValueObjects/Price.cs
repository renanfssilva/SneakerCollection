using SneakerCollection.Domain.Common.Models;

namespace SneakerCollection.Domain.SneakerAggregate.ValueObjects
{
    public sealed class Price : ValueObject
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        private Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Price Create(decimal amount, string currency)
            => new(amount, currency);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Price()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
