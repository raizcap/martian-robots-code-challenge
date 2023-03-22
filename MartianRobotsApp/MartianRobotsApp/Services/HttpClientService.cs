using System;
using MartianRobotsApp.Models;
using System.Net.Http;
using System.Text.Json;

namespace MartianRobotsApp.Services
{
    public class HttpClientService : HttpClient, IHttpClientService
    {
        public HttpClientService() : base()
        {
        }

        public async Task<T?> GetAsync<T>(string url)
        {
            var response = await GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return default(T);
            }

            try
            {
                var responseObject = JsonSerializer.Deserialize<T>(response.Content.ReadAsStream());
                return responseObject;
            }
            catch (Exception e)
            {
                throw new Exception($"Error geting an object of type {typeof(T)}. URL: {url}. Error: {e.Message}");
            }
        }

        public async Task<T?> PostAsync<T>(string url)
        {
            var response = await PostAsync(url, null);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return default(T);
            }

            try
            {
                var responseObject = JsonSerializer.Deserialize<T>(response.Content.ReadAsStream());
                return responseObject;
            }
            catch (Exception e)
            {
                throw new Exception($"Error geting an object of type {typeof(T)}. URL: {url}. Error: {e.Message}");
            }
        }
    }
}

