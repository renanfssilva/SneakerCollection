using SneakerCollection.Domain.SneakerAggregate;

namespace SneakerCollection.API.Services
{
    public interface ISneakersService
    {
        Task<List<Sneaker>> GetAllSneakers();
    }

    //public class SneakersService(HttpClient httpClient, IOptions<SneakersApiOptions> apiConfig) : ISneakersService
    //{
    //    private readonly SneakersApiOptions _apiConfig = apiConfig.Value;

    //    public async Task<List<Sneaker>> GetAllSneakers()
    //    {
    //        var sneakersResponse = await httpClient.GetAsync(_apiConfig.Endpoint);

    //        if (sneakersResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
    //            return [];

    //        var responseContent = sneakersResponse.Content;
    //        var allSneakers = await responseContent.ReadFromJsonAsync<List<Sneaker>>();
    //        return allSneakers.ToList();
    //    }
    //}
}
