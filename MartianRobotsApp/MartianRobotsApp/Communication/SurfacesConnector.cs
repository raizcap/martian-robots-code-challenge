using System;
using System.Text.Json;
using MartianRobotsApp.Models;
using MartianRobotsApp.Services;

namespace MartianRobotsApp.Communication
{
    public class SurfacesConnector : ISurfacesConnector
    {
        private const string BASE_URL = "http://localhost:5005/Surfaces/";
        private const string GET_BY_SIZE = "GetSurfaceBySize?XSize={0}&YSize={1}";
        private const string ADD = "AddSurface?XSize={0}&YSize={1}";
        private readonly HttpClientService mHttpClient;

        public SurfacesConnector()
        {
            mHttpClient = new HttpClientService();
        }

        public async Task<Surface?> GetSurfaceBySize(int XSize, int YSize)
        {
            var url = BASE_URL + string.Format(GET_BY_SIZE, XSize, YSize);

            var surface = await mHttpClient.GetAsync<Surface>(url);

            return surface;
        }

        public async Task<Surface?> AddSurface(int XSize, int YSize)
        {
            var url = BASE_URL + string.Format(ADD, XSize, YSize);

            var newSurface = await mHttpClient.PostAsync<Surface>(url);

            return newSurface;
        }
    }
}

