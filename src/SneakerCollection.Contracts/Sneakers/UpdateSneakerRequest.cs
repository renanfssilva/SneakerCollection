namespace SneakerCollection.Contracts.Sneakers
{
    public record UpdateSneakerRequest(
        string Name,
        BrandRequest Brand,
        PriceRequest Price,
        double SizeUS,
        int Year,
        int Rate);
}
