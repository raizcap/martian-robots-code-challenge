namespace MartianRobotsApp.Services
{
    public interface IHttpClientService
    {
        Task<T?> GetAsync<T>(string url);

        Task<T?> PostAsync<T>(string url);
    }
}