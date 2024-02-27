using SneakerCollection.Domain.SneakerAggregate.ValueObjects;

namespace SneakerCollection.Domain.Tests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class Sneaker
        {
            public static readonly SneakerId Id = SneakerId.Create(Guid.Parse("e7947777-fb7f-4504-ad04-7c9f96273aa7"));
            public const string Name = "Air Jordan";
            public const double SizeUS = 11;
            public const int Year = 2018;
            public const int Rate = 4;

            public const string BrandName = "Nike";

            public const string PriceCurrency = "$";
            public const decimal PriceAmount = 230;
        }
    }
}
