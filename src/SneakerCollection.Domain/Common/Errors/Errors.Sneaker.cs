using ErrorOr;

namespace SneakerCollection.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Sneaker
        {
            public static Error NotFound => Error.NotFound(
                code: "Sneaker.NotFound",
                description: "Sneaker was not found");
        }
    }
}
