namespace SneakerCollection.Contracts.Sneakers
{
    public record UpsertSneakerRequest(
        string Name,
        BrandRequest Brand,
        PriceRequest Price,
        double SizeUS,
        int Year,
        int Rate);
}
