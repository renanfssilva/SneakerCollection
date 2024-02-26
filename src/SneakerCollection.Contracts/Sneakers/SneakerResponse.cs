namespace SneakerCollection.Contracts.Sneakers
{
    public record SneakerResponse(
        string Id,
        string Name,
        BrandResponse Brand,
        PriceResponse Price,
        double SizeUS,
        int Year,
        int Rate);

    public record BrandResponse(
        string Name);

    public record PriceResponse(
        decimal Amount,
        string Currency);
}
